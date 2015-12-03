jQuery(document).ready(function(){
    /* функция кроссбраузерного определения отступа от верха документа к текущей позиции скроллера прокрутки */
    function getScrollTopRight() {
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
    /* пересчитываем отступ при прокрутке экрана */
    jQuery(window).scroll(function() {
        fixPaneRefresh();
    });
    
    function fixPaneRefresh(){
        if (jQuery("#fixedBoxRight").length) {
            var top  = getScrollTopRight();
            if (top < 1300) jQuery("#fixedBoxRight").css("top",1300-top+"px"); /* наш отступ */
            else jQuery("#fixedBoxRight").css("top","0");
        }
    }

});