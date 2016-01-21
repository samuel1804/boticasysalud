/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// Controlador de métodos generales
/// </summary>
/// <remarks>
/// Creacion: 	GMD(CERS) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Util');
Pe.GMD.UI.Web.Components.Util.GetKeyCode = function (e) {
    return e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;
}

Pe.GMD.UI.Web.Components.Util.GetValueCopy = function (e) {
    var texto = "";
    if (window.clipboardData) {
        texto = window.clipboardData.getData('Text');
    }
    else {
        texto = e.originalEvent.clipboardData.getData('text/plain');
    }
    return texto;
}

Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate = function (e) {
    var ok = true;
    if (e.value.length < 10) {
        ok = false;
    }
    else {
        try {
            var date = $.datepicker.parseDate(Pe.GMD.UI.Web.Formato.Fecha, e.value);
            ok = (date.getFullYear() >= 1900)
        }
        catch (err) {
            ok = false;
        }
    }

    if (!ok) {
        $('#' + e.id).val('');
    }

    return ok;
}

Pe.GMD.UI.Web.Components.Util.ValidateCopyDate = function validarCopyFecha(e) {
    var texto = GetCopiedValue(e);
    return ValidateCopyDate(texto);
}

Pe.GMD.UI.Web.Components.Util.ValidateCopyOnlyNumeric = function (e) {
    var text = Pe.GMD.UI.Web.Components.Util.GetValueCopy(e);
    return Pe.GMD.UI.Web.Components.Util.ValidateStringOnlyNumeric(text);
}

Pe.GMD.UI.Web.Components.Util.GetCopiedValue = function (e) {
    var text = "";
    if (window.clipboardData) {
        text = window.clipboardData.getData('Text');
    }
    else {
        text = e.originalEvent.clipboardData.getData('text/plain');
    }
    return text;
}

Pe.GMD.UI.Web.Components.Util.ValidateStringOnlyNumeric = function (text) {
    var patron = /^[0-9\r\n]+$/;
    if (!text.search(patron))
        return true;
    else
        return false;
}

Pe.GMD.UI.Web.Components.Util.ValidateOnlyNumbers = function (e) {
    /*Validar la existencia del objeto event*/
    e = (e) ? e : event;

    var key = Pe.GMD.TemplateApp.Presentation.Web.Shared.Util.GetKeyCode(e);

    /*Predefinir como invalido*/
    var result = false;

    if (key >= 48 && key <= 57)
    { result = true; }
    if (evento.charCode == 0)/*direccionales*/
    { result = true; }

    if (key == 13)/*enter*/
    { result = true; }

    /*Regresar la result*/
    return result;
}

Pe.GMD.UI.Web.Components.Util.StringFormat = function () {
    // The string containing the format items (e.g. "{0}")
    // will and always has to be the first argument.
    var theString = arguments[0];

    // start with the second argument (i = 1)
    for (var i = 1; i < arguments.length; i++) {
        // "gm" = RegEx options for Global search (more than one instance)
        // and for Multiline search
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }

    return theString;
}

Pe.GMD.UI.Web.Components.Util.ValidateCopyOnlyAlphanumeric = function (e) {
    var text = Pe.GMD.UI.Web.Components.Util.GetValueCopy(e);
    var patron = /^[\u00F1A-Za-z0-9\-.\s]+$/i;
    var result = patron.test(text);
    return result;
}

