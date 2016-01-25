/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// LibrerÍa para la creación de Editores
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EJHF) 20150527 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.TinyMCE');
Pe.GMD.UI.Web.Components.TinyMCE = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.TinyMCE.prototype = {
    selectorAreaTexto: null,
    editor: null,

    init: function (opts) {
        var config = {
            height: opts.height ? opts.height : 150,
            extraPlugins: 'quicktable,lineheight,texttransform,pastebase64,tableresize',
            removePlugins: 'a11yhelp, about, elementspath, div, iframe, image, flash, forms, language, link, magicline, newpage, save, showblocks, smiley, sourcearea, templates',
            //'basicstyles, bidi, blockquote, clipboard, colorbutton, colordialog, contextmenu, dialogadvtab, enterkey, entities, filebrowser, find, floatingspace, font, format, horizontalrule, htmlwriter, indentblock, indentlist, justify, maximize, list, liststyle, pagebreak, pastefromword, pastetext, preview, print, removeformat, resize, scayt, selectall, showborders, specialchar, stylescombo, tab, table, tabletools, toolbar, undo, wsc, wysiwygarea'
            qtBorder: '0', // Border of inserted table
            qtWidth: '100%', // Width of inserted table
            qtStyle: { 'border-collapse': 'collapse' },
            qtCellPadding: '5', // Cell padding table
            qtCellSpacing: '1' // Cell spacing table
        };

        editor = opts.input.ckeditor(config).editor;
        selectorAreaTexto = opts.input;
    },

    insertText: function (text) {
        editor.insertText(text);
    },

    getData: function () {
        return editor.getData();
    }
}