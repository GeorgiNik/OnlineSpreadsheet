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
                        field: "EntityStatusName",
                        operator: "contains",
                        value: val
                    },
                ]
            });
        }
    });
});

function showTouchpointsCount(customerID, touchpointsCount) {
    return '<a data-ajax="true" data-ajax-mode="replace" data-ajax-update="\#modal-container" class="k-button modal-link" href="/Touchpoints/Index?customerID=' + customerID + '"><i class="fa fa-lg fa-users"></i> ' + touchpointsCount + '</a>';
}
