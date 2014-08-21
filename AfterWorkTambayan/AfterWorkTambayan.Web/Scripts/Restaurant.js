// Restaurant.js
var restaurantModule = function () {
    var map;

    var init = function (latitude, longitude) {
        var mapOptions = {
            zoom: 15,
            center: new google.maps.LatLng(latitude, longitude),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map'), mapOptions);
    };

    var set = function (latitude, longitude) {
        var newLatlng = new google.maps.LatLng(latitude, longitude);
        map.setCenter(newLatlng);
    };

    return {
        init: init,
        set: set
    };

} ();

var angularJSFix;
var angularJSFixRestaurant;
function loadingIndicator() {
    $('#divResult').html("");
    $('#divResult').html('<div id="outercontainer"><div id="innercontainer">' +
                    '<div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div><span>Loading...Please wait</span></div>' +
                    '</div></div>');
    angularJSFix = true;
}

$(document).ready(function () {
    angularJSFix = false;
    angularJSFixRestaurant = "";

    $('#example').popover(
        {
            title: 'About',
            content: "<strong>Restaurant Profile Accordion and Add Restaurant Partial View are about integrating conventional ASP.NET MVC with Bootstrap.<br /><br />" +
                "Menu Administration is working around ASP.NET MVC to code Bootstrap modal input forms.<br /><br />" +
                "Foods and Services Accordion is all AngularJS.</strong>"
        }
    );

    $('#restaurant a[href="#"]').click(function () {
        $('li').removeClass('active');
        $(this).closest('li').addClass('active');
        var item = $(this).attr("data-category");
        var id = $(this).attr("data-id");
        angularJSFixRestaurant = id;
        
        switch (item) {
            case "listRestaurant":
                loadingIndicator();
                $('#divResult').load('Restaurant/GetRestaurant/' + id);
                break;
            case "menuAdmin":
                loadingIndicator();
                $('#divResult').load('Restaurant/GetMenu');
                break;
            case "addRestaurant":
                loadingIndicator();
                $('#divResult').load('Restaurant/AddRestaurant');
                break;
            default:
                break;
        }

        return false;
    });
    
    var active = $('#restaurant li.active a').attr("data-id");
    if (active && !doAngularJSFix) {
        $('#divResult').load('Restaurant/GetRestaurant/' + active);
    } else if (doAngularJSFix && doAngularJSFixRestaurant) {        
        $('li').removeClass('active');        
        $("#restaurant").find("[data-id='" + doAngularJSFixRestaurant + "']").closest('li').addClass("active")
        $('#divResult').load('Restaurant/GetRestaurant/' + doAngularJSFixRestaurant + "?angularJSFix=yes");
    }

});