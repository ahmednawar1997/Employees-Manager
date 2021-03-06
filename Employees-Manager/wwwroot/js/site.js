﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var index = 2;
$('#add_vacation_btn').click(function () {

    let vacationHtml = "<div class='row'>\
        <div class='col-4 p-1'><input type = 'text' class='form-control' name = 'Employee.Vacations["+index+"].Vacation_Type' value = '' placeholder = 'Vacation Type' required/></div >\
            <div class='col-4 p-1'><input type='number' class='form-control' name='Employee.Vacations["+ index +"].Balance' value='0' min='0' placeholder='Balance'/></div>\
            <div class='col-3 p-1'><input type='number' class='form-control' name='Employee.Vacations["+ index +"].Used' value='0' min='0' placeholder='Used'/></div>\
            <div class='col-1'></div>\
        </div>";
    index++;
    $('#vacations_container').append(vacationHtml);

})

function removeVacation() {
    if (index > 2) {
        index--;
        console.log($('#vacations_container .row:last-child'))
        $('#vacations_container .row:last-child').remove();
    }
}

function fetchEmployee(id) {
    $.ajax({
        type: "GET",
        url: "/Employees/?handler=Employee",
        contentType: "application/json",
        dataType: "json",
        data: { id: id },
        success: function (Employee) {
            console.log(Employee);
            $('#requestTitle').text("Request Vacation for: " + Employee.name);
            $("#request_employee_id").val(Employee.id);
            $('#vacation_type_select').empty();
            Employee.vacations.forEach(function (vacation) {
                $('#vacation_type_select').append("<option selected value='" + vacation.vacation_Type + "'>" + vacation.vacation_Type + "</option>")
            });
        },
        failure: function (response) {
            alert(response);
        }
    });
}
