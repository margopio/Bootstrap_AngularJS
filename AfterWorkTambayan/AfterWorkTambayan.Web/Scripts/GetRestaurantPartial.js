﻿// GetRestaurantPartial

$(document).ready(function () {
    //alert("GetRestaurantPartial");
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
            $.post('/Restaurant/GetRestaurant', $(this).serialize(), function (data) {
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

});

