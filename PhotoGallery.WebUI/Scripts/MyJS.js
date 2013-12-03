var GALLERY = {
    container: "#gallery",
    url: "/Gallery/JSLoadPhoto",
    load: function () {
        var _gallery = this;
        $.ajax({
            type: "get",
            url: this.url,
            cache: false,
            success: function (data) {
                var images = data.split('|');
                if (images[0] == "" || images[0] == null) {
                    $('#btnLoadMore').hide();
                    return 0;
                }
                $.each(images, function () {
                    _gallery.display(this);
                });
            }
        });
    },
    display: function (image_url) {

        if ($(this.container + ' tbody tr:last td').length < 3) {
            $(this.container + ' tbody tr:last').append('<td></td>');
        }
        else {
            $(this.container + ' tbody').append('<tr><td></td></tr>');
        }

        var images = image_url.split(';');

        $('<a href="" id="simplePhoto"></a>')
         .attr('photoName', images[1])
        .appendTo(this.container + ' tbody tr:last td:last');
        $('<img></img>')
        .attr('src', images[0])
        .attr('id', 'galleryPhoto')
        .attr('class', 'img-polaroid')
        .appendTo(this.container + ' tbody tr:last td:last a');
    }
};

$(document).ready(function () {
    GALLERY.load();
});


$('#galleryLoadSimple').on('click', '#simplePhoto', function (e) {
    var att = $(this).attr("photoName");
    $('#ShowSimple').load('/Gallery/ShowPhoto?photoName=' + att);
    return false;
});

$('#btnLoadMore').click(function () {
    GALLERY.load();
});