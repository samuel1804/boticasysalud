// Copyright (c) 2015.
// All rights reserved.
/// <summary>
/// Componente Token Field
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EMP) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.TokenInput');
Pe.GMD.UI.Web.Components.TokenInput = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.TokenInput.prototype = {
    target: null,
    init: function (opts) {
        this.target = opts.target ? opts.target : null;

        this.target.TokenInput({
            assa: this.asas,

        });

    }

}


