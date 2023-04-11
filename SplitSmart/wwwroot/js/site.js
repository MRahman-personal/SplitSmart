// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("h3:contains(Use another service to log in)").parent().parent().hide();
    $("h3:contains(Use another service to register.)").parent().parent().hide();
});