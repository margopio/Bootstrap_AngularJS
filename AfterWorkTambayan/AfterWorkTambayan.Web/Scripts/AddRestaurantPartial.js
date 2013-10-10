// AddRestaurantPartial

$(document).ready(function () {
    //alert("AddRestaurantPartial");
    $('form').submit(function (e) {
        //e.preventDefault();
        if ($(this).valid()) {
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
                //alert("data = " + data);
                if (data === "OK") {
                    window.location.href = "/Restaurant";
                } else {
                    $('#divResult').html('');
                    $('#divResult').slideUp();
                    $('#divResult').html(data);
                    $('#divResult').slideDown("slow");
                    $.validator.unobtrusive.parse($("#divResult"));
                }
            });

        }
        return false;
    });

    $("#cancel").click(function (e) {
        $('form')[0].reset();
    });

});

