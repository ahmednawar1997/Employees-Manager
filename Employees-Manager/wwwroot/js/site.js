// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var index = 2;
$('#add_vacation_btn').click(function () {

    let vacationHtml = "<div class='row'>\
        <div class='col-4 p-1'><input type = 'text' class='form-control' name = 'Employee.Vacations["+index+"].Vacation_Type' value = '' placeholder = 'Vacation Type' /></div >\
            <div class='col-4 p-1'><input type='number' class='form-control' name='Employee.Vacations["+ index +"].Balance' value='' min='0' placeholder='Balance'/></div>\
            <div class='col-3 p-1'><input type='number' class='form-control' name='Employee.Vacations["+ index +"].Used' value='' min='0' placeholder='Used'/></div>\
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
