$(function () {
    var pathname = window.location.pathname.toString();
    var url = pathname.toLowerCase().split('/')[1];
    var actionUrl = pathname.toLowerCase().split('/')[2];

    var admin = ['users', 'customers', 'data', 'keywords', 'admin'];
    var projectFiles = ['projectfiles'];
    var countryScorecard = ['countryscorecard'];
    var home = ['home'];
    
    if (projectFiles.indexOf(url) >= 0) {
        $("#content").css("padding-top", "60px");
        $('#project-files').addClass('active-drop');
        $("#wrapper").removeClass('background-image');
    }
    else if (countryScorecard.indexOf(url) >= 0) {
        $("#content").css("padding-top", "60px");
        $('#country-scorecard').addClass('active-drop');
        $("#wrapper").removeClass('background-image');
    }
    else if (admin.indexOf(url) >= 0 || admin.indexOf(actionUrl)>=0) {
        $('#admin-submenu').show();
        $('#admin').addClass('active-drop');
        $("#wrapper").removeClass('background-image');
    } else {
        $("#content").css("padding-top", "70px");
        $("#wrapper").addClass('background-image');
    }

    $('.submenu a').each(function () {
        var href = $(this).attr('href');
        if (href.toLowerCase().indexOf(url) >= 0) {
            $(this).addClass('active');
        }
    });
});