$('#Animals-Search-Form').submit(function (e) {

    e.preventDefault();

    $.ajax({
        type: $('#Animals-Search-Form').attr('method'),
        url: $('#Animals-Search-Form').attr('action'),
        data: $('#Animals-Search-Form').serialize(),
        success: function (data) {
            console.log('Submission was successful.');
            $('#Animals-Section').html(data);
            console.log(data);
        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        },
    });
});
$('#Adoption-Agencies-Search-Form').submit(function (e) {

    e.preventDefault();

    $.ajax({
        type: $('#Adoption-Agencies-Search-Form').attr('method'),
        url: $('#Adoption-Agencies-Search-Form').attr('action'),
        data: $('#Adoption-Agencies-Search-Form').serialize(),
        success: function (data) {
            console.log('Submission was successful.');
            $('#Adoption-Agencies-Section').html(data);
            console.log(data);
        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        },
    });
});