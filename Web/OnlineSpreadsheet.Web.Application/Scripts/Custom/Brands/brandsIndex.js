$(function () {
    $("#searchbox").keyup(function () {
        var val = $('#searchbox').val();
        if (val == '') {
            $("#grid").data("kendoGrid").dataSource.filter({})
        }
        else {
            $("#grid").data("kendoGrid").dataSource.filter({
                logic: "or",
                filters: [
                    {
                        field: "Name",
                        operator: "contains",
                        value: val
                    },
                   {
                        field: "CountryName",
                        operator: "contains",
                        value: val
                    },
                    {
                        field: "Email",
                        operator: "contains",
                        value: val
                    },
                ]
            });
        }
    });

    $('th[data-title="Logo"] span').addClass('text-center no-margin no-padding');
});

function printCountries(name, image) {
    var icon = '';

    if (image) {
        icon = '<img src="' + image + '" class="img-responsive img-small inline grid-flag">'
    }

    return icon + name;
}

function success(e) {
    var imagePath = e.response.ImageUrl;
    $("#Logo").val(imagePath).change();
    $('.popup-brand-logo').attr('src', imagePath);
    $("#UpdateImage").val(true).change();
}
