$(function () {
    $("#d-add-comment-form").on('submit', function (e) {
        e.preventDefault();
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var commentSection = $("#d-comment-section");
            commentSection.html(data);
            $form[0].reset();
            $('.d-comment').last().hide().show('slow'); 
        }).fail(function (xhdr, statusText, errorText) {
            console.log(xhdr);
        });
 
    });
});