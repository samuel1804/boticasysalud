// Copyright (c) 2015.
// All rights reserved.
/// <summary>
/// Componente Token Field
/// </summary>
/// <remarks>
/// Creacion: 	GMD(GRC) 20150422 
/// </remarks>
ns('Pe.GMD.UI.Web.Components.TokenField');
Pe.GMD.UI.Web.Components.TokenField = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.TokenField.prototype = {
    target: null,
    data: null,
    //value: null,
    prePopulate: null,
    queryParam: null,
    theme: null,
    searchingText: null,
    hintText: null,
    noResultsText: null,
    minChars: null,
    preventDuplicates: null,
    searchDelay: null,
    resultsLimit: null,
    delimiter: null,
    propertyToSearch: null,
    tokenValue: null,
    init: function (opts) {
        this.target = opts.target ? opts.target : null;

        if (opts) {
            this.data = opts.data ? opts.data : [];
            //this.value = opts.value ? opts.value : {};
            this.theme = opts.theme != null ? opts.theme : 'facebook';
            this.searchingText = opts.searchingText != null ? opts.searchingText : 'Searching...';
            this.hintText = opts.hintText != null ? opts.hintText : 'Type in a search term';
            this.noResultsText = opts.noResultsText != null ? opts.noResultsText : 'No results';
            this.minChars = opts.minChars != null ? opts.minChars : 3;
            this.queryParam = opts.queryParam != null ? opts.queryParam : "q";
            this.searchDelay = opts.searchDelay != null ? opts.searchDelay : 300;            
            //this.preventDuplicates = opts.preventDuplicates == false ? opts.preventDuplicates : true;
            this.preventDuplicates = opts.preventDuplicates == false ? true : false;
            this.resultsLimit = opts.resultsLimit != null ? opts.resultsLimit : 1;
            this.delimiter = opts.delimiter != null ? opts.delimiter : ",";
            this.propertyToSearch = opts.propertyToSearch != null ? opts.propertyToSearch : "name";
            this.tokenValue = opts.tokenValue != null ? opts.tokenValue : "id";
            this.prePopulate = opts.prePopulate ? opts.prePopulate : [];
        }
        this.load();
    },
    load: function () {
        this.target.tokenInput(this.data, {
            hintText: this.hintText,
            noResultsText: this.noResultsText,
            searchingText: this.searchingText,
            minChars: this.minChars,
            queryParam: this.queryParam,
            searchDelay: this.searchDelay,            
            theme: this.theme,
            tokenLimit: this.resultsLimit,
            tokenDelimiter: this.delimiter,
            propertyToSearch: this.propertyToSearch,
            preventDuplicates: this.preventDuplicates,
            tokenValue: this.tokenValue,
            prePopulate: this.prePopulate
        });
    },
    setData: function (data) {
        //this.target.tokenInput("add", data);
        this.data = data;
    },
    removeByID: function (data) {
        this.target.tokenInput("remove", data);
    },
    removeByName: function (data) {
        this.target.tokenInput("remove", data);
    },
    getValue: function () {
        this.target.tokenInput("get");
    },
    clearData: function () {
        this.target.tokenInput("clear");
    }
}


