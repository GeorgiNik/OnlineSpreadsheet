function controlDefaultBrand() {
    var isDefaultBrand = $('#IsDefaultBrand');
    if (!$('#CountryID').data('kendoDropDownList').value()) {
        isDefaultBrand.closest('.form-group').removeClass('hide');
        isDefaultBrand.attr('disabled', false);
    } else {
        isDefaultBrand.closest('.form-group').addClass('hide');
        isDefaultBrand.attr('disabled', true);
    }
}

$(function () {
  
    $('#CountryID').on('change', function () {
        controlDefaultBrand();
    });

    controlDefaultBrand();
});
