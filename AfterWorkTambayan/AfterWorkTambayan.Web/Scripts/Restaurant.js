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

$(document).ready(function () {
    //alert('Restaurant.js');    

    $('#example').popover(
        {
            title: 'About',
            content: "<strong>Restaurant Profile Accordion and Add Restaurant Partial View are about integrating conventional ASP.NET MVC with Bootstrap.<br /><br />" +
                "Menu Administration is working around ASP.NET MVC to code Bootstrap modal input forms.<br /><br />" +
                "Foods and Services Accordion shall be all AngularJS.</strong>"
        }
    );

    $('#restaurant a[href="#"]').click(function () {
        $('li').removeClass('active');
        $(this).closest('li').addClass('active');

        var item = $(this).attr("data-category");
        var id = $(this).attr("data-id");
        //alert("item = " + item);
        switch (item) {
            case "listRestaurant":
                $('#divResult').html("");
                $('#divResult').html('<div id="outercontainer"><div id="innercontainer">' +
                    '<div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div><span>Loading...Please wait</span></div>' +
                    '</div></div>');
                $('#divResult').load('Restaurant/GetRestaurant/' + id);
                break;
            case "menuAdmin":
                $('#divResult').html("");
                $('#divResult').html('<div id="outercontainer"><div id="innercontainer">' +
                    '<div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div><span>Loading...Please wait</span></div>' +
                    '</div></div>');
                $('#divResult').load('Restaurant/GetMenu');
                break;
            case "addRestaurant":
                $('#divResult').html("");
                $('#divResult').html('<div id="outercontainer"><div id="innercontainer">' +
                    '<div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div><span>Loading...Please wait</span></div>' +
                    '</div></div>');
                $('#divResult').load('Restaurant/AddRestaurant');
                break;
            default:
                break;
        }
        //if (item === "menuAdmin") {
        //$("#Comments").load("@Url.Content("~/BookComments/Index?BookId=" + ViewBag.BookId)");           
        //$('#divResult').load('Restaurant/GetMenu/');
        //}
        return false;
    });

    var active = $('#restaurant li.active a').attr("data-id");
    //alert("active out = " + active);
    if (active) {
        //alert("active in = " + active);
        $('#divResult').load('Restaurant/GetRestaurant/' + active);
    }

    //    $(document).on('click', '#cancel', function () {
    //        $('form')[0].reset();

    //        $('form')[0].removeData("validator").removeData("unobtrusiveValidation");
    //        $.validator.unobtrusive.parse($("#divResult"));
    //    });    

    //    $(document).on('submit', 'form', function (e) {
    //        alert("outside");
    //        if (!Sys.Mvc.FormContext.getValidationForForm(this).validate('submit').length) {
    //            alert("inside");
    //            //$.post("/Home/CreateUserCompanyInformation", $(this).serialize(), function (data) {               
    //            //$("#dynamicData").html(data);                
    //            //});            
    //        }
    //        e.preventDefault();
    //        return false;
    //    });

});