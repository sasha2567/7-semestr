jQuery(document).ready(function(){
    /* ������� ���������������� ����������� ������� �� ����� ��������� � ������� ������� ��������� ��������� */
    function getScrollTop() {
               var scrOfY = 0;
               if( typeof( window.pageYOffset ) == "number" ) {
                       //Netscape compliant
                       scrOfY = window.pageYOffset;
               } else if( document.body
               && ( document.body.scrollLeft
               || document.body.scrollTop ) ) {
                       //DOM compliant
                       scrOfY = document.body.scrollTop;
               } else if( document.documentElement
               && ( document.documentElement.scrollLeft
                || document.documentElement.scrollTop ) ) {
                       //IE6 Strict
                       scrOfY = document.documentElement.scrollTop;
               }
               return scrOfY;
    }
    /* ������������� ������ ��� ��������� ������ */
    jQuery(window).scroll(function() {
        fixPaneRefresh();
    });
    
    function fixPaneRefresh(){
        if (jQuery("#fixedBox").length) {
            var top  = getScrollTop();
            if (top < 750) jQuery("#fixedBox").css("top",750-top+"px"); /* 400 650 - ��� ��� ������ */
            else jQuery("#fixedBox").css("top","0");
        }
    }

});