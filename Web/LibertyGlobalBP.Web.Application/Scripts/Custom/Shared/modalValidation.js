var form = $('#generic-form');
var validator = $('#generic-form').kendoValidator().data("kendoValidator");

form.submit(function () {
    if (validator.validate()) {
        var btn = $('#btn-save, #btn-save-second');
        btn.prop('disabled', true);
        btn.css('opacity', 0.4);

        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            error: function (result) {
                $('#validation-result').html(result.responseText);

                btn.prop('disabled', false);
                btn.css('opacity', 1);
            },
            success: function (result) {
                $('#modal-container').empty();
                $('#modal-container').modal('hide');
            }
        });
    }

    return false;
});
