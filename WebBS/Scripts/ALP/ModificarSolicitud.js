$(document).ready(function () {

    var sucursal = $("#txtDefaultSucursal").val();

    $("#selSucursal").val(sucursal);

    $("#btnActualizar").on("click", ActualizarSolicitud);

    function ActualizarSolicitud() {

        var nroSolicitud = $("#txtNroSolicitud").val();
        var codSucursal = $("#selSucursal").val();
        var obs = $("#txtObs").val();

        var params = { nroSolicitud: nroSolicitud, codSucursal: codSucursal, obs: obs };

        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/Solicitud/Actualizar",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                console.log(data);

                if (data.Success) {

                    bootbox.alert("Se actualizó satisfactoriamente la Solicitud de Transporte : " + data.Object, function () {
                        window.location.replace("/Solicitud/Lista");
                    });

                }

            }
        });

    }

});