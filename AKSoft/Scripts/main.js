/* HTML document is loaded. DOM is ready.
-------------------------------------------*/
$(function(){

    /* start typed element */
    var subElementArray = $.map($('.sub-element'), function(el) { return $(el).text(); });    
    $(".element").typed({
        strings: subElementArray,
        typeSpeed: 30,
        contentType: 'html',
        showCursor: false,
        loop: true,
        loopCount: true,
    });
 
        /* Hide mobile menu after clicking on a link
        -----------------------------------------------*/
        $('.navbar-collapse a').click(function(){
            $(".navbar-collapse").collapse('hide');
        });
        /* end navigation top js */

        $('body').bind('touchstart', function() {});

        /* wow
        -----------------*/
        new WOW().init();
    });

    /* start preloader */
    $(window).load(function(){
        $('.preloader').fadeOut(1000); // set duration in brackets    
    });