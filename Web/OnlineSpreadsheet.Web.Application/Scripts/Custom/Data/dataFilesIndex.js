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
                        field: "FileName",
                        operator: "contains",
                        value: val
                    },
                    {
                        field: "CreatedBy",
                        operator: "contains",
                        value: val
                    }
                ]
            });
        }
    });
});