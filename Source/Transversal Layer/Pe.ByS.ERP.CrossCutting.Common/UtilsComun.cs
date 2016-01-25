using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;
using RazorEngine;

namespace Pe.ByS.ERP.CrossCutting.Common
{
    public static class UtilsComun
    {
        /// <summary>
        /// Metodo para obtener una expresion Lambda para un OrderBy en base al nombre de la propiedad
        /// </summary>
        /// <typeparam name="T">El tipo la clase que contiene la propiedad</typeparam>
        /// <param name="propiedad">El nombre de la propiedad que se usara en el OrderBy</param>
        /// <returns>Una expresion del tipo Expression<Func<T,[TipoPropiedad]>></returns>
        public static dynamic LambdaPropertyOrderBy<T>(string propiedad)
        {
            string[] listaPropiedades = propiedad.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            foreach (string prop in listaPropiedades)
            {
                PropertyInfo propertyInfo = type.GetProperty(prop);
                expr = Expression.MakeMemberAccess(expr, propertyInfo);
                type = propertyInfo.PropertyType;
            }

            return Expression.Lambda(expr, arg);
        }

        public static Expression<Func<T, bool>> ConvertToLambda<T>(string filters) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;
            Filter parametros = (string.IsNullOrEmpty(filters)) ? null : JsonConvert.DeserializeObject<Filter>(filters);

            if (parametros == null)
                return expresionsLambdaSet ?? PredicateBuilder.True<T>();

            expresionsLambdaSet = MergeRules<T>(parametros);

            return expresionsLambdaSet ?? PredicateBuilder.True<T>();
        }

        public static Expression GetMemberAccessLambda<T>(ParameterExpression arg, string itemField) where T: class
        {
            var listaPropiedades = itemField.Split('.');
            Expression expression = arg;

            var tipoActual = typeof(T);

            foreach (var propiedad in listaPropiedades)
            {
                var propertyInfo = tipoActual.GetProperty(propiedad);
                expression = Expression.MakeMemberAccess(expression, propertyInfo);
                tipoActual = propertyInfo.PropertyType;
            }

            return expression;
        }

        private static Expression<Func<T, bool>> MergeRules<T>(Filter parametro) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;

            Expression comparison = null;

            foreach (Rule item in parametro.rules)
            {
                var arg = Expression.Parameter(typeof(T), "p");
                PropertyInfo property;

                if (item.field.Contains("."))
                {
                    #region Seccion para obtener la ultima propiedad de la composicion

                    var properties = item.field.Split('.');
                    var tipoActual = typeof(T);
                    PropertyInfo propertyInfo = null;

                    foreach (var propiedad in properties)
                    {
                        propertyInfo = tipoActual.GetProperty(propiedad);
                        tipoActual = propertyInfo.PropertyType;
                    }

                    property = propertyInfo; 

                    #endregion
                }
                else
                    property = typeof(T).GetProperty(item.field);

                var valorEvaluar = item.data == null ?
                    (Expression)Expression.Constant(item.data) :
                    Expression.Convert(Expression.Constant(Convert.ChangeType(item.data,
                    Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType)), property.PropertyType);

                switch (item.op)
                {
                    #region Lista de Expresiones Comparativas

                    case "bw":
                        MethodInfo miBeginWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                        comparison = Expression.Call(GetMemberAccessLambda<T>(arg, item.field), miBeginWith, valorEvaluar);
                        break;
                    case "gt":
                        comparison = Expression.GreaterThanOrEqual(GetMemberAccessLambda<T>(arg, item.field), valorEvaluar);
                        break;
                    case "lt":
                        comparison = Expression.LessThanOrEqual(GetMemberAccessLambda<T>(arg, item.field), valorEvaluar);
                        break;
                    case "eq":
                        comparison = Expression.Equal(GetMemberAccessLambda<T>(arg, item.field), valorEvaluar);
                        break;
                    case "ne":
                        comparison = Expression.NotEqual(GetMemberAccessLambda<T>(arg, item.field), valorEvaluar);
                        break;
                    case "ew":
                        MethodInfo miEndsWith = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                        comparison = Expression.Call(GetMemberAccessLambda<T>(arg, item.field), miEndsWith, valorEvaluar);
                        break;
                    case "cn":
                        MethodInfo miContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        comparison = Expression.Call(GetMemberAccessLambda<T>(arg, item.field), miContains, valorEvaluar);
                        break;
                    case "fe":
                        break;

                    #endregion
                }

                #region Concatenacion de las Expresiones de los rules actuales

                if (parametro.groupOp.ToUpper() == "AND")
                {
                    if (expresionsLambdaSet != null)
                        expresionsLambdaSet = expresionsLambdaSet.And(Expression.Lambda<Func<T, bool>>(comparison, arg));
                    else
                        expresionsLambdaSet = Expression.Lambda<Func<T, bool>>(comparison, arg);

                }
                else if (parametro.groupOp.ToUpper() == "OR")
                {
                    expresionsLambdaSet = expresionsLambdaSet != null
                        ? expresionsLambdaSet.Or(Expression.Lambda<Func<T, bool>>(comparison, arg))
                        : Expression.Lambda<Func<T, bool>>(comparison, arg);
                }
                else
                    throw new ArgumentException("Argumento GroupOp invalido"); 

                #endregion
            }

            if (parametro.groups == null)
                return expresionsLambdaSet;

            #region Manejo de Expresiones hijas de esta expresion

