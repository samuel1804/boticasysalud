using Pe.ByS.ERP.Presentacion.Core;

namespace Pe.ByS.ERP.Presentacion.Areas.GestionPermiso.Controllers
{
    public class KardexController : BaseController
    {
        /*#region Propiedades
        /// <summary>
        /// Servicio de manejo de Solicitudes de permisos
        /// </summary>
        public ISolicitudPermisoService solicitudPermisoService { get; set; }
        public IOrdenPedidoService ordenpedidoService { get; set; }
        private readonly IJQGridPagingService<ViewKardex> viewKardexBL;
        #endregion



        public ActionResult Index()
        {
            return PartialView("Listar", null);

        }


        [HttpPost]
        public  JsonResult ListarViewKardex(GridTable grid)
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                var filtros = new OrdenPedidoRequest();

                var listaMovimientoEntrada = ordenpedidoService.ListarPedido(filtros);

                jsonResponse.Success = true;
                jsonResponse.Message = "Exito";
                var midata = listaMovimientoEntrada.Result.Select(p => new
                {
                    Codigo = p.Codigo.ToString(),
                    NumeroPedido = p.NumeroPedido,
                    Direccion = p.Tienda.Direccion
                });

                var lista = from item in midata select new {
                              id = item.Codigo ,
                             cell = new[]
                            {
                                item.Codigo.ToString(),
                                item.NumeroPedido,  
                                item.Direccion 
                            }
                };
                return Json(lista);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        
        public ActionResult EliminarPedido(string id)
        {
            //OrdenPedidoRequest request = new OrdenPedidoRequest();
            //request.Codigo = model.Codigo;
            //request.IdTienda = model.IdTienda;
            //request.IdEstado = model.IdEstado;
            //request.Fecha = Convert.ToDateTime(model.Fecha);
            //request.NumeroPedido = model.NumeroPedido;
            List<int> lista = new List<int>();
            lista.Add(Convert.ToInt32(id));
            var resultado = ordenpedidoService.Eliminar(lista);    //.Guardar(request);
            return PartialView("Listar");                     
        }*/

    }
}