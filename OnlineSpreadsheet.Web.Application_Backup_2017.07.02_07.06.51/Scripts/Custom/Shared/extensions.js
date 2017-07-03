if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : match
            ;
        });
    };
}

if (!String.prototype.replaceAll) {
    String.prototype.replaceAll = function (search, replacement) {
        var target = this;
        return target.replace(new RegExp(escapeRegExp(search), 'g'), replacement);
    };
}

String.prototype.escapeJquery = function () {
    return "#" + this.replace(/(:|\.|\[|\]|,)/g, "\\$1");
}

function escapeRegExp(str) {
    return str.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
}
