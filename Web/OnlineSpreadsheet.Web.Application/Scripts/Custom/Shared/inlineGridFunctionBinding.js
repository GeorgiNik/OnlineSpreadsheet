$(function () {
    var grid = $('#grid').data("kendoGrid");

    if (grid) {
        grid.bind('edit', activateRow)
        grid.bind('save', hideErrorAlert)
        grid.bind('cancel', hideErrorAlert)
        grid.bind('cancel', cancel)
        grid.bind('dataBound', dataBound)
        grid.dataSource.bind('requestEnd', requestEnd)
        grid.dataSource.bind('error', errorAlert)

        $('#grid thead tr *').on('click', function () {
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
                var dataSource = $('#grid').data("kendoGrid").dataSource;
                if (dataSource.data().length) {
                    dataSource.sort({});
                    dataSource.filter({});
                    var page = $('#grid .k-pager-last').attr('data-page');
                    dataSource.page(page);
                }
            }
        });
    }
});
