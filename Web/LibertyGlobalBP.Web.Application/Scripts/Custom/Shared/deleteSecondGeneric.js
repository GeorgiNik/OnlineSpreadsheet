function confirmDeleteSecond(e) {
    var popup = $("#window").kendoWindow({
        title: "Delete",
        visible: false, // the window will not appear before its .open method is called
        width: "500px",
    }).data("kendoWindow");

    var windowTemplate = kendo.template($("#windowTemplateGeneric").html());

    var tr = $(e.target).closest("tr"); // get the row for deletion
    var data = this.dataItem(tr); // get the row data so it can be referred later
    popup.content(windowTemplate(data)); // send the row data object to the template and render it
    popup.open().center();

    $("body").on('click', '#btnDeleteGeneric', function () {
        var grid = $('#gridSecond').data("kendoGrid");
        grid.dataSource.remove(data); // prepare a "destroy" request
        grid.dataSource.sync(); // actually send the request (might be ommited if the autoSync option is enabled in the dataSource)
        popup.close();
    });

    $("body").on('click', '#btnCancelGeneric', function () {
        popup.close();
    });
}
