Index = {}

Index.Init = function () {
    $(document).ready(function () {
       
        $('#payer').empty();

        $.ajax({
            url: '/Home/GetAllMembers',
            type: 'GET',
            data: '',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var htmlString = '<option value=0> Default</option>';
                if (data.length > 0) {
                    
                    for (var i = 0; i < data.length; i++) {
                        htmlString = htmlString + '<option value=' + data[i].Value + '>'+ data[i].Text + '</option>';
                    }
                }
                $('#payer').append(htmlString);
                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('Request failed: ' + textStatus);
            }
        });
    });
   
}

Index.Add = function () {
    $(document).ready(function () {
        $("#add").on('click', function () {
          
            if (validate())
            {
              
                var obj = {
                    Name: $('#name').val(),
                    DateOfBirth: $("#dob").val(),
                    PayerId: $('#payer').val()
                };

                //wiring up our ajax function here
                $.ajax({
                    url: '/Home/AddMember',
                    type: 'POST',
                    data: JSON.stringify(obj),
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        if (data == true) {
                            location.href = '/Home/Index';
                        }
                        else {
                            alert('request failed, please try again later.');
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log('Request failed: ' + textStatus);
                    }
                });

            }
         
        });
    });
}

function validate() {
    var isValid = true;

    if ($("#name").val()=='') {
        $("#name").css('border-color', 'red');
        isValid = false;
    }
    else {
        $("#name").css('border-color', 'lightgrey');
    }

    if ($("#dob").val() == '') {

        $("#dob").css('border-color', 'red');
        isValid = false;
    }
    else {
        var start = new Date($('#dob').val());
        var end = new Date();

        // end - start returns difference in milliseconds 
        var diff = new Date(end - start);
        // get years
        var years = diff / 1000 / 60 / 60 / 24 / 365;

        if (years >= 18 && years <= 65) {
            $("#dob").css('border-color', 'lightgrey');
            $('#dobValidation').css('display', 'none')
        }
        else {
            $("#dob").css('border-color', 'red');
            $('#dobValidation').show()
            isValid = false;
        }

        $("#dob").css('border-color', 'lightgrey');
    }

    if ($("#payer").val() == '') {
        $("#payer").css('border-color', 'red');
        isValid = false;
    }
    else {
        $("#payer").css('border-color', 'lightgrey');
    }
    return isValid;
}