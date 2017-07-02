$(function () {
    var grid = $("#gridSecond").data("kendoGrid");

    grid.bind("dataBound", onDataBoundSecond);

    grid.table.on("click", ".checkbox-second", function () {
        var multipleDeleteBtn = $('.k-grid-delete-selection-second');

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

    $('.k-grid-delete-selection-second').on("click", function (e) {
        e.preventDefault();

        if (checkedItems) {
            var popup = $("#window").kendoWindow({
                title: "Delete",
                visible: false,
                width: "500px",
            }).data("kendoWindow");

            var windowTemplate = kendo.template($("#multipleDeleteSecond").html());
            popup.content(windowTemplate);
            popup.open().center();

            $("#multipleDeleteBtnSecond").click(function () {
                $.each(checkedItems, function (i, item) {
                    grid.dataSource.remove(item); // prepare a "destroy" request
                    grid.dataSource.sync(); // actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
                    grid.removeRow(item);
                });
                popup.close();
                $('.k-grid-delete-selection-second').addClass('hide');
            });

            $("#multipleCancelBtnSecond").click(function () {
                popup.close();
            });
        }
    });
});

$('#modal-container').on('shown.bs.modal hidden.bs.modal', function () {
    $(".checkbox:checked").attr("checked", false);
    $('#grid tr.k-state-selected').removeClass('k-state-selected');
    checkedItems = [];
});
