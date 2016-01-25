function NotaIngreso(data) {
    var self = this;
    if (!data) data = {};
    self.NumeroNotaIngreso = ko.observable(data.NumeroNotaIngreso);
    self.Fecha = ko.observable(data.Fecha);
    self.NumeroOrdenCompra = ko.observable(data.NumeroOrdenCompra);
    self.UsuarioRecibo = ko.observable(data.UsuarioRecibo);
    self.idAlmacen = ko.observable(data.idAlmacen);
    self.GuiaRemsion = ko.observable(data.GuiaRemsion);
    self.Observaciones = ko.observable(data.Observaciones);
}

function ViewModel() {
    var self = this;

    self.notas = ko.observableArray();

    self.NotaIngreso = new NotaIngreso();

    self.ver = function (data) {
        self.NotaIngreso.NumeroNotaIngreso(data.NumeroNotaIngreso);
        self.NotaIngreso.Fecha(util.date.format(data.Fecha, 'dd/MM/yyyy hh:mm tt'));
        self.NotaIngreso.NumeroOrdenCompra(data.NumeroOrdenCompra);
        self.NotaIngreso.UsuarioRecibo(data.UsuarioRecibo);
        self.NotaIngreso.idAlmacen(data.idAlmacen);
        self.NotaIngreso.GuiaRemsion(data.GuiaRemsion);
        self.NotaIngreso.Observaciones(data.Observaciones);
        $('#modal-nota').modal('show');
    }

    self.editar = function (data) {

    }

    self.eliminar = function (data) {

    }

    self.init = function () {        
        $.ajax({
            type: "GET",
            url: urlPath + 'NotaIngreso/FillIndex',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {                
                self.notas(data); //Put the response in ObservableArray
            },
            error: function (err) {
                //alert(err.status + " : " + err.statusText);
                console.log(err);
            }
        });
    }
}

$(function () {
    var modelo = new ViewModel();
    ko.applyBindings(modelo);
    modelo.init();
});