// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var table = $('#weathertable').DataTable(
        {
            "ajax":
            {
                "url": "/Home/Fetch",
                "error": handleAjaxError
            },
            "pageLength" : 5,
            "columns": [
                { "data": "name" },
                { "data": "main" },
                { "data": "description" },
                { "data": "temp" }
            ],
            "language": {
                "loadingRecords": "Loading weather data, please hold..."
            }
        }
    );
});

function handleAjaxError(xhr, textStatus, error) {
    $('#failuretoast').toast({ delay: 8000 });
    $('#failuretoast').toast('show');
}

$('body').on('click', '.close', function () {
    $(this).closest('.toast').toast('hide');
});
