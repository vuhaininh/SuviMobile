
$(document).ready(function(){
	$('input[type="text"], textarea').on('keyup', function () {
		var value = $(this).val();
        Native("TextChanging", value);
    });

	$('.input-radio, .star-radio, .smiley-radio').on('click', function (e) {
		var content = $(this).val();
        Native("goNext", content);
    });

    $('.js-next').on('click', function(e){
    	var content = "";
    	if($('.question-input').length){
    		content = $('textarea').val();
    	}
    	else if($('.question-choices').length){
	    	var checkedValues = [];
	    	$('.input-checkbox:checked').each(function() {
	       		checkedValues.push($(this).val());
	     	});
	     	content = checkedValues.join();
     	}
     	Native("goNext", content);
    });

});
	