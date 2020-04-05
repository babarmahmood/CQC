$(document).ready(function () {

    $('#lnkBack').click(function () {
        HandleButtonClick(false);
        return false;
    });

    $('#btnNext').click(function () {
        HandleButtonClick(true);
        return false;
    });
    $(document).on("click", "a.govuk-link-summary", function () {
        HandleEditButtonClick($(this).attr('Id'));
        return false;
    });
    $(document).on("click", "#SubmitFeedback", function () {
        SaveFeedBack();
        return false;
    });

});

function HandleEditButtonClick(viewId) {


    var data = { "viewId": viewId };
    var url = "/Home/GetViewById";
    DisplayNextScreen(url, data);
}

function HandleButtonClick(isNextButtonClicked) {


    var data = PopulateData(isNextButtonClicked);
    var url = "/Home/GetNextQuestion";
    DisplayNextScreen(url, data);
}

function SaveFeedBack() {
    var data = null;
    var url = "/Home/SaveData";
    DisplayNextScreen(url, data);
}

function DisplayNextScreen(url, data) {

    $.ajax({
        url: url,
        type: "Post",
        dataType: "html",
        data: data,
        cache: false,
        async: false,
        success: function (result) {
            $('#divStep').html(result);
            ShowNextAndBackButtons();
        },
        failure: function (response) {
            console.log(response);
        }

    });
    return false;
}


function PopulateData(isNextButtonClicked) {
    var LightingSurveyVm = {
        "FullNameVm": {
            "FullName": $('#txtFullName').val()
        },
        "EmailVm": {
            "EmailAddress": $('#txtEmail').val()
        },
        "HomeAddress": {
            "BuildindAndStreet": $('#txtBuildingAndStreet').val(),
            "TownOrCity": $('#txtTwonOrCity').val(),
            "County": $('#txtCounty').val(),
            "PostCode": $('#txtPostCode').val()
        },
        "IsHappy": $("input[name='IsHappy']:checked").val(),
        "LevelOfBrightness": $('#listBrightness').val(),
        "IsNextButtonClicked": isNextButtonClicked
    };

    return LightingSurveyVm;
}

function ShowNextAndBackButtons() {

    if ($("#HideBackButton").val()) {
        $(".backLinkContainer").css("display", "none");
    }
    else {
        $(".backLinkContainer").css("display", "block");
    }

    if ($("#HideNextButton").val()) {
        $("#nextButtonContainer").css("display", "none");
    }
    else {
        $("#nextButtonContainer").css("display", "block");
    }
}

