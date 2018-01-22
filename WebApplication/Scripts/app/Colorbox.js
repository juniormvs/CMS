function initColorbox() {
    console.log('init colorbox');

    $.colorbox.remove();

    $('.colorbox').colorbox({
        photo: true,
        rel: 'colorbox',
        reposition: true,
        scalePhotos: true,
        scrolling: false,
        previous: '<i class="ace-icon fa fa-arrow-left"></i>',
        next: '<i class="ace-icon fa fa-arrow-right"></i>',
        close: '&times;',
        current: '{current} of {total}',
        maxWidth: '100%',
        maxHeight: '100%'
    });
}

$(document).ready(function () {
    initColorbox();
});