            foreach (var parametroHijo in parametro.groups)
            {
                var expressionHijo = MergeRules<T>(parametroHijo);
                if (expressionHijo == null) continue;

                if (expresionsLambdaSet == null)
                {
                    expresionsLambdaSet = expressionHijo;
                    continue;
                }

                if (parametro.groupOp.ToUpper() == "AND")
                {
                    expresionsLambdaSet = expresionsLambdaSet.And(expressionHijo);
                }
                else if (parametro.groupOp.ToUpper() == "OR")
                {
                    expresionsLambdaSet = expresionsLambdaSet.Or(MergeRules<T>(parametroHijo));
                }
                else
                    throw new ArgumentException("Argumento GroupOp invalido");
            } 

            #endregion

            return expresionsLambdaSet;
        }

        /// <summary>
        /// Permite verificar si una clase hereda de una clase base.
        /// </summary>
        /// <param name="type">Tipo a comparar.</param>
        /// <param name="typeBase">Tipo Base a la cual se va a comparar.</param>
        /// <returns></returns>
        public static bool VerificarBaseType(Type type, Type typeBase)
        {
            bool esValido = false;
            if (type != null)
            {
                if (type.BaseType != null)
                    esValido = (type.BaseType == typeBase ||
                                (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeBase)) ||
                               VerificarBaseType(type.BaseType, typeBase);
            }
            return esValido;
        }

        public static string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;
            var errorMessage = string.Format("{0}\n{1}", ex.Message, GetExceptionMessage(ex.InnerException));
            return errorMessage;
        }

        public static string BodyEmail<T>(string contenido, T model, bool isHtml = true)
        {
            dynamic obj2 = new ExpandoObject();
            obj2.Dummy = "";
            string body = Razor.Parse(contenido, model, null);
            return body;
        }

        #region Métodos adicionales y de extensión

        /// <summary>
        /// Convierte una fecha en una cadena con formato: dd/mm/yyyy.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>dd/mm/yyyy</returns>
        public static string ConvertToDdmmaaaa(this DateTime fecha)
        {
            return string.Format("{0:dd/MM/yyyy}", fecha);
        }

        /// <summary>
        /// Convierte una fecha en una cadena con formato: dd/mm/yyyy.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>dd/mm/yyyy</returns>
        public static string ConvertToDdmmaaaa(DateTime? fecha)
        {
            return string.Format("{0:dd/MM/yyyy}", fecha);
        }

        /// <summary>
        /// Extrae la hora de una fecha en formato: hh:mm (includeMillisecond = false), hh:mm:ss (includeMillisecond = true).
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="includeMillisecond"></param>
        /// <returns>hh:mm</returns>
        public static string ConvertToHour(this DateTime fecha, bool includeMillisecond = false)
        {
            return includeMillisecond ? string.Format("{0:HH:mm:ss}", fecha) : string.Format("{0:HH:mm}", fecha);
        }

        /// <summary>
        /// Convierte una fecha en una cadena con formato: dd/mm/yyyy hh:mm:ss (includeSeconds = true), dd/mm/yyyy hh:mm (includeSeconds = false).
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="includeSeconds"></param>
        /// <returns>dd/mm/yyyy hh:mm:ss => (includeSeconds = true), dd/mm/yyyy hh:mm => (includeSeconds = false)</returns>
        public static string GetDateTime(this DateTime dateTime, bool includeSeconds = true)
        {
            return includeSeconds ? string.Format("{0:dd/MM/yyyy HH:mm:ss}", dateTime) : string.Format("{0:dd/MM/yyyy HH:mm}", dateTime);
        }

        /// <summary>
        /// Retorna la fecha con la última hora del dia: dd/mm/yy 23:59:59.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DateTime GetDateEnd(this DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
        }

        /// <summary>
        /// Retorna la fecha con la hora inicial del dia: dd/mm/yy 0:0:0.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DateTime GetDateStar(this DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
        }

        /// <summary>
        /// Retorna la fecha equivalente en base al timezone origen hacia el timezone local
        /// </summary>
        /// <param name="dateAnotherTimeZone">fecha en otro timezone distinto al local</param>
        /// <param name="timeZoneSourceId">Id del timezone en el que viene la fecha</param>
        /// <returns>Fecha equivalente en el timezone local</returns>
        public static DateTime ConvertDateTimeToLocalTimeZone(DateTime dateAnotherTimeZone, string timeZoneSourceId)
        {
            var fechaConvertida = TimeZoneInfo.ConvertTime(dateAnotherTimeZone, TimeZoneInfo.FindSystemTimeZoneById(timeZoneSourceId), TimeZoneInfo.Local);
            return fechaConvertida;
        }

        public static string GetStringValue(this System.Enum value)
        {
            return Convert.ToString(Convert.ChangeType(value, value.GetTypeCode()));
        }

        public static int GetNumberValue(this System.Enum value)
        {
            return Convert.ToInt32(Convert.ChangeType(value, value.GetTypeCode()));
        }

        #endregion Métodos adicionales y de extensión para fechas

        public static DateTime FechaLimiteEjecucion(DateTime? fechaTentativa, DateTime fechaLimiteEjecucion, DateTime fechaInicioEjecucion)
        {
            if (fechaTentativa.Value.TimeOfDay > fechaLimiteEjecucion.TimeOfDay)
            {
                var factor = 1 - fechaInicioEjecucion.Date.Subtract(fechaTentativa.Value.Date).TotalDays;
                fechaLimiteEjecucion = fechaInicioEjecucion.Date.Add(fechaLimiteEjecucion.TimeOfDay).AddDays(factor);
            }
            else
            {
                fechaLimiteEjecucion = fechaTentativa.Value.Date.Add(fechaLimiteEjecucion.TimeOfDay);
            }

            return fechaLimiteEjecucion;
        }

        #region Ip y HostName Local

        public static string IpCliente
        {
            get
            {
                string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                return ip;
            }
        }

        public static string HostNameCliente
        {
            get { return HttpContext.Current.Request.UserHostName; }
        }

        #endregion
    }
}