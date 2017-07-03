$(function () {
    var grid = $("#grid").data("kendoGrid");
    var dataSource = grid.dataSource;
    grid.one("dataBound", function () {
        if (dataSource.data().length) {
            dataSource.filter({
                field: 'EntityStatus',
                value: entityStatusActive,
                operator: 'eq'
            });
        }
    });

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
                        field: "Title",
                        operator: "contains",
                        value: val
                    },
                    {
                        field: "UserRoleName",
                        operator: "contains",
                        value: val
                    },
                    {
                        field: "Email",
                        operator: "contains",
                        value: val
                    },
                    {
                        field: "Phone",
                        operator: "contains",
                        value: val
                    },
                    {
                        field: "EntityStatusName",
                        operator: "contains",
                        value: val
                    },
                ]
            });
        }
    });
});
