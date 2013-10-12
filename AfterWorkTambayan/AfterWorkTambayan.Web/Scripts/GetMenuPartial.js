// GetMenuPartial

$(document).ready(function () {
    //alert("GetMenuPartial");
    $('#iconImageUrl').click(function (e) {
        var imageUrl = $('#Category_ImageUrl').val();
        if (imageUrl) {
            $('#iconImageUrl').attr("src", imageUrl);
        }
    });

    $('form').submit(function (e) {
        if ($(this).valid()) {
            $('button[data-loading-text]').button('loading');
            var url = "/Restaurant/GetMenu";
            var postData = $(this).serialize();
            //alert("postData =  " + postData);
            $.post(url, postData, function (data) {
                if (data === "OK") {
                    //alert("Data saved!");
                    $('#modal').modal('hide');
                    $('#divResult').html('');
                    $('#divResult').load('Restaurant/GetMenu');
                    //return;
                } else {
                    alert("Something went wrong. Please retry!");
                }
            });
        }
        return false;
    });

    //   $('form').validate({
    //        rules: {
    //            ImageUrl: { required: true, minlength: 4 },
    //            Name: { required: true, minlength: 4 },
    //            Description: { required: true, minlength: 4 }
    //        },
    //        messages: {
    //            Name: "Name title is required (at least 4 chars).",
    //            Description: "Description is required is required (at least 10 chars)."
    //        },
    //        errorContainer: "#validationSummary",
    //        errorLabelContainer: "#validationSummary ul",
    //        wrapper: "li"
    //        highlight: function (element) {
    //            $(element).closest('.control-group')
    //                .removeClass('success').addClass('error');
    //        },
    //        success: function (element) {
    //            element
    //                .addClass('valid').closest('.control-group')
    //                .removeClass('error').addClass('success');
    //        },
    //        submitHandler: function (form) {
    //            var url = "/Restaurant/GetMenu";
    //            var postData = form.serialize();
    //            alert("postData = " + postData);
    //            $.post(url, postData, function (data) {
    //                if (data.toLowerCase() == "OK") {
    //                    alert("Data saved!");
    //                    return;
    //                }
    //                alert("Something went wrong. Please retry!");
    //            });
    //            return false;
    //        }
    //  });

});