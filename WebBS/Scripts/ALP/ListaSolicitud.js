$(document).ready(function () {
    
    var now = new Date();

    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    /*var today = now.getFullYear() + "-" + (month) + "-" + (day);

    $('#txtFecSolicitud').val(today);*/

    $("#btnBuscar").on("click", BuscarSolicitud);

    BuscarSolicitud();

    function BuscarSolicitud() {

        var nroSolicitud = $("#txtNroConstancia").val();
        var fechaSolicitud = $("#txtFecSolicitud").val();
        var nomPreparado = $("#txtNomPreparado").val();
        var sucursal = parseInt($("#selSucursal").val());

        var params = { nroSolicitud: nroSolicitud, fechaSolicitud: fechaSolicitud, nomPreparado: nomPreparado, sucursal: sucursal };

        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/Solicitud/BuscarSolicitud",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                console.log(data);

                if (data.Success) {

                    var html = "";

                    $.each(data.Object, function (index, value) {
                        html += "<tr>";
                        html += "<td>" + value.nroSolicitud + "</td>";
                        html += "<td>" + value.fechaSolicitud + "</td>";
                        html += "<td>" + value.sucursal + "</td>";
                        html += "<td>" + value.quimico + "</td>";
                        html += "<td>" + value.nomPreparado + "</td>";
                        html += "<td><a href='../Solicitud/Modificar?num_solicitud=" + value.nroSolicitud + "'>Modificar Solicitud</a></td>";
                        html += "<tr>";
                    });

                    $("#tbConstanciaContent").html(html);

                }

            }
        });

    }

});