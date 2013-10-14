// GetRestaurantPartial

$(document).ready(function () {
    //alert("GetRestaurantPartial");

    //$('#map').goMap(); 

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

            $.post('/Restaurant/GetRestaurant', $(this).serialize(), function (data) {
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

    $('div#am button').each(function () {
        //alert("AM");
        var $this = $(this);
        if ($this.text() === 'AM') {
            $this.addClass('active');
        }
    });

    $('div#pm button').each(function () {
        //alert("PM");
        var $this = $(this);
        if ($this.text() === 'PM') {
            $this.addClass('active');
        }
    });

    $("#cancel").click(function (e) {
        $('form')[0].reset();
    });    

});

