"use strict";


// Prealoder
 function prealoader () {
   if ($('#loader').length) {
     $('#loader').fadeOut(); // will first fade out the loading animation
     $('#loader-wrapper').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
     $('body').delay(350).css({'overflow':'visible'});
  };
 }



// Banner rev Slider 
function mainBanner () {
	if ($("#banner").length) {
		$("#rev_slider").revolution({
			sliderLayout:"fullwidth",
			dottedOverlay:"none",
			delay:7500,
			navigation: {
				keyboardNavigation:"off",
				keyboard_direction: "horizontal",
				mouseScrollNavigation:"off",
				onHoverStop:"on",
				touch:{
					touchenabled:"on",
					swipe_threshold: 75,
					swipe_min_touches: 1,
					swipe_direction: "horizontal",
					drag_block_vertical: false
				},
				arrows: {
      		          style: "hermes",
      		          enable: true,
      		          hide_onmobile: false,
      		          hide_onleave: false,
      		          tmp: '<div class="tp-arr-allwrapper">	<div class="tp-arr-imgholder"></div>	<div class="tp-arr-titleholder">{{title}}</div>	</div>',
      		          left: {
      		              h_align: "left",
      		              v_align: "center",
      		              h_offset: 10,
      		              v_offset: 0
      		          },
      		          right: {
      		              h_align: "right",
      		              v_align: "center",
      		              h_offset: 10,
      		              v_offset: 0
      		          }
      		      },
			
				bullets: {
	                enable: true,
	                hide_onmobile: false,
	                style: "uranus",
	                hide_onleave: false,
	                direction: "horizontal",
	                h_align: "center",
	                v_align: "bottom",
	                h_offset: 20,
	                v_offset: 90,
	                space: 8,
	                tmp: '<span class="tp-bullet-inner"></span>'
	            }
			},
			viewPort: {
				enable:true,
				outof:"pause",
				visible_area:"80%"
			},
			responsiveLevels:[2220,1183,975,751],
			gridwidth:[1170,970,770,480],
			gridheight:[907,900,800,700],
			lazyType:"none",
			parallax: {
				type:"mouse",
				origo:"slidercenter",
				speed:2000,
				levels:[2,3,4,5,6,7,12,16,10,50],
			},
			shadow:0,
			spinner:"off",
			stopLoop:"off",
			stopAfterLoops:-1,
			stopAtSlide:-1,
			shuffle:"off",
			autoHeight:"off",
			hideThumbsOnMobile:"off",
			hideSliderAtLimit:0,
			hideCaptionAtLimit:0,
			hideAllCaptionAtLilmit:0,
			debugMode:false,
			fallbacks: {
				simplifyAll:"off",
				nextSlideOnWindowFocus:"off",
				disableFocusListener:false,
			}
	    });
	};
}


// placeholder remove
function removePlaceholder () {
  if ($("input,textarea").length) {
    $("input,textarea").each(
            function(){
                $(this).data('holder',$(this).attr('placeholder'));
                $(this).on('focusin', function() {
                    $(this).attr('placeholder','');
                });
                $(this).on('focusout', function() {
                    $(this).attr('placeholder',$(this).data('holder'));
                });
                
        });
  }
}

// Accordion panel
function themeAccrodion () {
  if ($('.theme-accordion > .panel').length) {
    $('.theme-accordion > .panel').on('show.bs.collapse', function (e) {
          var heading = $(this).find('.panel-heading');
          heading.addClass("active-panel");
          
    });
    
    $('.theme-accordion > .panel').on('hidden.bs.collapse', function (e) {
        var heading = $(this).find('.panel-heading');
          heading.removeClass("active-panel");
          //setProgressBar(heading.get(0).id);
    });

  };
}


// Testimonial Slider 
function testimonialSlider () {
	if($('#testimonial-slider').length) {
		$('#testimonial-slider').owlCarousel({
		    loop:true,
		    margin:30,
		    nav:false,
		    autoplay:true,
		    autoplayTimeout:1500,
		    autoplaySpeed:1000,
		    lazyLoad:true,
		    singleItem:true,
		    responsive:{
		        0:{
		            items:1
		        },
		        731:{
		            items:2
		        },
		        1000:{
		            items:3
		        }
		    }
		})
	}
}



// Partner Logo Footer 
function partnersLogo () {
	if($('#partner_logo').length) {
		$('#partner_logo').owlCarousel({
		    loop:true,
		    margin:-1,
		    nav:false,
		    dots:false,
		    autoplay:true,
		    autoplayTimeout:1000,
		    autoplaySpeed:900,
		    lazyLoad:true,
		    singleItem:true,
		    responsive:{
		        0:{
		            items:1
		        },
		        550:{
		            items:2
		        },
		        751:{
		            items:3
		        },
		        1001:{
		            items:4
		        }
		    }
		})
	}
}



// Counter function
function CounterNumberChanger () {
  var timer = $('.timer');
  if(timer.length) {
    timer.appear(function () {
      timer.countTo();
    })
  }
}


