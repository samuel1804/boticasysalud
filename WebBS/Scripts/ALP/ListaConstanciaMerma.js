$(document).ready(function () {

    var now = new Date();

    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    var today = now.getFullYear() + "-" + (month) + "-" + (day);

    $('#txtFecConstancia').val(today);

    $("#btnBuscar").on("click", BuscarConstancia);

    BuscarConstancia();

    function BuscarConstancia() {

        var nroConstancia = $("#txtNroConstancia").val();
        var fechaConstancia = $("#txtFecConstancia").val();
        var nomPreparado = $("#txtNomPreparado").val();
        var sucursal = parseInt($("#selSucursal").val());

        var params = { nroConstancia: nroConstancia, fechaConstancia: fechaConstancia, nomPreparado: nomPreparado, sucursal: sucursal };

        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/Constancia/BuscarConstancia",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                if (data.Success) {

                    if (data.Object.length == 0)
                        bootbox.alert("No hay constancias para el criterio de búsqueda");

                    var html = "";

                    $.each(data.Object, function (index, value) {
                        html += "<tr>";
                        html += "<td>" + value.nroConstancia + "</td>";
                        html += "<td>" + value.fechaConstancia + "</td>";
                        html += "<td>" + value.sucursal + "</td>";
                        html += "<td>" + value.nomPreparado + "</td>";
                        html += "<td><a href='../ControlMerma/Nuevo?num_constancia=" + value.nroConstancia + "'>Registrar Merma</a></td>";
                        html += "<tr>";
                    });

                    $("#tbConstanciaContent").html(html);

                }

            }
        });

    }

});