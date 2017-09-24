$(function () {
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
            '/Areas/Forum/Content/css/forum.css'
        ]
    });

    $(".date-ago").each(function (i, e) {
        var m = moment.utc($(e).html());
        $(e).html(m.fromNow());
        $(e).css('visibility', 'visible');

        var localFull = m.local().format("LLLL");
        $(e).attr('title', localFull);
    });

    var quoteTemplate = $($("#forum-quote-template").html());

    $("body").on("click", "a.post-quote", function () {
        var post = $(this).closest(".forum-posts__post");
        var memberName = post.data("member");
        var postDate = moment.utc(post.data("date")).local().format("LLLL");
        var postContent = post.find(".post__main .content").html();
        var quote = $("<div></div>").append(quoteTemplate.clone());
        quote.find(".forum-quote__header__name").html(memberName);
        quote.find(".forum-quote__header__date").html(postDate);
        quote.find(".forum-quote__content").html(postContent);
        tinymce.activeEditor.execCommand('mceInsertContent', false, quote.html());
    });
});