// Scroll to top
function scrollToTop () {
  if ($('.scroll-top').length) {

    //Check to see if the window is top if not then display button
    $(window).on('scroll', function (){
      if ($(this).scrollTop() > 200) {
        $('.scroll-top').fadeIn();
      } else {
        $('.scroll-top').fadeOut();
      }
    });
    
    //Click event to scroll to top
    $('.scroll-top').on('click', function() {
      $('html, body').animate({scrollTop : 0},1500);
      return false;
    });
  }
}



// Mixitup gallery
function mixitupGallery () {
  if ($("#mixitup_list").length) {
    $("#mixitup_list").mixItUp()
  };
}



// Fancybox 
function FancypopUp () {
  if ($(".fancybox").length) {
    $(".fancybox").fancybox({
      openEffect  : 'elastic',
        closeEffect : 'elastic',
         helpers : {
            overlay : {
                css : {
                    'background' : 'rgba(0, 0, 0, 0.6)'
                }
            }
        }
    });
  };
}


// Google Map 
function googlMap () {
	if($("#google-map").length) {
		var settingsItemsMap = {
	        zoom: 12,
	        center: new google.maps.LatLng(23.810332, 90.412518),
	        zoomControlOptions: {
	          style: google.maps.ZoomControlStyle.LARGE
	        },
	        scrollwheel: false,
	        mapTypeId: google.maps.MapTypeId.ROADMAP
	    };
	    var map = new google.maps.Map(document.getElementById('google-map'), settingsItemsMap );
	    var image = 'images/map.png';
	    var myMarker = new google.maps.Marker({
	        position: new google.maps.LatLng(23.810332, 90.412518),
	        draggable: true,
	        icon: image
	    });

	    map.setCenter(myMarker.position);
	    myMarker.setMap(map);
	    // Google map 
	};
}

//Contact Form Validation
function contactFormValidation () {
  if($('.form-validation').length){
    $('.form-validation').validate({ // initialize the plugin
      rules: {
        name: {
          required: true
        },
        email: {
          required: true,
          email: true
        },
        phone: {
          required: true
        },
        message: {
          required: true
        }
      },
      submitHandler: function(form) {
                $(form).ajaxSubmit({
                    success: function() {
                        $('.form-validation :input').attr('disabled', 'disabled');
                        $('.form-validation').fadeTo( "slow", 1, function() {
                            $(this).find(':input').attr('disabled', 'disabled');
                            $(this).find('label').css('cursor','default');
                            $('#alert_success').fadeIn();
                        });
                    },
                    error: function() {
                        $('.form-validation').fadeTo( "slow", 1, function() {
                            $('#alert_error').fadeIn();
                        });
                    }
                });
            }
        });
  }
}

// Close suddess Alret
function closeSuccessAlert () {
  if($('.closeAlert').length) {
    $(".closeAlert").on('click', function(){
      $(".alert_wrapper").fadeOut();
    });
    $(".closeAlert").on('click', function(){
      $(".alert_wrapper").fadeOut();
    })
  }
}

// Sticky menu
function menuScroll () {
  if ($('header').length) {
    var sticky = $('header'),
        scroll = $(window).scrollTop();

    if (scroll >= 100) sticky.addClass('fixed');
    else sticky.removeClass('fixed');
    
  };
}



// toggle menu for mobile
function mobileDropdown () {
  if($('header').length) {
    $('header nav.navbar-default .nav>li.dropdown-holder').append(function () {
      return '<i class="fa fa-bars"></i>';
    });
    $('header nav.navbar-default .nav>li.dropdown-holder .fa').on('click', function () {
      $(this).parent('li').children('ul').slideToggle();
    }); 
  }
}


// Progress Bar
function bootstrapProgress () {
  if($('.progress').length) {
    $(function() {
    
    var $meters = $(".progress > .progress-bar");
    var $section = $('.our_skills');
    var $queue = $({});
    
    function loadDaBars() {
        $meters.each(function() {
            var $el = $(this);
            var origWidth = $el.width();
            $el.width(0);
            $queue.queue(function(next) {
                $el.animate({width: origWidth}, 700, next);
            });
        });
    }
    
    $(document).bind('scroll', function(ev) {
        var scrollOffset = $(document).scrollTop();
        var containerOffset = $section.offset().top - window.innerHeight;
        if (scrollOffset > containerOffset) {
            loadDaBars();
            // unbind event not to load scrolsl again
            $(document).unbind('scroll');
        }
    });
    
});
  }
}



// DOM ready function
jQuery(document).on('ready', function() {
	mainBanner ();
	removePlaceholder ();
	themeAccrodion ();
	testimonialSlider ();
	partnersLogo ();
	CounterNumberChanger ();
	scrollToTop ();
	mixitupGallery ();
	FancypopUp ();
	googlMap ();
	contactFormValidation ();
	closeSuccessAlert ();
	mobileDropdown ();
	bootstrapProgress ()
});


// Window scroll function
jQuery(window).on('scroll', function () {
  (function ($) {
   	menuScroll ()
  })(jQuery);
});


// window load function
jQuery(window).on('load', function () {
  (function ($) {
  	prealoader ()
  })(jQuery);
});