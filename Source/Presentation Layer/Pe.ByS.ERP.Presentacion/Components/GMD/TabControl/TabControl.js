// Copyright (c) 2015.
// All rights reserved.
/// <summary>
/// Controlador de Tab Control
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EJHF) 20150715 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.TabControl');
Pe.GMD.UI.Web.Components.TabControl = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.TabControl.prototype = {
    target: null,
    isCollapsible: null,
    isSortable: null,

    init: function (opts) {
        this.target = opts.target != null ? opts.target : null;
        this.isCollapsible = opts.isCollapsible != null ? opts.isCollapsible : false;
        this.isSortable = opts.isSortable != null ? opts.isSortable : false;
        this.target.tabs({
            collapsible: this.isCollapsible
        });

        if (this.isSortable == true) {
            opts.target.find(".ui-tabs-nav").sortable({
                axis: "x",
                stop: function () {
                    opts.target.tabs("refresh");
                }
            })
        };
    }
};