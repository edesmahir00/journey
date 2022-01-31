
$(".select2").select2({
    allowClear: true,
    placeholder: "Bir şehir seçiniz"
});


function changePlaces() {
    var from = $("#FromId").val();
    var to = $("#ToId").val();

    var fromText = $("#select2-FromId-container").html();
    var toText = $("#select2-ToId-container").html();

    $('#FromId').val(to);
    $('#ToId').val(from);

    $('#select2-FromId-container').html(toText);
    $('#select2-ToId-container').html(fromText);

    $('#FromId').trigger('change');
    $('#ToId').trigger('change');
}

function setDay(day) {
    var date = new Date();
    var currentDateToday = date.toISOString().slice(0, 10);

    var nextDay = new Date(date);
    nextDay.setDate(date.getDate() + 1);
    var currentDateTomorrow = nextDay.toISOString().slice(0, 10);

    if (day === "today") {
        $(".date-depart").val(currentDateToday);

    } else if (day === "tomorrow") {
        $(".date-depart").val(currentDateTomorrow);
    }

}

function searchTicket() {

}