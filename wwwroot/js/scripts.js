/*!
    * Start Bootstrap - SB Admin v6.0.2 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2020 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    (function($) {
    "use strict";
        window.handleTickerChanged = (symbol, price) => {
            // ... client-side processing/display code ...
            return 'Done!';
        };
    // Add active state to sidbar nav links
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
        $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function() {
            if (this.href === path) {
                $(this).addClass("active");
            }
        });
    
        // Toggle the side navigation
     
            $("#sidebarToggle").on("click", function (e) {
                e.preventDefault();
                $("body").toggleClass("sb-sidenav-toggled");

            });
        
        window.toggleSideBar = () => {        
                $("body").toggleClass("sb-sidenav-toggled");
            
        }
        window.tab1 = () => {
            $("#tab2").toggleClass("active");
            $("#tab1").removeClass("active");
            $("#tab3").removeClass("active");

        }
        window.tab2 = () => {

            $("#tab2").removeClass("active");
            $("#tab3").removeClass("active");

        }
        window.tab3 = () => {
         
            $("#tab2").removeClass("active");
            $("#tab3").removeClass("active");

        }
})(jQuery);





