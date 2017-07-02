function confirmDeleteThird(e) {
    var popup = $("#window").kendoWindow({
        title: "Delete",
        visible: false, // the window will not appear before its .open method is called
        width: "500px",
    }).data("kendoWindow");

    var windowTemplate = kendo.template($("#windowTemplateThird").html());

    var tr = $(e.target).closest("tr"); // get the row for deletion
    var data = this.dataItem(tr); // get the row data so it can be referred later
    popup.content(windowTemplate(data)); // send the row data object to the template and render it
    popup.open().center();

    $("body").on('click', '#btnDeleteThird', function () {
        var grid = $('#gridThird').data("kendoGrid");
        grid.dataSource.remove(data); // prepare a "destroy" request
        grid.dataSource.sync(); // actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
        popup.close();
    });

    $("body").on('click', '#btnCancelThird', function () {
        popup.close();
    });
}

function rowNumbersThird() {
    var grid = $("#gridThird").data("kendoGrid");
    var page = grid.dataSource.page();
    var pageSize = grid.dataSource.pageSize();
    var counter = (page * pageSize) + 1 - pageSize;
    $('.row-numbers-third').each(function () {
        $(this).html(counter);
        counter += 1;
    });
}

function errorAlertThird(args) {
    if (args.errors) {
        var grid = $("#gridThird").data("kendoGrid");
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

function requestEndThird(e) {
    if (e.response && e.response.Errors) {
        if (e.type == "destroy") {
            cancelThird();
        }
    }
}

function hideErrorAlertThird(e) {
    $('#validation-result').empty();
    $('.validation').empty().addClass('hide');
    rowNumbersThird();
}

function activateRowThird(e) {
    $(e.container).closest("tr").addClass('active');
}

function cancelThird() {
    var grid = $('#gridThird').data('kendoGrid');
    grid.cancelChanges();
    grid.refresh();
}

function showStatusThird(EntityStatus) {
    // defined in the layout
    if (EntityStatus == entityStatusInactive) {
        return "<i class='fa fa-circle inactive-state'></i>"
    }
    else {
        return "<i class='fa fa-circle active-state'></i>"
    }
}

function dataBoundThird() {
    rowNumbersThird();

    var grid = $("#gridThird").data("kendoGrid");
    var gridData = grid.dataSource.view();

    for (var i = 0; i < gridData.length; i++) {
        var item = gridData[i];

        if (item.EntityStatus == entityStatusInactive) {
            $(grid.table.find("tr[data-uid='" + item.uid + "']")).find(".k-grid-Delete").remove();
        }
    }
}
