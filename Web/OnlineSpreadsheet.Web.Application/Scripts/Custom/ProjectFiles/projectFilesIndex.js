function onSuccess(e) {
    $("#grid_" + e).data('kendoGrid').dataSource.read();
}
$(function () {
    
    $('#searchbox').keyup(function () {
        var grid = $("#grid").data("kendoGrid");
        var val = $('#searchbox').val();
        if (val == '') {
            grid.dataSource.filter({});
        }
        else {
            grid.dataSource.filter({
                logic: 'or',
                filters: [
                    {
                        field: 'Name',
                        operator: 'contains',
                        value: val
                    }
                ]
            });
        }
    });

    $('#modal-container').on('hidden.bs.modal', function () {
        var grid = $('#grid').data("kendoGrid");
        if (grid) {
            grid.dataSource.read();
        }
    });
});