Pe.GMD.UI.Web.Components.Util.ValidateCopyDate = function validarCampoFecha(value) {
    var date_regex = /^(0[1-9]|1\d|2\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/;
    return date_regex.test(value);
};

Pe.GMD.UI.Web.Components.Util.RemoveDrop = function () {
    var controls = $("input[type=text], input[type=password], textarea");
    controls.bind("drop", function () {
        return false;
    });
    controls = undefined;
}

Pe.GMD.UI.Web.Components.Util.RenderIndicador = function (data, formaAlterna) {
    var etiqueta = '';

    if (formaAlterna)
        etiqueta = Pe.GMD.UI.Web.Components.Util.RenderIndicadorDescripcion(data);
    else
        etiqueta = Pe.GMD.UI.Web.Components.Util.RenderIndicadorCheck(data);

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIndicadorDescripcion = function (data, type, full) {
    var etiqueta = '';

    if (data === true)
        etiqueta = Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSi;
    else if (data === false)
        etiqueta = Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaNo;

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIndicadorCheck = function (data, type, full) {
    var etiqueta = '';

    if (data === true)
        etiqueta = '<span class="control-table"><i class="fa fa-check-square" style="font-size: 16px"></i></span>';
        //etiqueta = '<span class="control-table"><i class="fa fa-check-circle-o" style="font-size: 16px"></i></span>';
    else if (data === false)
        etiqueta = '<span class="control-table"><i class="fa fa-square-o" style="font-size: 16px"></i></span>';
    //etiqueta = '<span class="control-table"><i class="fa fa-circle-o" style="font-size: 16px"></i></span>';

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIcono = function (clase, icono, tooltip) {
    var etiqueta = '';

    if (tooltip)
        etiqueta = 'data-toggle="tooltip" data-placement="top" title="' + tooltip + '"'

    etiqueta = '<span class="control-table ' + clase + '" ' + etiqueta + '><i class="fa ' + icono + '"></i></span>';

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIconoAccion = function (editar, eliminar) {
    var etiqueta = '';

    editar = (editar !== false);
    eliminar = (eliminar !== false);

    if (editar)
        etiqueta += Pe.GMD.UI.Web.Components.Util.RenderIcono('edit', 'fa-edit', Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaEditar);

    if (eliminar)
        etiqueta += Pe.GMD.UI.Web.Components.Util.RenderIcono('delete', 'fa-trash', Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaEliminar);

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.CargarLista = function (listaDesplegable, listaValores, campoCodigo, campoDescripcion) {
    Pe.GMD.UI.Web.Components.Util.CargarListaDesplegable(listaDesplegable, Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, listaValores, campoCodigo, campoDescripcion);
}

Pe.GMD.UI.Web.Components.Util.CargarListaFiltro = function (listaDesplegable, listaValores, campoCodigo, campoDescripcion) {
    Pe.GMD.UI.Web.Components.Util.CargarListaDesplegable(listaDesplegable, Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaTodos, listaValores, campoCodigo, campoDescripcion);
}

Pe.GMD.UI.Web.Components.Util.CargarListaDesplegable = function (listaDesplegable, primerItem, listaValores, campoCodigo, campoDescripcion) {
    if (!campoCodigo) campoCodigo = 'Codigo';
    if (!campoDescripcion) campoDescripcion = 'Valor';

    listaDesplegable.empty();

    if(primerItem)
        listaDesplegable.append(new Option(primerItem, ""));

    if (listaValores) {
        $.each(listaValores, function (index, value) {
            listaDesplegable.append(new Option(value[campoDescripcion], value[campoCodigo]));
        });
    }
}

Pe.GMD.UI.Web.Components.Util.ByteToImage = function (buffer, onLoad) {
    var mime;
    var a = new Uint8Array(buffer);
    var nb = a.length;
    if (nb < 4) {
        return null;
    }
    var b0 = a[0];
    var b1 = a[1];
    var b2 = a[2];
    var b3 = a[3];
    if (b0 == 0x89 && b1 == 0x50 && b2 == 0x4E && b3 == 0x47) {
        mime = 'image/png';
    }
    else if (b0 == 0xff && b1 == 0xd8) {
        mime = 'image/jpeg';
    }
    else if (b0 == 0x47 && b1 == 0x49 && b2 == 0x46) {
        mime = 'image/gif';
    }
    else {
        return null;
    }
    var binary = "";
    for (var i = 0; i < nb; i++) {
        binary += String.fromCharCode(a[i]);
    }
    var base64 = window.btoa(binary);
    var image = new Image();
    image.onload = onLoad;
    image.src = 'data:' + mime + ';base64,' + base64;
    return image;
}

Pe.GMD.UI.Web.Components.Util.RedirectPost = function (location, args) {
    var form = '';
    $.each(args, function (key, value) {
        form += '<input type="hidden" name="' + key + '" value="' + value + '">';
    });
    var submit = $('<form action="' + location + '" method="POST" target="_self">' + form + '</form>');
    $('body').after(submit);
    submit.submit();
}

Pe.GMD.UI.Web.Components.Util.Left = function (cadena, len) {
    if (len <= 0)
        return "";
    else if (len > String(cadena).length)
        return cadena;
    else
        return String(cadena).substring(0, len);   
}

Pe.GMD.UI.Web.Components.Util.Right = function (cadena, len) {
    if (len <= 0)
        return "";
    else if (len > String(cadena).length)
        return str;
    else {
        var iLen = String(cadena).length;
        return String(cadena).substring(iLen, iLen - len);
    }
}

String.prototype.format = String.prototype.formatoArreglo = function () {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    return s;
};

(function ($, undefined) {
    $.fn.getCursorPosition = function () {
        var el = $(this).get(0);
        var pos = 0;
        if ('selectionStart' in el) {
            pos = el.selectionStart;
        } else if ('selection' in document) {
            el.focus();
            var Sel = document.selection.createRange();
            var SelLength = document.selection.createRange().text.length;
            Sel.moveStart('character', -el.value.length);
            pos = Sel.text.length - SelLength;
        }
        return pos;
    }
})(jQuery);

//Giovanni Rivera C.
function getCursorTinyPosicion(editor) {
    //set a bookmark so we can return to the current position after we reset the content later
    var bm = editor.selection.getBookmark(0);
    //select the bookmark element
    var selector = "[data-mce-type=bookmark]";
    var bmElements = editor.dom.select(selector);
    //put the cursor in front of that element
    editor.selection.select(bmElements[0]);
    editor.selection.collapse();
    //add in my special span to get the index...
    //we won't be able to use the bookmark element for this because each browser will put id and class attributes in different orders.
    var elementID = "######cursor######";
    var positionString = '<span id="' + elementID + '"></span>';
    editor.selection.setContent(positionString);
    //get the content with the special span but without the bookmark meta tag
    var content = editor.getContent({ format: "html" });
    //find the index of the span we placed earlier
    var index = content.indexOf(positionString);
    //remove my special span from the content
    editor.dom.remove(elementID, false);
    //move back to the bookmark
    editor.selection.moveToBookmark(bm);
    return index;
};

Pe.GMD.UI.Web.Components.Util.ConvertToDecimal = function (value) {

    var format = Pe.GMD.UI.Web.Formato.Decimal;
    var number = value;

    format = format.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorDecimal, '@');
    format = format.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorMiles, ',');
    format = format.replace('@', '.');

    number = number.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorDecimal, '@');
    number = number.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorMiles, ',');
    number = number.replace('@', '.');

    number = $.parseNumber(number, { format: format });

    return parseFloat(number);
};

Pe.GMD.UI.Web.Components.Util.DecimalConvertToString = function (value) {

    var format = Pe.GMD.UI.Web.Formato.Decimal;
    var number = value.toString();

    format = format.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorDecimal, '@');
    format = format.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorMiles, ',');
    format = format.replace('@', '.');

    if (typeof decimal == 'string') {
        number = number.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorDecimal, '@');
        number = number.replace(Pe.GMD.UI.Web.Formato.DecimalSeparadorMiles, '');
        number = number.replace('@', '.');
    }

    number = $.formatNumber(number, { format: format });

    number = number.replace('.', '@');
    number = number.replace(',', Pe.GMD.UI.Web.Formato.DecimalSeparadorMiles);
    number = number.replace('@', Pe.GMD.UI.Web.Formato.DecimalSeparadorDecimal);

    return number;

};

Pe.GMD.UI.Web.Components.Util.ValidateDateRange = function (txtStart, txtEnd) {

    var isValid = true;

    var valueStart = txtStart.is('input') ? txtStart.val() : txtStart.html();
    var valueEnd = txtEnd.is('input') ? txtEnd.val() : txtEnd.html();

    if (valueStart != '' && valueEnd != '') {
        var dateStart = $.datepicker.parseDate(Pe.GMD.UI.Web.Formato.Fecha, valueStart);
        var dateEnd = $.datepicker.parseDate(Pe.GMD.UI.Web.Formato.Fecha, valueEnd);
        isValid = (dateStart <= dateEnd);
    }
    return isValid;
}