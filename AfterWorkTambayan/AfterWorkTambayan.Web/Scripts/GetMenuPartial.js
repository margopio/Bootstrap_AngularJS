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
                    $('button[data-loading-text]').button('reset');
                    alert("Something went wrong. Please retry!");
                }
            });
        }
        return false;
    });

    var add = false;
    var dataId, imageUrl, name, description;

    $('#add').click(function () {
        add = true;
    });

    $('#edit').click(function () {
        var chkSelector = 'tr td:nth-child(1) :checkbox';
        $('#menuTable ' + chkSelector).each(function () {
            var $this = $(this);
            if ($this.is(':checked')) {
                var $row = $this.closest('tr');
                dataId = $row.attr('data-category-id');
                imageUrl = $row.children('td:eq(1)').children('img').attr('src');
                name = $row.children('td:eq(2)').text();
                description = $row.children('td:eq(3)').text();
                //alert("dataId = " + dataId + " imageUrl = " + imageUrl + " name = " + name + " description = " + description);
                $('#modal').modal('show');
                return;
            }
        });
    });

    $('#modal').on('shown', function () {
        if (add === true) {
            $('#Category_CategoryId').val('');
            $('#Category_ImageUrl').val('');
            $('#Category_Name').val('');
            $('#Category_Description').val('');
            add = false;
        } else {
            $('#Category_CategoryId').val(dataId);
            $('#Category_ImageUrl').val(imageUrl);
            $('#Category_Name').val(name);
            $('#Category_Description').val(description);
            $('#iconImageUrl').attr("src", imageUrl);          
        }
    })

    $('#delete').click(function () {
        var chkSelector = 'tr td:nth-child(1) :checkbox';
        $('#menuTable ' + chkSelector).each(function () {
            var $this = $(this);
            if ($this.is(':checked')) {
                bootbox.confirm("<strong>Are you sure?</strong>", function (result) {
                    if (result) {
                        //alert("User confirmed dialog");
                        var $row = $this.closest('tr');
                        dataId = $row.attr('data-category-id');
                        //alert("dataId = " + dataId);                
                        var url = "/Restaurant/DeleteMenu/" + dataId;
                        $.post(url, function (data) {
                            if (data === "OK") {
                                //alert("Data deleted!");                        
                                $('#divResult').html('');
                                $('#divResult').load('Restaurant/GetMenu');
                                //return;
                            } else {
                                alert("Something went wrong. Please retry!");
                            }

                        });
                        return;
                    } else {
                        //alert("User declined dialog");
                    }
                });
            }
        });
    });

});