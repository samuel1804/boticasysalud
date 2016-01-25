using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pe.ByS.ERP.CrossCutting.Common;
using Pe.ByS.ERP.CrossCutting.Common.Enums;
using Pe.ByS.ERP.CrossCutting.Common.JQGrid;
using Pe.ByS.ERP.Domain.Core;
using Pe.ByS.ERP.Services.BusinessLogic.Inter;

namespace Pe.ByS.ERP.Services.BusinessLogic.Core
{
    public class ListJQGridParameter<T> where T: EntityBase
    {
        public ListJQGridParameter()
        {
            MostrarSoloActivos = true;
        }

        private IJQGridPaging<T> _businessLogicClass;
        public IJQGridPaging<T> BusinessLogicClass {
            get
            {
                return _businessLogicClass;
            }
            set
            {
                _businessLogicClass = value;
                CountMethod = _businessLogicClass.Count;
                ListMethod = _businessLogicClass.GetAll;
            }
        }

        private Expression<Func<T, bool>> _filtrosAdicionales;
        public Expression<Func<T, bool>> FiltrosAdicionales 
        {
            get
            {
                return _filtrosAdicionales ?? (p => !MostrarSoloActivos || p.Estado == (int) TipoEstado.Activo);
            }
            set
            {
                _filtrosAdicionales = MostrarSoloActivos ? value.And(p => p.Estado == (int) TipoEstado.Activo) : value;
            }
        }

        public GridTable Grid { get; set; }
        public Func<T, Row> SelecctionFormat { get; set; }
        
        public Func<Expression<Func<T, bool>>, int> CountMethod { get; set; }
        public Func<JQGridParameters<T>, IQueryable<T>> ListMethod { get; set; }
        public List<Expression<Func<T, object>>> ObjectIncludeList { get; set; }
        public bool MostrarSoloActivos { get; set; }
    }
}