var webApp = function () {
    var _popupMensaje = "popupMensaje";
    var _tituloPopupMensaje = "Información";
    var _btnAceptar = "Aceptar";
    var _popupConfirmacion = "popupConfirmacion";
    var _tituloPopupComfirmacion = "Confirmación";
    var _btnCancelar = "Cancelar";
    var _mensajePopupConfirmacion = "Está seguro de realizar esta operación?";
    
    var createMessageDialog = function () {
        var dialogMessage =
			'<div id=' + _popupMensaje + ' class="modal fade">\
			  <div class="modal-dialog">\
			   <div class="modal-content">\
			    <div class="modal-header">\
				    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>\
					<h4 class="modal-title">' + _tituloPopupMensaje + '</h4>\
				</div>\
			    <div class="modal-body">\
				   <label></label>\
				 </div>\
				 <div class="modal-footer">\
					<button type="button" class="btn btn-sm btn-success" data-dismiss="modal"><i class="ace-icon fa fa-check"></i> ' + _btnAceptar + '</button>\
				 </div>\
			  </div>\
			 </div>\
			</div>';

        $("body").append(dialogMessage);
    };

    var createConfirmDialog = function () {
        var dialogConfirm =
			'<div id=' + _popupConfirmacion + ' class="modal fade">\
			  <div class="modal-dialog">\
			   <div class="modal-content">\
			    <div class="modal-header">\
				    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>\
					<h4 class="modal-title">' + _tituloPopupComfirmacion + '</h4>\
				</div>\
			    <div class="modal-body">\
				   <label></label>\
				 </div>\
				 <div class="modal-footer">\
					<button type="button" class="btn btn-sm btn-info" data-dismiss="modal"><i class="ace-icon fa fa-thumbs-o-up"></i> ' + _btnAceptar + '</button>\
					<button type="button" class="btn btn-sm" data-dismiss="modal"><i class="ace-icon fa fa-times"></i> ' + _btnCancelar + '</button>\
				 </div>\
			  </div>\
			 </div>\
			</div>';

        $("body").append(dialogConfirm);
    };
    
    var getDataForm = function(form) {
        var that = $(form);
        var url = that.attr('action');
        var type = that.attr('method');
        var data = {};

        that.find('[name]').each(function(index, value) {
            var that = $(this);
            var name = that.attr('name');
            var value = that.val();

            if (that.attr('type') === 'radio') {
                if (that.is(':checked')) {
                    data[name] = value;
                }
            } else if (that.attr('type') === 'checkbox') {
                if (that.is(':checked')) {
                    data[name] = value;
                }
            } else {
                data[name] = value;
            }
        });

        var obj = {
            url: url,
            type: type,
            data: data
        };

        return obj;
    };

    return {
        init: function () {
            createMessageDialog();
            createConfirmDialog();
        },
        getDataForm: getDataForm,
        showConfirmDialog: function (fnSuccess, message) {
            var popup = $('#' + _popupConfirmacion);
            var btnSuccess = $(popup).find('.btn-info');

            btnSuccess.off('click');
            if ($.isFunction(fnSuccess)) {
                btnSuccess.on('click', function () { fnSuccess(); });
            }

            $('#' + _popupConfirmacion + ' .modal-body label').text(
                (message != null && message != '')
                ? message
                : _mensajePopupConfirmacion);

            popup.modal('show');
        },
        showMessageDialog: function (fnSuccess, message) {
            var popup = $('#' + _popupMensaje);
            var btnSuccess = $(popup).find('.btn-success');

            btnSuccess.off('click');
            if ($.isFunction(fnSuccess)) {
                btnSuccess.on('click', function () { fnSuccess(); });
            }
            
            $('#' + _popupMensaje + ' .modal-body').html(message);
            popup.modal('show');
        }
    };
}();