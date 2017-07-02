$(function () {
    var grid = $("#grid").data("kendoGrid");

    grid.bind("dataBound", onDataBound);

    grid.table.on("click", ".checkbox", function () {
        var multipleDeleteBtn = $('.k-grid-delete-selection');

        var row = $(this).closest("tr");
        var item = grid.dataItem(row);

        if (this.checked) {
            checkedItems.push(item);
            row.addClass("k-state-selected");
        } else {
            checkedItems.splice(checkedItems.indexOf(item), 1);
            row.removeClass("k-state-selected");
        }

        if (checkedItems.length) {
            multipleDeleteBtn.removeClass('hide');
        } else {
            multipleDeleteBtn.addClass('hide');
        }
    });

    $('.k-grid-delete-selection').on("click", function (e) {
        e.preventDefault();

        if (checkedItems) {
            var popup = $("#window").kendoWindow({
                title: "Delete",
                visible: false,
                width: "500px",
            }).data("kendoWindow");

            var windowTemplate = kendo.template($("#multipleDelete").html());
            popup.content(windowTemplate);
            popup.open().center();

            $('body').on('click', "#multipleDeleteBtn", function () {
                $.each(checkedItems, function (i, item) {
                    grid.dataSource.remove(item); // prepare a "destroy" request
                    grid.dataSource.sync(); // actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
                    grid.removeRow(item);
                });
                popup.close();
                $('.k-grid-delete-selection').addClass('hide');
            });

            $("#multipleCancelBtn").click(function () {
                popup.close();
            });
        }
    });
});
