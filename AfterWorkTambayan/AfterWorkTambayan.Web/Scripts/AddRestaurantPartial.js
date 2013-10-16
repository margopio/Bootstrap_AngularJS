// AddRestaurantPartial

var map;
function initialize() {
    var mapOptions = {
        zoom: 15,
        center: new google.maps.LatLng(14.5500, 121.0333),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map'), mapOptions);
}

$(document).ready(function () {
    //alert("AddRestaurantPartial");
        
    $('form').bind("keypress", function (e) {
        if (e.keyCode == 13) {
            return false;
        }
    });

    $('form').submit(function (e) {
        //e.preventDefault();
        if ($(this).valid()) {
            $('button[data-loading-text]').button('loading');
            $('div#am button').each(function () {
                if ($(this).hasClass('active')) {
                    var am = $(this).text();
                    //alert("am = " + am); 
                    var value = $('#Restaurant_OperationHrsFrom').val();
                    if (am === "AM") {
                        $('#Restaurant_OperationHrsFrom').val(value + " am");
                    } else {
                        $('#Restaurant_OperationHrsFrom').val(value + " pm");
                    }
                }
            });

            $('div#pm button').each(function () {
                if ($(this).hasClass('active')) {
                    var pm = $(this).text();
                    //alert("pm = " + pm); 
                    var value = $('#Restaurant_OperationHrsTo').val();
                    if (pm === "AM") {
                        $('#Restaurant_OperationHrsTo').val(value + " am");
                    } else {
                        $('#Restaurant_OperationHrsTo').val(value + " pm");
                    }
                }
            });

            //var formData = $(this).serialize();
            //alert("formData = " + formData);
            $.post('/Restaurant/AddRestaurant', $(this).serialize(), function (data) {
                if (data === "OK") {
                    window.location.href = "/Restaurant";
                } else {
                    $('#divResult').html('');
                    $('#divResult').slideUp();
                    $('#divResult').html(data);
                    $('#divResult').slideDown("slow");
                    $.validator.unobtrusive.parse($("#divResult"));
                }
                return false;
            });

        }
        return false;
    });

    $("#cancel").click(function (e) {
        $('form')[0].reset();
    });

    $("#previewMap").click(function () {
        var latitude = $.trim($('#Restaurant_Latitude').val());
        var longitude = $.trim($('#Restaurant_Longitude').val());
        if (latitude != "" && longitude != "") {
            //alert("latitude = " + latitude + " longitude = " + longitude);
            var newLatlng = new google.maps.LatLng(latitude, longitude);
            map.setCenter(newLatlng);
        }
    });

    initialize()  

});

