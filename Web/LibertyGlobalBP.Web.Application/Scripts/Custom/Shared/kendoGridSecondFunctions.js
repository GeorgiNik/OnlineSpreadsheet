function confirmDeleteSecond(e) {
    var popup = $("#window").kendoWindow({
        title: "Delete",
        visible: false, // the window will not appear before its .open method is called
        width: "500px",
    }).data("kendoWindow");

    var windowTemplate = kendo.template($("#windowTemplateSecond").html());

    var tr = $(e.target).closest("tr"); // get the row for deletion
    var data = this.dataItem(tr); // get the row data so it can be referred later
    popup.content(windowTemplate(data)); // send the row data object to the template and render it
    popup.open().center();

    $("body").on('click', '#btnDeleteSecond', function () {
        var grid = $('#gridSecond').data("kendoGrid");
        grid.dataSource.remove(data); // prepare a "destroy" request
        grid.dataSource.sync(); // actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
        popup.close();
    });

    $("body").on('click', '#btnCancelSecond', function () {
        popup.close();
    });
}

function rowNumbersSecond() {
    var grid = $("#gridSecond").data("kendoGrid");
    var page = grid.dataSource.page();
    var pageSize = grid.dataSource.pageSize();
    var counter = (page * pageSize) + 1 - pageSize;
    $('.row-numbers-second').each(function () {
        $(this).html(counter);
        counter += 1;
    });
}

function errorAlertSecond(args) {
    if (args.errors) {
        var grid = $("#gridSecond").data("kendoGrid");
        grid.one("dataBinding", function (e) {
            e.preventDefault();
            var validation = $('.validation');
            validation.empty().removeClass('hide');
            for (var error in args.errors) {
                validation.append(args.errors[error].errors + "<br />")
            }
        });
    }
}

function requestEndSecond(e) {
    if (e.response && e.response.Errors) {
        if (e.type == "destroy") {
            cancelSecond();
        }
    }
}

function hideErrorAlertSecond(e) {
    $('#validation-result').empty();
    $('.validation').empty().addClass('hide');
    rowNumbersSecond();
}

function activateRowSecond(e) {
    $(e.container).closest("tr").addClass('active');
}

function cancelSecond() {
    var grid = $("#gridSecond").data("kendoGrid");
    grid.cancelChanges();
    grid.refresh();
}

function showStatusSecond(EntityStatus) {
    // defined in the layout
    if (EntityStatus == entityStatusInactive) {
        return "<i class='fa fa-circle inactive-state'></i>"
    }
    else {
        return "<i class='fa fa-circle active-state'></i>"
    }
}

function dataBoundSecond() {
    rowNumbersSecond();

    var grid = $("#gridSecond").data("kendoGrid");
    var gridData = grid.dataSource.view();

    for (var i = 0; i < gridData.length; i++) {
        var item = gridData[i];

        if (item.EntityStatus == entityStatusInactive) {
            $(grid.table.find("tr[data-uid='" + item.uid + "']")).find(".k-grid-Delete").remove();
        }
    }
}
