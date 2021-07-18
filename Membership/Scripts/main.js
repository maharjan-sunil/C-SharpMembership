//show or hide credentials logic
$('#ShowHide, #ShowHide_1').on("click", function () {
    var value = $(this).closest("form > div").find("input[type = 'password'], input[type = 'text']");
    ToggleIcon(this);
    ShowHide(value);
})

function ShowHide(value) {
    if (value.hasClass("showCredentials")) {
        value.addClass("hideCredentials").removeClass("showCredentials");
        value.attr("type", "text");
    }
    else {
        value.attr("type", "password");
        value.addClass("showCredentials").removeClass("hideCredentials");
    }
}

function ToggleIcon(input) {
    if ($(input).hasClass("fa fa-eye")) {
        $(input).removeClass("fa fa-eye").addClass("fa fa-eye-slash");
    }
    else {
        $(input).removeClass("fa fa-eye-slash").addClass("fa fa-eye");
    }

}

function GoToPage(page, pageSize) {
    $('#currentPage').val(page);
    $('#recordPerPage').val(pageSize);
    $('#pagingForm').submit();
}