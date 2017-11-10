$('#helper-form').submit(function (e) {

    e.preventDefault();

    $.ajax({
        type: $('#helper-form').attr('method'),
        url: $('#helper-form').attr('action'),
        data: $('#helper-form').serialize(),
        success: function (data) {
            console.log('Submission was successful.');
            $('#helper-result-header').html("You should get a " + data);
            console.log(data);
        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        },
    });
});