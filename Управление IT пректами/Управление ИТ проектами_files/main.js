$(document).ready(function() {
	
	// ����� ������ � ��������� ����
	$('input.change-text').each(function() {
		var textControlDef = $(this).val();
		$(this).focus(function() {
			var textControlCur = $(this).val();
			if(textControlCur === textControlDef) {
				$(this).val('').addClass('write-color');
				$(this).blur(function() {
					var textControlNew = $(this).val();
					if(textControlNew == 0) {
						$(this).val(textControlCur).removeClass('write-color');
					}
				});
			}
		});
	});
	
	// ����� �������� �� �������
	$('.js-subscribe').click(function() {
		$(this).siblings('.subscribe-popup').fadeToggle();
		return false;
	});
	
	// �������� �� ����������
	$('.share-box .link').click(function() {
		$(this).siblings('.share-box-c').fadeToggle();
		return false;
	});
	
	// ���� �������� �� ����������
	$('.link-toggle-sections').click(function() {
		if($('.library-sections').hasClass('hidden') == true) {
			$(this).siblings('.library-sections-c').slideDown(500, function() {
				$('.link-toggle-sections i').text('������');
				$('.library-sections').removeClass('hidden');
			});
		} else {
			$(this).siblings('.library-sections-c').slideUp(500, function() {
				$('.link-toggle-sections i').text('��������');
				$('.library-sections').addClass('hidden');
			});
		}
		return false;
	});
	
});
