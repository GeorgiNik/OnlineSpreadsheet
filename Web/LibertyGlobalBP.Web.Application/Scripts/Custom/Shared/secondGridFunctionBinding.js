$(function () {
    var grid = $('#gridSecond').data("kendoGrid");
    if (grid) {
        grid.bind('edit', activateRowSecond)
        grid.bind('save', hideErrorAlertSecond)
        grid.bind('cancel', hideErrorAlertSecond)
        grid.bind('cancel', cancelSecond)
        grid.bind('dataBound', dataBoundSecond)
        grid.dataSource.bind('requestEnd', requestEndSecond)
        grid.dataSource.bind('error', errorAlertSecond)
    }

    $('#gridSecond thead tr *').on('click', function () {
        if ($('.k-grid-edit-row').length) {
            return false;
        }
    });

    $('.k-grid-add').on('click', function () {
        if ($('.k-header.k-grid-filter.k-state-active').length ||
            $('.k-header[aria-sort]').length ||
            $('.k-grid-edit-row').length) {
            return false;
        }
        else {
            var dataSource = $('#gridSecond').data("kendoGrid").dataSource;
            if (dataSource.data().length) {
                dataSource.sort({});
                dataSource.filter({});
                var page = $('#gridSecond .k-pager-last').attr('data-page');
                dataSource.page(page);
            }
        }
    });
});
