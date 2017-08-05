(function ($) {
	"use strict";

    $(document).ready(function($){

        //active class
        $(".carousel-inner .item:first-child").addClass("active");        
        
		//Fixed nav on scroll
		$(document).on('scroll',function(e){
			var scrollTop = $(document).scrollTop();
			if(scrollTop > $('nav').height()){
				$('nav').addClass('navbar-scroll');
			}
			else {
				$('nav').removeClass('navbar-scroll');
			}
		});
		
		//Numaric Counter
		$('.counter').counterUp({
			delay: 10,
			time: 1000
		});	
		
		//Portfolio Popup
		$('.magnific-popup').magnificPopup({type:'image'});
		
		//Video popup
		$('.popup-youtube').magnificPopup({
			type: 'iframe'
		})
		
		//Smooth Scroll
		smoothScroll.init();
		
		//active on scroll
		$('body').scrollspy({ 
			target: '.navbar',
			offset: 80
		})
		
		//Progress bar
		$('.progress .progress-bar').progressbar();
		
		//WOW
		new WOW().init();
		
    });


    $(window).on('load',function(){
		
		//Preloader
		$('.preloader').delay(500).fadeOut('slow');
        $('body').delay(500).css({'overflow':'visible'});

		//Portfolio container			
		var $container = $('.portfolioContainer');
		$container.isotope({
			filter: '*',
			animationOptions: {
				duration: 750,
				easing: 'linear',
				queue: false
			}
		});
 
		$('.portfolioFilter a').on('click', function(){
			$('.portfolioFilter a').removeClass('current');
			$(this).addClass('current');
	 
			var selector = $(this).attr('data-filter');
			$container.isotope({
				filter: selector,
				animationOptions: {
					duration: 750,
					easing: 'linear',
					queue: false
				}
			 });
			 return false;
		}); 
		        
    });


}(jQuery));	