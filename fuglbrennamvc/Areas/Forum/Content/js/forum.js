﻿$(function () {
    tinymce.init({
        selector: 'textarea.tinymce',
        height: 300,
        menubar: false,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor textcolor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste code help'
        ],
        toolbar: 'insert | undo redo |  styleselect | bold italic backcolor  | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help',
        content_css: [
        ]
    });

    $(".date-ago").each(function (i, e) {
        var m = moment.utc($(e).html());
        $(e).html(m.fromNow());
        $(e).css('visibility', 'visible');

        var localFull = m.local().format("LLLL");
        $(e).attr('title', localFull);
    });
});