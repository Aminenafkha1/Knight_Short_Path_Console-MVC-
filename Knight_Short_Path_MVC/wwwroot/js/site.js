// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function callPath(x,y) {


    $.ajax({
        type: "POST",
        data: {x:x,y:y},
        success: function (data) {
            // Handle the response
            $("body").html(data)
        },
        error: function () {
            alert("An error occurred.");
        }
    });
}