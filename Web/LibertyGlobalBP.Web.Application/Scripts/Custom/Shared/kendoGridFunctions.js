function confirmDelete(e) {
    var popup = $("#window").kendoWindow({
        title: "Delete",
        visible: false, // the window will not appear before its .open method is called
        width: "500px",
    }).data("kendoWindow");

    var windowTemplate = kendo.template($("#windowTemplate").html());

    var tr = $(e.target).closest("tr"); // get the row for deletion
    var data = this.dataItem(tr); // get the row data so it can be referred later
    popup.content(windowTemplate(data)); // send the row data object to the template and render it
    popup.open().center();

    $("body").on('click', '#btnDelete', function () {
        var grid = $('#grid').data("kendoGrid");
        grid.dataSource.remove(data); // prepare a "destroy" request
        grid.dataSource.sync(); // actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
        popup.close();
    });

    $("body").on('click', '#btnCancel', function () {
        popup.close();
    });
}

function rowNumbers() {
    var grid = $("#grid").data("kendoGrid");
    var page = grid.dataSource.page();
    var pageSize = grid.dataSource.pageSize();
    var counter = 1;
    if (page && pageSize) {
        counter += (page - 1) * pageSize;
    }
    $('.row-numbers').each(function () {
        $(this).html(counter);
        counter += 1;
    });
}

function errorAlert(args) {
    var validation = $('.validation');
    if (args.errors) {
        var grid = $("#grid").data("kendoGrid");
        grid.one("dataBinding", function (e) {
            e.preventDefault();
            validation.empty();
            validation.removeClass('hide');

            for (var error in args.errors) {
                validation.append(args.errors[error].errors + "<br />")
            }
        });
    }
}

function requestEnd(e) {
    if (e.response && e.response.Errors) {
        if (e.type == "destroy") {
            cancel();
        }
    }
}

function hideErrorAlert(e) {
    var validation = $('.validation');
    validation.empty();
    validation.addClass('hide');
    rowNumbers();
}

function activateRow(e) {
    $(e.container).closest("tr").addClass('active');
}

function cancel() {
    var grid = $('#grid').data('kendoGrid');
    grid.cancelChanges();
    grid.refresh();
}

function showStatus(EntityStatus) {
    // defined in the layout
    if (EntityStatus == entityStatusInactive) {
        return "<i class='fa fa-circle inactive-state'></i>"
    }
    else {
        return "<i class='fa fa-circle active-state'></i>"
    }
}

function dataBound() {
    rowNumbers();

    var grid = $("#grid").data("kendoGrid");
    var gridData = grid.dataSource.view();

    for (var i = 0; i < gridData.length; i++) {
        var item = gridData[i];

        if (item.EntityStatus == entityStatusInactive) {
            $(grid.table.find("tr[data-uid='" + item.uid + "']")).find(".k-grid-Delete").remove();
        }
    }
}
