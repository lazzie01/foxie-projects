Calculator = {}

var ownPremiumPayer = false;
Calculator.Init = function () {
    $(document).ready(function () {

        $('#memberName').empty();
        $.ajax({
            url: '/Home/GetAllMembers',
            type: 'GET',
            data: '',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var htmlString = '<option value=0> Select Member</option>';
                if (data.length > 0) {

                    for (var i = 0; i < data.length; i++) {
                        htmlString = htmlString + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                    }
                }
                $('#memberName').append(htmlString);

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('Request failed: ' + textStatus);
            }
        });

        var premId = -1;
        $('#memberName').on('change', function () {
          
                $('#memberId').val($('#memberName').val());
                var memberName = $('#memberName').val();
                $.ajax({
                    url: '/Home/GetPremiumPayerId?id=' + memberName,
                    type: 'GET',
                    data: '',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        premId = data;
                        $('#premiumPayerId').val(data);

                        if (premId > -1) {
                            if (premId == memberName) {
                                $('#insuredValue').empty();
                                ownPremiumPayer = true;
                                callAjax(ownPremiumPayer);
                            }
                            else {
                                $('#insuredValue').empty();
                                ownPremiumPayer = false;
                                callAjax(ownPremiumPayer);
                            }
                        }
                        else {
                                $('#insuredValue').empty();
                              }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log('Request failed: ' + textStatus);
                    }
                });  
        });

       

    });
}

Calculator.Evaluate = function () {
    $(document).ready(function () {

        $('#addBtn').on('click', function () {
            if (validate())
            {
                $.ajax({
                    url: '/Home/Calculate?memberId=' + $('#memberName').val()
                        + '&insuredId=' + $('#insuredValue').val()
                        + '&ownPremiumPayer=' + ownPremiumPayer,
                    type: 'GET',
                    data: '',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        $('#policyFeeId').val(data[0]);
                        $('#premiumId').val(data[1]);
                        $('#totalId').val(data[2]);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log('Request failed: ' + textStatus);
                    }
                });  
            }
        });
    });
}

Calculator.History = function () {
    $(document).ready(function () {
        
        $('#historyId').on('click', function () {
            
            if ($('#memberName').val() != 0) {
                $.ajax({
                    url: '/Home/History?id=' + $('#memberName').val(),
                    type: 'GET',
                    data: '',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {

                        $('#tableHeading').show();
                        $('#premiumHistory').empty();
                        var tableHead = '<thead><tr> <th>Date</th> <th>Sum Insured (R)</th> <th>Policy Fee (R)</th> <th>Premium (R)</th> <th>Total (R)</th> </tr></thead>';
                        var tableBody = tableHead + '<tbody>';
                        for (var i = 0; i < data.length; i++) {
                            tableBody = tableBody + '<tr> <td>' + data[i].Date + '</td> <td>' + data[i].Insured + '</td> <td>' + data[i].PolicyFee + '</td><td>' + data[i].Premium + '</td><td>' + (data[i].PolicyFee + data[i].Premium) + '</td> </tr>';
                        }
                        tableBody = tableBody + '</tbody>';
                        $('#premiumHistory').append(tableBody);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log('Request failed: ' + textStatus);
                    }
                });
            }
            else {
                $('#tableHeading').hide();
                $('#premiumHistory').empty();
            }
            });
       
    });
}

function validate() {
    var isValid = true;

    if ($("#memberName").children('option:selected').val() == '0') {
        $("#memberName").css('border-color', 'red');
        isValid = false;
    }
    else {
        $("#memberName").css('border-color', 'lightgrey');
    }

    if ($("#insuredValue").children('option:selected').val() == '0') {
        $("#insuredValue").css('border-color', 'red');
        isValid = false;
    }
    else {
        $("#insuredValue").css('border-color', 'lightgrey');
    }
    return isValid;
}

function callAjax(ownPremiumPayer) {
    $.ajax({
        url: '/Home/GetInsuredSums?ownPremiumPayer=' + ownPremiumPayer,
        type: 'GET',
        data: '',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var htmlString = '<option value=0>Insured Sum</option>';
            if (data.length > 0) {

                for (var i = 0; i < data.length; i++) {
                    htmlString = htmlString + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                }
            }
            $('#insuredValue').append(htmlString);

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('Request failed: ' + textStatus);
        }
    });
}