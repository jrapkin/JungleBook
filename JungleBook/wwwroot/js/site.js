// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Create properties for view model

//(function ($) {
//    function processForm(e) {
//        var dataFromForm = {
//            Location: $('#Location').val(),
//            Keyword: $('#Keyword').val(),
//        };

//        $.ajax({
//            url: 'TravelersController/SelectInterests',
//            dataType: 'json',
//            type: 'post',
//            contentType: 'application/json',
//            data: JSON.stringify(dataFromForm),
//            success: function (data, textStatus, jQxhr) {
//                $('#response pre').html(data);
//            },
//            error: function (jqXhr, textStatus, errorThrown) {
//                console.log(errorThrown);
//            }
//        });
//        e.preventDefault();
//    }
//    $('#my-form').submit(processForm);
//});
//document.getElementById("searchButton").addEventListener("click", function ($)
//{
//    $('#searchButton').('click', function (e)
//    {
//            e.preventDefault();
//            var dataFromForm = $('#testFormData').serialize;

//            $.ajax({
//                url: '/TravelersController/ShowEvents',
//                type: 'POST',
//                data: JSON.stringify(dataFromForm),
//                success: function (data, textStatus, jQxhr) {
//                    $('#SearchEvents').html(data),
//                    consol.log(success)
//                },
//                error: function (jqXhr, textStatus, errorThrown) {
//                    console.log(errorThrown);
//                }
//            });
//    });
//});

//Post to SearchEvents method
$(document).ready(function () {
    console.log("ready");
    $("#EventSearchForm").submit(function (e) {
        console.log("Events Search clicked");
        e.preventDefault();
        var modelFromForm = $('#EventSearchForm').serialize();

        $.ajax(
            {
                url: '/TravelersController/ShowEvents',
                type: 'POST',
                data: modelFromForm,
                success: function (data, textStatus, jQxhr) {
                    $('#EventsPartialView').html(data),
                        console.log("success");
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
    });
});

$(document).ready(function () {
    console.log("ready");
    $("#SearchByInterestsForm").submit(function (e) {
        console.log("Interests Search Clicked");
        e.preventDefault();
        var modelFromForm = $('#SearchByInterestsForm').serialize();

        $.ajax(
            {
                url: '/TravelersController/SelectInterests',
                type: 'POST',
                data: modelFromForm,
                success: function (data, textStatus, jQxhr) {
                    $('#SearchByInterestPartial').html(data),
                        console.log("success");
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
    });
});
//Post to send email invitations

$(document).ready(function () {
    console.log("ready");
    $("#EmailInvitationForm").submit(function (e) {
        console.log("clicked");
        e.preventDefault();
        var modelFromForm = $('#EmailInvitationForm').serialize();

        $.ajax(
            {
                url: '/TravelersController/SendInvitations',
                type: 'POST',
                data: modelFromForm,
                success: function (data, textStatus, jQxhr) {
                    $('#InvitationPartial').html(data),
                        console.log("success");
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
    });
});