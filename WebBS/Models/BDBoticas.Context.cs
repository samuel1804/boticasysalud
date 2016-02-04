﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BDBoticasEntities : DbContext
    {
        public BDBoticasEntities()
            : base("name=BDBoticasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ALP_CONSTANCIA_PREPARADO> ALP_CONSTANCIA_PREPARADO { get; set; }
        public virtual DbSet<ALP_HOJA_MERMA> ALP_HOJA_MERMA { get; set; }
        public virtual DbSet<ALP_INSUMO> ALP_INSUMO { get; set; }
        public virtual DbSet<ALP_LIBRO_RECETA> ALP_LIBRO_RECETA { get; set; }
        public virtual DbSet<ALP_ORDEN_PREPARADO> ALP_ORDEN_PREPARADO { get; set; }
        public virtual DbSet<ALP_ORDEN_PREPARADO_INSUMO> ALP_ORDEN_PREPARADO_INSUMO { get; set; }
        public virtual DbSet<ALP_RECETA> ALP_RECETA { get; set; }
        public virtual DbSet<DIS_Control_Asignacion> DIS_Control_Asignacion { get; set; }
        public virtual DbSet<DIS_HojaRuta> DIS_HojaRuta { get; set; }
        public virtual DbSet<DIS_HojaRutaDetalle> DIS_HojaRutaDetalle { get; set; }
        public virtual DbSet<DIS_Pedido> DIS_Pedido { get; set; }
        public virtual DbSet<DIS_Pedido_Detalle> DIS_Pedido_Detalle { get; set; }
        public virtual DbSet<DIS_PresentacionProducto> DIS_PresentacionProducto { get; set; }
        public virtual DbSet<DIS_Producto> DIS_Producto { get; set; }
        public virtual DbSet<DIS_TipoProducto> DIS_TipoProducto { get; set; }
        public virtual DbSet<DIS_Transportista> DIS_Transportista { get; set; }
        public virtual DbSet<DIS_Vehiculo> DIS_Vehiculo { get; set; }
        public virtual DbSet<GCC_CLIENTE> GCC_CLIENTE { get; set; }
        public virtual DbSet<GCC_CLIENTE_JURIDICO> GCC_CLIENTE_JURIDICO { get; set; }
        public virtual DbSet<GCC_CLIENTE_NATURAL> GCC_CLIENTE_NATURAL { get; set; }
        public virtual DbSet<GCC_COMPROBANTE> GCC_COMPROBANTE { get; set; }
        public virtual DbSet<GCC_CONTRATO_CREDITO> GCC_CONTRATO_CREDITO { get; set; }
        public virtual DbSet<GCC_CUENTA_CLIENTE> GCC_CUENTA_CLIENTE { get; set; }
        public virtual DbSet<GCC_DOCUMENTO_RECHAZO> GCC_DOCUMENTO_RECHAZO { get; set; }
        public virtual DbSet<GCC_EMPLEADO_INF_CREDITICIO> GCC_EMPLEADO_INF_CREDITICIO { get; set; }
        public virtual DbSet<GCC_EMPLEADO_SOL_CREDITO> GCC_EMPLEADO_SOL_CREDITO { get; set; }
        public virtual DbSet<GCC_INFORME_CREDITICIO> GCC_INFORME_CREDITICIO { get; set; }
        public virtual DbSet<GCC_NOTIFICACION> GCC_NOTIFICACION { get; set; }
        public virtual DbSet<GCC_PLAN_CREDITO> GCC_PLAN_CREDITO { get; set; }
        public virtual DbSet<GCC_POLITICA_CREDITO> GCC_POLITICA_CREDITO { get; set; }
        public virtual DbSet<GCC_POLITICAS_NOTIFICACION> GCC_POLITICAS_NOTIFICACION { get; set; }
        public virtual DbSet<GCC_SOLICITUD_CREDITO> GCC_SOLICITUD_CREDITO { get; set; }
        public virtual DbSet<IMP_ACCION> IMP_ACCION { get; set; }
        public virtual DbSet<IMP_ACTIVIDAD> IMP_ACTIVIDAD { get; set; }
        public virtual DbSet<IMP_ACTIVIDAD_PLANIFICADA> IMP_ACTIVIDAD_PLANIFICADA { get; set; }
        public virtual DbSet<IMP_ADQUISICION> IMP_ADQUISICION { get; set; }
        public virtual DbSet<IMP_ALERTA> IMP_ALERTA { get; set; }
        public virtual DbSet<IMP_ARTICULO> IMP_ARTICULO { get; set; }
        public virtual DbSet<IMP_BITACORA_EVENTO> IMP_BITACORA_EVENTO { get; set; }
        public virtual DbSet<IMP_BL> IMP_BL { get; set; }
        public virtual DbSet<IMP_CERTIFICADO_ISO> IMP_CERTIFICADO_ISO { get; set; }
        public virtual DbSet<IMP_CERTIFICADO_MANUFACTURA> IMP_CERTIFICADO_MANUFACTURA { get; set; }
        public virtual DbSet<IMP_CONCEPTO> IMP_CONCEPTO { get; set; }
        public virtual DbSet<IMP_DAM> IMP_DAM { get; set; }
        public virtual DbSet<IMP_DEPARTAMENTO> IMP_DEPARTAMENTO { get; set; }
        public virtual DbSet<IMP_DESADUANAJE> IMP_DESADUANAJE { get; set; }
        public virtual DbSet<IMP_DETALLE_FACTURA_COMERCIAL> IMP_DETALLE_FACTURA_COMERCIAL { get; set; }
        public virtual DbSet<IMP_DETALLE_ORDEN_COMPRA> IMP_DETALLE_ORDEN_COMPRA { get; set; }
        public virtual DbSet<IMP_DISTRITO> IMP_DISTRITO { get; set; }
        public virtual DbSet<IMP_EVENTO> IMP_EVENTO { get; set; }
        public virtual DbSet<IMP_FACTURA_COMERCIAL> IMP_FACTURA_COMERCIAL { get; set; }
        public virtual DbSet<IMP_ORDEN_COMPRA> IMP_ORDEN_COMPRA { get; set; }
        public virtual DbSet<IMP_PAGO_IMPORTACION> IMP_PAGO_IMPORTACION { get; set; }
        public virtual DbSet<IMP_PROVEEDOR> IMP_PROVEEDOR { get; set; }
        public virtual DbSet<IMP_PROVINCIA> IMP_PROVINCIA { get; set; }
        public virtual DbSet<IMP_PUERTO> IMP_PUERTO { get; set; }
        public virtual DbSet<IMP_RESOLUCION_DIGEMID> IMP_RESOLUCION_DIGEMID { get; set; }
        public virtual DbSet<IMP_SOLICITUD> IMP_SOLICITUD { get; set; }
        public virtual DbSet<IMP_SOLICITUD_GESTION_PERMISO> IMP_SOLICITUD_GESTION_PERMISO { get; set; }
        public virtual DbSet<IMP_SOLICITUD_IMPORTACION> IMP_SOLICITUD_IMPORTACION { get; set; }
        public virtual DbSet<IMP_TIPO_ACTIVIDAD> IMP_TIPO_ACTIVIDAD { get; set; }
        public virtual DbSet<IMP_TIPO_CAMBIO> IMP_TIPO_CAMBIO { get; set; }
        public virtual DbSet<IMP_TIPO_EVENTO> IMP_TIPO_EVENTO { get; set; }
        public virtual DbSet<IMP_TIPO_MONEDA> IMP_TIPO_MONEDA { get; set; }
        public virtual DbSet<IMP_TIPO_PAGO> IMP_TIPO_PAGO { get; set; }
        public virtual DbSet<RRH_AlternativaEvaluacionTecnica> RRH_AlternativaEvaluacionTecnica { get; set; }
        public virtual DbSet<RRH_Area> RRH_Area { get; set; }
        public virtual DbSet<RRH_Candidato> RRH_Candidato { get; set; }
        public virtual DbSet<RRH_Criterio> RRH_Criterio { get; set; }
        public virtual DbSet<RRH_Distrito> RRH_Distrito { get; set; }
        public virtual DbSet<RRH_Empleado> RRH_Empleado { get; set; }
        public virtual DbSet<RRH_EvaluacionTecnica> RRH_EvaluacionTecnica { get; set; }
        public virtual DbSet<RRH_ExperienciaLaboral> RRH_ExperienciaLaboral { get; set; }
        public virtual DbSet<RRH_GradoAcademico> RRH_GradoAcademico { get; set; }
        public virtual DbSet<RRH_OfertaLaboral> RRH_OfertaLaboral { get; set; }
        public virtual DbSet<RRH_OfertaLaboral_Candidato> RRH_OfertaLaboral_Candidato { get; set; }
        public virtual DbSet<RRH_Option> RRH_Option { get; set; }
        public virtual DbSet<RRH_Perfil> RRH_Perfil { get; set; }
        public virtual DbSet<RRH_PreguntaEvaluacionTecnica> RRH_PreguntaEvaluacionTecnica { get; set; }
        public virtual DbSet<RRH_PruebaAutoevaluacion> RRH_PruebaAutoevaluacion { get; set; }
        public virtual DbSet<RRH_PruebaAutoevaluacion_Respuesta> RRH_PruebaAutoevaluacion_Respuesta { get; set; }
        public virtual DbSet<RRH_PruebaEvaluacionTecnica> RRH_PruebaEvaluacionTecnica { get; set; }
        public virtual DbSet<RRH_Puesto> RRH_Puesto { get; set; }
        public virtual DbSet<RRH_ReferenciaLaboral> RRH_ReferenciaLaboral { get; set; }
        public virtual DbSet<RRH_RespuestaAutoevaluacion> RRH_RespuestaAutoevaluacion { get; set; }
        public virtual DbSet<RRH_Sucursal> RRH_Sucursal { get; set; }
        public virtual DbSet<RRH_Usuario> RRH_Usuario { get; set; }
        public virtual DbSet<RYA_ACTARECEP_CAB> RYA_ACTARECEP_CAB { get; set; }
        public virtual DbSet<RYA_ACTARECEP_DET> RYA_ACTARECEP_DET { get; set; }
        public virtual DbSet<RYA_ALMACENES> RYA_ALMACENES { get; set; }
        public virtual DbSet<RYA_LOTES> RYA_LOTES { get; set; }
        public virtual DbSet<RYA_MOVALM_CAB> RYA_MOVALM_CAB { get; set; }
        public virtual DbSet<RYA_MOVALM_DET> RYA_MOVALM_DET { get; set; }
        public virtual DbSet<RYA_PEDIDO_CAB> RYA_PEDIDO_CAB { get; set; }
        public virtual DbSet<RYA_PEDIDO_DET> RYA_PEDIDO_DET { get; set; }
        public virtual DbSet<RYA_PRODUCTO> RYA_PRODUCTO { get; set; }
        public virtual DbSet<RYA_STOCK> RYA_STOCK { get; set; }
        public virtual DbSet<RYA_SUCURSALES> RYA_SUCURSALES { get; set; }
        public virtual DbSet<RYA_TRANSA_ALMA> RYA_TRANSA_ALMA { get; set; }
        public virtual DbSet<RYA_UBICACIONES> RYA_UBICACIONES { get; set; }
        public virtual DbSet<RRH_Puesto_Option> RRH_Puesto_Option { get; set; }
    
        public virtual int sp_DetalleReceta_Buscar(string wHERE)
        {
            var wHEREParameter = wHERE != null ?
                new ObjectParameter("WHERE", wHERE) :
                new ObjectParameter("WHERE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DetalleReceta_Buscar", wHEREParameter);
        }
    
        public virtual int sp_Kardex_ObtenerUltimoMovimiento(string wHERE)
        {
            var wHEREParameter = wHERE != null ?
                new ObjectParameter("WHERE", wHERE) :
                new ObjectParameter("WHERE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Kardex_ObtenerUltimoMovimiento", wHEREParameter);
        }
    
        public virtual int sp_Orden_Anular(string codigo)
        {
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Orden_Anular", codigoParameter);
        }
    
        public virtual int sp_OrdenPreparado_Actualizar(string codigo_Orden, Nullable<System.DateTime> fecha, string tecnico_Farmaceutico, string receta_Cliente, string codigo_Sucursal, string codigo_Receta, string estado)
        {
            var codigo_OrdenParameter = codigo_Orden != null ?
                new ObjectParameter("Codigo_Orden", codigo_Orden) :
                new ObjectParameter("Codigo_Orden", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var tecnico_FarmaceuticoParameter = tecnico_Farmaceutico != null ?
                new ObjectParameter("Tecnico_Farmaceutico", tecnico_Farmaceutico) :
                new ObjectParameter("Tecnico_Farmaceutico", typeof(string));
    
            var receta_ClienteParameter = receta_Cliente != null ?
                new ObjectParameter("Receta_Cliente", receta_Cliente) :
                new ObjectParameter("Receta_Cliente", typeof(string));
    
            var codigo_SucursalParameter = codigo_Sucursal != null ?
                new ObjectParameter("Codigo_Sucursal", codigo_Sucursal) :
                new ObjectParameter("Codigo_Sucursal", typeof(string));
    
            var codigo_RecetaParameter = codigo_Receta != null ?
                new ObjectParameter("Codigo_Receta", codigo_Receta) :
                new ObjectParameter("Codigo_Receta", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_OrdenPreparado_Actualizar", codigo_OrdenParameter, fechaParameter, tecnico_FarmaceuticoParameter, receta_ClienteParameter, codigo_SucursalParameter, codigo_RecetaParameter, estadoParameter);
        }
    
        public virtual int sp_OrdenPreparado_Crear(string codigo_Orden, Nullable<System.DateTime> fecha, string tecnico_Farmaceutico, string receta_Cliente, string codigo_Sucursal, string codigo_Receta, string estado)
        {
            var codigo_OrdenParameter = codigo_Orden != null ?
                new ObjectParameter("Codigo_Orden", codigo_Orden) :
                new ObjectParameter("Codigo_Orden", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var tecnico_FarmaceuticoParameter = tecnico_Farmaceutico != null ?
                new ObjectParameter("Tecnico_Farmaceutico", tecnico_Farmaceutico) :
                new ObjectParameter("Tecnico_Farmaceutico", typeof(string));
    
            var receta_ClienteParameter = receta_Cliente != null ?
                new ObjectParameter("Receta_Cliente", receta_Cliente) :
                new ObjectParameter("Receta_Cliente", typeof(string));
    
            var codigo_SucursalParameter = codigo_Sucursal != null ?
                new ObjectParameter("Codigo_Sucursal", codigo_Sucursal) :
                new ObjectParameter("Codigo_Sucursal", typeof(string));
    
            var codigo_RecetaParameter = codigo_Receta != null ?
                new ObjectParameter("Codigo_Receta", codigo_Receta) :
                new ObjectParameter("Codigo_Receta", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_OrdenPreparado_Crear", codigo_OrdenParameter, fechaParameter, tecnico_FarmaceuticoParameter, receta_ClienteParameter, codigo_SucursalParameter, codigo_RecetaParameter, estadoParameter);
        }
    
        public virtual int sp_Receta_Buscar(string wHERE)
        {
            var wHEREParameter = wHERE != null ?
                new ObjectParameter("WHERE", wHERE) :
                new ObjectParameter("WHERE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Receta_Buscar", wHEREParameter);
        }
    
        public virtual int sp_Table_List(string tabla)
        {
            var tablaParameter = tabla != null ?
                new ObjectParameter("Tabla", tabla) :
                new ObjectParameter("Tabla", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Table_List", tablaParameter);
        }
    
        public virtual int sp_Table_List_Codigo_Orden(string filtro)
        {
            var filtroParameter = filtro != null ?
                new ObjectParameter("filtro", filtro) :
                new ObjectParameter("filtro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Table_List_Codigo_Orden", filtroParameter);
        }
    
        public virtual int sp_Table_List_Nom_Receta(string filtro)
        {
            var filtroParameter = filtro != null ?
                new ObjectParameter("filtro", filtro) :
                new ObjectParameter("filtro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Table_List_Nom_Receta", filtroParameter);
        }
    
        public virtual int sp_Table_List_Nom_Sucursal(string filtro)
        {
            var filtroParameter = filtro != null ?
                new ObjectParameter("filtro", filtro) :
                new ObjectParameter("filtro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Table_List_Nom_Sucursal", filtroParameter);
        }
    
        public virtual int sp_Table_List_Todos(string tabla)
        {
            var tablaParameter = tabla != null ?
                new ObjectParameter("Tabla", tabla) :
                new ObjectParameter("Tabla", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Table_List_Todos", tablaParameter);
        }
    
        public virtual ObjectResult<usp_Chofer_GetAll_Result> usp_Chofer_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_Chofer_GetAll_Result>("usp_Chofer_GetAll");
        }
    
        public virtual ObjectResult<Nullable<int>> RRH_Criterio_Insert(string desc_criterio)
        {
            var desc_criterioParameter = desc_criterio != null ?
                new ObjectParameter("Desc_criterio", desc_criterio) :
                new ObjectParameter("Desc_criterio", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("RRH_Criterio_Insert", desc_criterioParameter);
        }
    
        public virtual ObjectResult<RRH_Empleado_Get_Result> RRH_Empleado_Get(Nullable<int> cod_Empleado)
        {
            var cod_EmpleadoParameter = cod_Empleado.HasValue ?
                new ObjectParameter("Cod_Empleado", cod_Empleado) :
                new ObjectParameter("Cod_Empleado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RRH_Empleado_Get_Result>("RRH_Empleado_Get", cod_EmpleadoParameter);
        }
    
        public virtual ObjectResult<RRH_Empleado_GetJefe_Result> RRH_Empleado_GetJefe()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RRH_Empleado_GetJefe_Result>("RRH_Empleado_GetJefe");
        }
    
        public virtual ObjectResult<RRH_Empleado_Select_Result> RRH_Empleado_Select(Nullable<int> cod_Jefe, string nomCompleto, string nom_puesto)
        {
            var cod_JefeParameter = cod_Jefe.HasValue ?
                new ObjectParameter("Cod_Jefe", cod_Jefe) :
                new ObjectParameter("Cod_Jefe", typeof(int));
    
            var nomCompletoParameter = nomCompleto != null ?
                new ObjectParameter("NomCompleto", nomCompleto) :
                new ObjectParameter("NomCompleto", typeof(string));
    
            var nom_puestoParameter = nom_puesto != null ?
                new ObjectParameter("Nom_puesto", nom_puesto) :
                new ObjectParameter("Nom_puesto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RRH_Empleado_Select_Result>("RRH_Empleado_Select", cod_JefeParameter, nomCompletoParameter, nom_puestoParameter);
        }
    
        public virtual ObjectResult<RRH_PreguntaEvaluacionTecnica_get_Result> RRH_PreguntaEvaluacionTecnica_get(Nullable<int> cod_perfil)
        {
            var cod_perfilParameter = cod_perfil.HasValue ?
                new ObjectParameter("Cod_perfil", cod_perfil) :
                new ObjectParameter("Cod_perfil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RRH_PreguntaEvaluacionTecnica_get_Result>("RRH_PreguntaEvaluacionTecnica_get", cod_perfilParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> RRH_PreguntaEvaluacionTecnica_Insert(Nullable<int> cod_preg_eva_tec, string titulo, string pregunta, Nullable<System.DateTime> fec_creacion, Nullable<int> cod_criterio, string cod_usu_regi, Nullable<System.DateTime> fec_usu_regi, Nullable<int> cod_alternativa_evaluaciontec, Nullable<int> cod_perfil)
        {
            var cod_preg_eva_tecParameter = cod_preg_eva_tec.HasValue ?
                new ObjectParameter("Cod_preg_eva_tec", cod_preg_eva_tec) :
                new ObjectParameter("Cod_preg_eva_tec", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var preguntaParameter = pregunta != null ?
                new ObjectParameter("Pregunta", pregunta) :
                new ObjectParameter("Pregunta", typeof(string));
    
            var fec_creacionParameter = fec_creacion.HasValue ?
                new ObjectParameter("Fec_creacion", fec_creacion) :
                new ObjectParameter("Fec_creacion", typeof(System.DateTime));
    
            var cod_criterioParameter = cod_criterio.HasValue ?
                new ObjectParameter("Cod_criterio", cod_criterio) :
                new ObjectParameter("Cod_criterio", typeof(int));
    
            var cod_usu_regiParameter = cod_usu_regi != null ?
                new ObjectParameter("Cod_usu_regi", cod_usu_regi) :
                new ObjectParameter("Cod_usu_regi", typeof(string));
    
            var fec_usu_regiParameter = fec_usu_regi.HasValue ?
                new ObjectParameter("Fec_usu_regi", fec_usu_regi) :
                new ObjectParameter("Fec_usu_regi", typeof(System.DateTime));
    
            var cod_alternativa_evaluaciontecParameter = cod_alternativa_evaluaciontec.HasValue ?
                new ObjectParameter("Cod_alternativa_evaluaciontec", cod_alternativa_evaluaciontec) :
                new ObjectParameter("Cod_alternativa_evaluaciontec", typeof(int));
    
            var cod_perfilParameter = cod_perfil.HasValue ?
                new ObjectParameter("Cod_perfil", cod_perfil) :
                new ObjectParameter("Cod_perfil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("RRH_PreguntaEvaluacionTecnica_Insert", cod_preg_eva_tecParameter, tituloParameter, preguntaParameter, fec_creacionParameter, cod_criterioParameter, cod_usu_regiParameter, fec_usu_regiParameter, cod_alternativa_evaluaciontecParameter, cod_perfilParameter);
        }
    
        public virtual ObjectResult<RRH_PreguntaEvaluacionTecnica_Select_Result> RRH_PreguntaEvaluacionTecnica_Select(Nullable<int> startRowIndex, Nullable<int> maximumRows)
        {
            var startRowIndexParameter = startRowIndex.HasValue ?
                new ObjectParameter("startRowIndex", startRowIndex) :
                new ObjectParameter("startRowIndex", typeof(int));
    
            var maximumRowsParameter = maximumRows.HasValue ?
                new ObjectParameter("maximumRows", maximumRows) :
                new ObjectParameter("maximumRows", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RRH_PreguntaEvaluacionTecnica_Select_Result>("RRH_PreguntaEvaluacionTecnica_Select", startRowIndexParameter, maximumRowsParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> RRH_PreguntaEvaluacionTecnica_Update(Nullable<int> cod_preg_eva_tec, string titulo, string pregunta, Nullable<System.DateTime> fec_creacion, Nullable<int> cod_criterio, string cod_usu_regi, Nullable<System.DateTime> fec_usu_regi, Nullable<int> cod_alternativa_evaluaciontec, Nullable<int> cod_perfil)
        {
            var cod_preg_eva_tecParameter = cod_preg_eva_tec.HasValue ?
                new ObjectParameter("Cod_preg_eva_tec", cod_preg_eva_tec) :
                new ObjectParameter("Cod_preg_eva_tec", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var preguntaParameter = pregunta != null ?
                new ObjectParameter("Pregunta", pregunta) :
                new ObjectParameter("Pregunta", typeof(string));
    
            var fec_creacionParameter = fec_creacion.HasValue ?
                new ObjectParameter("Fec_creacion", fec_creacion) :
                new ObjectParameter("Fec_creacion", typeof(System.DateTime));
    
            var cod_criterioParameter = cod_criterio.HasValue ?
                new ObjectParameter("Cod_criterio", cod_criterio) :
                new ObjectParameter("Cod_criterio", typeof(int));
    
            var cod_usu_regiParameter = cod_usu_regi != null ?
                new ObjectParameter("Cod_usu_regi", cod_usu_regi) :
                new ObjectParameter("Cod_usu_regi", typeof(string));
    
            var fec_usu_regiParameter = fec_usu_regi.HasValue ?
                new ObjectParameter("Fec_usu_regi", fec_usu_regi) :
                new ObjectParameter("Fec_usu_regi", typeof(System.DateTime));
    
            var cod_alternativa_evaluaciontecParameter = cod_alternativa_evaluaciontec.HasValue ?
                new ObjectParameter("Cod_alternativa_evaluaciontec", cod_alternativa_evaluaciontec) :
                new ObjectParameter("Cod_alternativa_evaluaciontec", typeof(int));
    
            var cod_perfilParameter = cod_perfil.HasValue ?
                new ObjectParameter("Cod_perfil", cod_perfil) :
                new ObjectParameter("Cod_perfil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("RRH_PreguntaEvaluacionTecnica_Update", cod_preg_eva_tecParameter, tituloParameter, preguntaParameter, fec_creacionParameter, cod_criterioParameter, cod_usu_regiParameter, fec_usu_regiParameter, cod_alternativa_evaluaciontecParameter, cod_perfilParameter);
        }
    }
}
