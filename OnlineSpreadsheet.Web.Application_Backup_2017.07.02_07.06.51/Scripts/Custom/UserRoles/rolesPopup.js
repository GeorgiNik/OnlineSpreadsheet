$(function () {
    $('.read-checkbox:not(.sub-configuration)').change(function () {
        var value = $(this).prop('checked');

        if (!value) {
            $('input[name=' + $('input[data-checkbox-target=' + $(this).attr('id') + ']').attr('name') + ']').each(function () {
                $(this).prop('checked', value).val(value).change();
            });
        }
    });

    $('.edit-checkbox:not(.sub-configuration)').change(function () {
        var value = $(this).prop('checked');

        if (value) {
            $('input[name=' + $("#" + $(this).data('checkbox-target')).attr('name') + ']').each(function () {
                $(this).prop('checked', value).val(value).change();
            });
        }
    });

    $('.read-checkbox[name=ConfigurationRead]').change(function () {
        var value = $(this).prop('checked');

        if ((!value && $('.read-checkbox.sub-configuration:not(:checked)').length == 0) || (value && $('.read-checkbox.sub-configuration:not(:checked)').length > 0)) {
            $.each($('.read-checkbox.sub-configuration'), function () {
                $(this).prop('checked', value).val(value).change();
            });
        }
    });

    $('.edit-checkbox[name=ConfigurationEdit]').change(function () {
        var value = $(this).prop('checked');

        if ((!value && $('.edit-checkbox.sub-configuration:not(:checked)').length == 0) || (value && $('.edit-checkbox.sub-configuration:not(:checked)').length > 0)) {
            $.each($('.edit-checkbox.sub-configuration'), function () {
                $(this).prop('checked', value).val(value).change();
            });
        }
    });

    $('.read-checkbox.sub-configuration').change(function () {
        var value = $(this).prop('checked');

        var tasklistRead = $('.read-checkbox[name=ConfigurationRead]');

        //if ((tasklistRead.prop('checked') && !value) || (!tasklistRead.prop('checked') && value && $('.read-checkbox.sub-configuration:not(:checked)').length == 0)) {
        //    tasklistRead.prop('checked', value).val(value).change();
        //}

        if (!value) {
            $('input[name=' + $('input[data-checkbox-target=' + $(this).attr('id') + ']').attr('name') + ']').each(function () {
                $(this).prop('checked', value).val(value).change();
            });
        }
    });

    $('.edit-checkbox.sub-configuration').change(function () {
        var value = $(this).prop('checked');

        var tasklistEdit = $('.edit-checkbox[name=ConfigurationEdit]');

        //if ((tasklistEdit.prop('checked') && !value) || (!tasklistEdit.prop('checked') && value && $('.edit-checkbox.sub-configuration:not(:checked)').length == 0)) {
        //    tasklistEdit.prop('checked', value).val(value).change();
        //}

        if (value) {
            $('input[name=' + $("#" + $(this).data('checkbox-target')).attr('name') + ']').each(function () {
                $(this).prop('checked', value).val(value).change();
            });
        }
    });
});
