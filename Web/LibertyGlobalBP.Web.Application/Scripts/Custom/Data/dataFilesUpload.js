function onUpload(e) {
    var id = $("#FolderID").val();

    e.data = { folderId: id };
}