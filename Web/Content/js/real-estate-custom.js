//sticky header

$(window).resize(function () {
    $(".navbar-collapse").css({maxHeight: $(window).height() - $(".navbar-header").height() + "px"});
});
//sticky header on scroll
$(document).ready(function () {
    $(window).load(function () {
        $(".sticky").sticky({topSpacing: 0});
    });
});

//slider revolution
jQuery(document).ready(function () {

    revapi = jQuery('.tp-banner').revolution(
            {
                delay: 6000,
                startwidth: 1170,
                startheight: 450,
                hideThumbs: 10,
                fullWidth: "on",
                forceFullWidth: "on",
                navigationStyle: "preview4"
            });

});	//ready

//all property slider
$(document).ready(function () {

    $("#property-slider").owlCarousel({
    loop:true,
    margin:0,
    nav:false,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:4
        }
    }
});
});

//select box
(function () {
    [].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
        new SelectFx(el);
    });
})();



//thumb slider
$(window).load(function() {
  // The slider being synced must be initialized first
  $('#carousel').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: false,
    slideshow: false,
    itemWidth: 210,
    itemMargin: 5,
    asNavFor: '#slider'
  });
 
  $('#slider').flexslider({
    animation: "slide",
    controlNav: false,
    animationLoop: false,
    slideshow: false,
    sync: "#carousel"
  });
});


/***********************************************************
     * ACCORDION
     ***********************************************************/
    $('.panel-heading a[data-toggle="collapse"]').on('click', function () {
        if ($(this).closest('.panel-heading').hasClass('active')) {
            $(this).closest('.panel-heading').removeClass('active');
        } else {
            $('.panel-heading a[data-toggle="collapse"]').closest('.panel-heading').removeClass('active');
            $(this).closest('.panel-heading').addClass('active');
        }
    });
    