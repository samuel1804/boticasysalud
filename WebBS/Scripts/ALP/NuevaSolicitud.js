$(document).ready(function () {
    
    var sucursal = $("#txtDefaultSucursal").val();

    $("#selSucursal").val(sucursal);

    $("#btnEmitir").on("click", EmitirSolicitud);

    function EmitirSolicitud()
    {

        var nroConstancia = $("#txtNroConstancia").val();
        var codSucursal = $("#selSucursal").val();
        var obs = $("#txtObs").val();

        var params = { nroConstancia: nroConstancia, codSucursal: codSucursal, obs: obs};

        var data = JSON.stringify(params);

        $.ajax({
            type: "POST",
            url: "/Solicitud/Guardar",
            data: data,
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            error: function (data) {
                console.log(data);
            },
            success: function (data) {

                console.log(data);

                if (data.Success) {
                    
                    bootbox.alert("Se registró satisfactoriamente la Solicitud de Transporte : " + data.Object, function () {
                        window.location.replace("/Solicitud/Lista");
                    });

                }

            }
        });

    }

});