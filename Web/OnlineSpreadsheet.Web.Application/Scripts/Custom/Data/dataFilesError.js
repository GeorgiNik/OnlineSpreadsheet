function fileUploadFail(e) {
    var error = e.XMLHttpRequest.responseText;

    $('#validation-sum').html(error).fadeIn();

    setTimeout(function () {
        $('#validation-sum').fadeOut().html('');
    }, 5000);
}