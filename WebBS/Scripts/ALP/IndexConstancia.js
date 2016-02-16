$(document).ready(function () {
    
    var now = new Date();

    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    /*var today = now.getFullYear() + "-" + (month) + "-" + (day);

    $('#txtFecOrden').val(today);*/

    $("#btnBuscar").on("click", BuscarOrden);

    BuscarOrden();

    function BuscarOrden() {
        
        var nroOrden = $("#txtNroOrden").val();
        var fechaOrden = $("#txtFecOrden").val();
        var nomPreparado = $("#txtNomPreparado").val();
        var sucursal = parseInt($("#selSucursal").val());

        var params = { nroOrden: nroOrden, fechaOrden: fechaOrden, nomPreparado: nomPreparado, sucursal: sucursal };

        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/OrdenPreparado/BuscarOrden",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                if (data.Success) {

                    var html = "";

                    $.each(data.Object, function (index, value) {
                        html += "<tr>";
                        html += "<td>" + value.nroOrden + "</td>";
                        html += "<td>" + value.fechaOrden + "</td>";
                        html += "<td>" + value.sucursal + "</td>";
                        html += "<td>" + value.nomPreparado + "</td>";
                        html += "<td><a href='../Constancia/Nuevo?num_orden=" + value.nroOrden + "'>Nueva Constancia</a></td>";
                        html += "<tr>";
                    });

                    $("#tbOrdenContent").html(html);
                                        
                }

            }
        });

    }

});