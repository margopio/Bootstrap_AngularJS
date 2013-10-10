// Restaurant.js

$(document).ready(function () {
    //alert('Restaurant');

    $('#example').popover(
        {
            title: 'About',
            content: "<strong>Restaurant Profile Accordion and Add Restaurant Partial View are about integrating conventional ASP.NET MVC with Twitter Bootstrap.<br /><br />" +
                "Menu Administration is working around ASP.NET MVC to code Twitter Bootstrap modal input forms.<br /><br />" +
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
                $('#divResult').load('Restaurant/GetRestaurant/' + id);
                break;
            case "menuAdmin":
                $('#divResult').load('Restaurant/GetMenu');
                break;
            case "addRestaurant":
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

    //var active = $('li.active a').attr("data-id");
    //alert("active = " + active);

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