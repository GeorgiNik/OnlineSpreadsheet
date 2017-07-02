$(function () {
    var grid = $('#gridThird').data("kendoGrid");
    if (grid) {
        grid.bind('edit', activateRowThird)
        grid.bind('save', hideErrorAlertThird)
        grid.bind('cancel', hideErrorAlertThird)
        grid.bind('cancel', cancelThird)
        grid.bind('dataBound', dataBoundThird)
        grid.dataSource.bind('requestEnd', requestEndThird)
        grid.dataSource.bind('error', errorAlertThird)
    }

    $('#gridThird thead tr *').on('click', function () {
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
            var dataSource = $('#gridThird').data("kendoGrid").dataSource;
            if (dataSource.data().length) {
                dataSource.sort({});
                dataSource.filter({});
                var page = $('#gridThird .k-pager-last').attr('data-page');
                dataSource.page(page);
            }
        }
    });
});
