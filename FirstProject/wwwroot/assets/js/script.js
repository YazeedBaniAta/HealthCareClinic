
;(function ($) {


	'use strict';

	$(window).on('scroll', function () {
		if ($(window).scrollTop() > 70) {
			$('.backtop').addClass('reveal');
		} else {
			$('.backtop').removeClass('reveal');
		}
	});

	window.addEventListener('load', function () {
		document.querySelector('body').classList.add("loaded")
	});

	/**
   * To get Doctor after Filter
   */
	$('select[name="DepartmentId"]').on('change', function () {
		var DepartmentId = $(this).val();
		if (DepartmentId) {
			//console.log(DepartmentId);
			$.ajax({
				url: "/Home/GetDoctor/" + DepartmentId,
				type: "GET",
				dataType: "json",
				success: function (data) {
					$('select[name="DoctorId"]').empty();
					$('select[name="DoctorId"]').append('<option selected disabled >Select Doctor</option>');
					$.each(data.result, function (key, value) {
						$('select[name="DoctorId"]').append('<option value="' + value.id + '">' + "Dr-" + value.firstName +" "+ value.lastName + '</option>');
					});
				},
			});

		} else {
			console.log('AJAX load did not work');
		}
	});

	/* DATA TABLES */
	init_DataTables();
	
	/*
	* To make smooth scroll
	*/
	var scroll = new SmoothScroll('a[href*="#"]');

	/*
	* scroll-progress in head of site
	*/

	const scrollProgress = document.getElementById('scroll-progress');
	const height =
		document.documentElement.scrollHeight - document.documentElement.clientHeight;

	window.addEventListener('scroll', () => {
		const scrollTop =
			document.body.scrollTop || document.documentElement.scrollTop;
		scrollProgress.style.width = `${(scrollTop / height) * 100}%`;
	});
	
	/**
   * Animation on scroll
   */
	window.addEventListener('load', () => {
		AOS.init({
			duration: 1000,
			easing: 'ease-in-out',
			once: true,
			mirror: false
		})
	});


	$('.portfolio-single-slider').slick({
		infinite: true,
		arrows: false,
		autoplay: true,
		autoplaySpeed: 2000

	});

	$('.clients-logo').slick({
		infinite: true,
		arrows: false,
		autoplay: true,
		slidesToShow: 6,
		slidesToScroll: 6,
		autoplaySpeed: 6000,
		responsive: [
		    {
		      breakpoint: 1024,
		      settings: {
		        slidesToShow:6,
		        slidesToScroll: 6,
		        infinite: true,
		        dots: true
		      }
		    },
		    {
		      breakpoint: 900,
		      settings: {
		        slidesToShow:4,
		        slidesToScroll: 4
		      }
		    },{
		      breakpoint: 600,
		      settings: {
		        slidesToShow: 4,
		        slidesToScroll: 4
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
		        slidesToShow: 2,
		        slidesToScroll: 2
		      }
		    }
		  
  		]
	});

	$('.testimonial-wrap').slick({
		slidesToShow: 1,
		slidesToScroll: 1,
		infinite: true,
		dots: true,
		arrows: false,
		autoplay: true,
		vertical:true,
		verticalSwiping:true,
		autoplaySpeed: 6000,
		responsive: [
		    {
		      breakpoint: 1024,
		      settings: {
		        slidesToShow:1,
		        slidesToScroll: 1,
		        infinite: true,
		        dots: true
		      }
		    },
		    {
		      breakpoint: 900,
		      settings: {
		        slidesToShow: 1,
		        slidesToScroll: 1
		      }
		    },{
		      breakpoint: 600,
		      settings: {
		        slidesToShow: 1,
		        slidesToScroll: 1
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
		        slidesToShow: 1,
		        slidesToScroll: 1
		      }
		    }
		  
  		]
	});

	$('.testimonial-wrap-2').slick({
		slidesToShow: 2,
		slidesToScroll: 2,
		infinite: true,
		dots: true,
		arrows:false,
		autoplay: true,
		autoplaySpeed: 6000,
		responsive: [
		    {
		      breakpoint: 1024,
		      settings: {
		        slidesToShow:2,
		        slidesToScroll:2,
		        infinite: true,
		        dots: true
		      }
		    },
		    {
		      breakpoint: 900,
		      settings: {
		        slidesToShow: 1,
		        slidesToScroll: 1
		      }
		    },{
		      breakpoint: 600,
		      settings: {
		        slidesToShow: 1,
		        slidesToScroll: 1
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
		        slidesToShow: 1,
		        slidesToScroll: 1
		      }
		    }
		  
  		]
	});


	// Counter

	$('.counter-stat span').counterUp({
	      delay: 10,
	      time: 1000
	  });

		
 // Shuffle js filter and masonry
    var Shuffle = window.Shuffle;
    var jQuery = window.jQuery;

    var myShuffle = new Shuffle(document.querySelector('.shuffle-wrapper'), {
        itemSelector: '.shuffle-item',
        buffer: 1
    });

    jQuery('input[name="shuffle-filter"]').on('change', function (evt) {
        var input = evt.currentTarget;
        if (input.checked) {
            myShuffle.filter(input.value);
        }
    });

})(jQuery);


function init_DataTables() {

	console.log('run_datatables');

	if (typeof ($.fn.DataTable) === 'undefined') { return; }
	console.log('init_DataTables');

	var handleDataTableButtons = function () {
		if ($("#datatable-buttons").length) {
			$("#datatable-buttons").DataTable({
				dom: "Blfrtip",
				buttons: [
					{
						extend: "copy",
						className: "btn btn-sm btn-secondary mx-1 px-3 rounded"
					},
					{
						extend: "csv",
						className: "btn btn-sm btn-secondary mx-1 px-3 rounded"
					},
					{
						extend: "excel",
						className: "btn btn-sm btn-secondary mx-1 px-3 rounded"
					},
					{
						extend: "pdfHtml5",
						className: "btn btn-sm btn-secondary mx-1 px-3 rounded"
					},
					{
						extend: "print",
						className: "btn btn-sm btn-secondary mx-1 px-3 rounded"
					},
				],
				responsive: true
			});
		}
	};

	TableManageButtons = function () {
		"use strict";
		return {
			init: function () {
				handleDataTableButtons();
			}
		};
	}();

	$('#datatable').dataTable();

	$('#datatable-keytable').DataTable({
		keys: true
	});

	$('#datatable-responsive').DataTable();

	$('#datatable-scroller').DataTable({
		ajax: "js/datatables/json/scroller-demo.json",
		deferRender: true,
		scrollY: 380,
		scrollCollapse: true,
		scroller: true
	});

	$('#datatable-fixed-header').DataTable({
		fixedHeader: true
	});

	var $datatable = $('#datatable-checkbox');

	$datatable.dataTable({
		'order': [[1, 'asc']],
		'columnDefs': [
			{ orderable: false, targets: [0] }
		]
	});
	$datatable.on('draw.dt', function () {
		$('checkbox input').iCheck({
			checkboxClass: 'icheckbox_flat-green'
		});
	});

	TableManageButtons.init();

};

