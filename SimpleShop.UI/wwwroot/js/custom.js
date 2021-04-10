(function ($) {
    "use strict";

    $('.popup-youtube, .popup-vimeo').magnificPopup({
        // disableOn: 700,
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false
    });



    var review = $('.textimonial_iner');
    if (review.length) {
        review.owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            autoplay: true,
            autoplayHoverPause: true,
            autoplayTimeout: 5000,
            nav: false,
            responsive: {
                0: {
                    margin: 15,

                },
                600: {
                    margin: 10,
                },
                1000: {
                    margin: 10,
                }
            }
        });
    }
    var best_product_slider = $('.best_product_slider');
    if (best_product_slider.length) {
        best_product_slider.owlCarousel({
            items: 4,
            loop: true,
            dots: false,
            autoplay: true,
            autoplayHoverPause: true,
            autoplayTimeout: 5000,
            nav: true,
            navText: ["next", "previous"],
            responsive: {
                0: {
                    margin: 15,
                    items: 1,
                    nav: false
                },
                576: {
                    margin: 15,
                    items: 2,
                    nav: false
                },
                768: {
                    margin: 30,
                    items: 3,
                    nav: true
                },
                991: {
                    margin: 30,
                    items: 4,
                    nav: true
                }
            }
        });
    }

    //product list slider
    var product_list_slider = $('.product_list_slider');
    if (product_list_slider.length) {
        product_list_slider.owlCarousel({
            items: 1,
            loop: true,
            dots: false,
            autoplay: true,
            autoplayHoverPause: true,
            autoplayTimeout: 5000,
            nav: true,
            navText: ["next", "previous"],
            smartSpeed: 1000,
            responsive: {
                0: {
                    margin: 15,
                    nav: false,
                    items: 1
                },
                600: {
                    margin: 15,
                    items: 1,
                    nav: false
                },
                768: {
                    margin: 30,
                    nav: true,
                    items: 1
                }
            }
        });
    }

    //single banner slider
    // var banner_slider = $('.banner_slider');
    // if (banner_slider.length) {
    //   banner_slider.owlCarousel({
    //     items: 1,
    //     loop: true,
    //     dots: false,
    //     autoplay: true,
    //     autoplayHoverPause: true,
    //     autoplayTimeout: 5000,
    //     nav: true,
    //     navText: ["next","previous"],
    //     smartSpeed: 1000,
    //   });
    // }

    if ($('.img-gal').length > 0) {
        $('.img-gal').magnificPopup({
            type: 'image',
            gallery: {
                enabled: true
            }
        });
    }


    //single banner slider
    $('.banner_slider').on('initialized.owl.carousel changed.owl.carousel', function (e) {
        function pad2(number) {
            return (number < 10 ? '0' : '') + number
        }
        var carousel = e.relatedTarget;
        $('.slider-counter').text(pad2(carousel.current()));

    }).owlCarousel({
        items: 1,
        loop: true,
        dots: false,
        autoplay: true,
        autoplayHoverPause: true,
        autoplayTimeout: 5000,
        nav: true,
        navText: ["next", "previous"],
        smartSpeed: 1000,
        responsive: {
            0: {
                nav: false
            },
            600: {
                nav: false
            },
            768: {
                nav: true
            }
        }
    });



    // niceSelect js code
    $(document).ready(function () {
        $('select').niceSelect();
    });

    // menu fixed js code
    // $(window).scroll(function () {
    //   var window_top = $(window).scrollTop() + 1;
    //   if (window_top > 50) {
    //     $('.main_menu').addClass('menu_fixed animated fadeInDown');
    //   } else {
    //     $('.main_menu').removeClass('menu_fixed animated fadeInDown');
    //   }
    // });


    $('.counter').counterUp({
        time: 2000
    });

    $('.slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        speed: 300,
        infinite: true,
        asNavFor: '.slider-nav-thumbnails',
        autoplay: true,
        pauseOnFocus: true,
        dots: true,
    });

    $('.slider-nav-thumbnails').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.slider',
        focusOnSelect: true,
        infinite: true,
        prevArrow: false,
        nextArrow: false,
        centerMode: true,
        responsive: [{
            breakpoint: 480,
            settings: {
                centerMode: false,
            }
        }]
    });


    // Search Toggle
    $("#search_input_box").hide();
    $("#search_1").on("click", function () {
        $("#search_input_box").slideToggle();
        $("#search_input").focus();
    });
    $("#close_search").on("click", function () {
        $('#search_input_box').slideUp(500);
    });

    //------- Mailchimp js --------//  
    function mailChimp() {
        $('#mc_embed_signup').find('form').ajaxChimp();
    }
    mailChimp();

    // click counter js
    (function () {
        let orders = [];
        $('.inumber-decrement, .number-increment').on('click', function (e) {
            const isNegative = $(e.target).closest('.inumber-decrement').is('.inumber-decrement');
            const input = $(e.target).closest('.product_count').find('input');
            if (input.is('input')) {
                input[0][isNegative ? 'stepDown' : 'stepUp']();
            }
        })

        var increment_descrementBtn = $('.ti-angle-down, .ti-angle-up');
        increment_descrementBtn.each(function (index) {
            $(this).on("click", function () {
                const input = $(this).closest('.product_count').find('input');
                const isNegative = $(this).closest('.ti-angle-down').is('.ti-angle-down');
                if (input.is('input')) {
                    input[0][isNegative ? 'stepDown' : 'stepUp']();

                    if (input.val() > 0 && input.val() < 15) {
                        let productId = input.attr('product-id');
                        let quantity = 1;

                        let input1 = $("<input>")
                            .attr("type", "hidden")
                            .attr("name", "productId").val(productId);
                        let input3 = $("<input>")
                            .attr("type", "hidden")
                            .attr("name", "quantity").val(quantity);
                        let input4 = $("<input>")
                            .attr("type", "hidden")
                            .attr("name", "isIncrement").val(!isNegative);

                        $(this).parents('form')[0].append(input1[0], input3[0], input4[0]);
                        $(this).parents('form')[0].submit();
                    }
                }
            });
        })
        //$("#update_cart_btn").click(function () {

        //});

    })();

    // click counter js


    // var a = 0;
    // $('.increase').on('click', function(){



    //   console.log(  $(this).innerHTML='Product Count: '+ a++ );
    // });

    var product_overview = $('#vertical');
    if (product_overview.length) {
        product_overview.lightSlider({
            gallery: true,
            item: 1,
            vertical: true,
            verticalHeight: 450,
            thumbItem: 4,
            slideMargin: 0,
            speed: 600,
            autoplay: true,
            responsive: [
                {
                    breakpoint: 991,
                    settings: {
                        item: 1,

                    }
                },
                {
                    breakpoint: 576,
                    settings: {
                        item: 1,
                        slideMove: 1,
                        verticalHeight: 350,
                    }
                }
            ]
        });
    }




}(jQuery));