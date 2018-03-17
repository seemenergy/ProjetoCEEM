jQuery(function ($) {'use strict';
    const OFFSET_NAVBAR = $('nav.navbar').height() + 25;

	// accordian
	$('.accordion-toggle').on('click', function () {
		$(this).closest('.panel-group').children().each(function(){
		  $(this).find('>.panel-heading').removeClass('active');
        });
	 	$(this).closest('.panel-heading').toggleClass('active');
	});

	//Initiat WOW JS
	new WOW().init();

	// portfolio filter
	$(window).load(function(){'use strict';
		var $portfolio_selectors = $('.portfolio-filter >li>a');
		var $portfolio = $('.portfolio-items');
		$portfolio.isotope({
			itemSelector : '.portfolio-item',
			layoutMode : 'fitRows'
		});
		
		$portfolio_selectors.on('click', function (){
			$portfolio_selectors.removeClass('active');
			$(this).addClass('active');
			var selector = $(this).attr('data-filter');
			$portfolio.isotope({ filter: selector });
			return false;
		});
	});

	// Contact form
	var form = $('#main-contact-form');
	form.submit(function(event){
		event.preventDefault();
		var form_status = $('<div class="form_status"></div>');
		$.ajax({
			url: $(this).attr('action'),

			beforeSend: function(){
				form.prepend( form_status.html('<p><i class="fa fa-spinner fa-spin"></i> Email is sending...</p>').fadeIn() );
			}
		}).done(function(data){
			form_status.html('<p class="text-success">' + data.message + '</p>').delay(3000).fadeOut();
		});
	});

	//goto top
	$('.gototop').click(function(event) {
		event.preventDefault();
		$('html, body').animate({
			scrollTop: $('body').offset().top
		}, 500);
	});

    // Scrolling buttons Highlight
	$(document).on('click', 'a[href^="#"]', function (event) {
		event.preventDefault();

		var $clickedAnchor = $(event.target);
		var $anchorParent = $clickedAnchor.closest('ul.nav');

		// $anchorParent.find('li').removeClass('active');
		// $clickedAnchor.closest("li").addClass('active');

		var adjustOffset = OFFSET_NAVBAR;

		if ($clickedAnchor.attr('href') === '#quem-somos')
			adjustOffset *= 2;

		$('html, body').animate({
			scrollTop: $($.attr(this, 'href')).offset().top - adjustOffset
		}, 500);
	});

	// $('a.navbar-brand').click(function(event) {
	// 	$('#left-menu').find('li').removeClass('active');
	// });

	$(document).scroll(function() {
		var activeClass = 'active';

		var $navEl = $('#left-menu a[href="#{id}"'.replace('{id}', (function() {
			var $el = $('.anchor');
			var position = $(document).scrollTop();
			var getPosition = function(el) {
				return $(el).offset().top - OFFSET_NAVBAR - 100;
			};

			if (position < getPosition($el.first())) return;

			var id;
            
			$el.each(function (index, el) {
				if (position > getPosition(el))
					id = $(el).attr('id');
			});
			return id;
		})()));
		
		if ($navEl.attr('href')) {
			var $li = $navEl.closest('li');
			$li.addClass(activeClass);
			$li.siblings().removeClass(activeClass);            
		}
		else {
			$('#left-menu li').removeClass('active');
		}
	});
    
    (function() {
        var moretext = '[ ... ] Leia mais';
        var readTag = '<span class="read"></span>';
        var $more = $('.more'); $more.wrap(readTag);
        var $read = $('.read');

        $('.read').each(function() {
            var html = '<span class="morecontent">&nbsp;&nbsp;'
                     + '<a href="" class="morelink">' + moretext + '</a></span>';

            $(this).append(html); 
        });

        $('.morelink').click(function(event){
            event.preventDefault();
            $(this).parents('.read')
                .find('.more')
                .removeClass('more');
            $(this).remove();
        });
    })();
});