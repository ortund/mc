$(".datefield").datepicker();

$("input[type=text]").on("blur", function () {
    var span = $("span." + $(this).attr("id"));
    SetFieldText($(this), span);
});

$("input[type=checkbox]").change(function () {
    var span = $("span." + $(this).attr("class"));

    if (this.checked) {
        RemoveValue(span);
    }
});

function SetFieldText(e, span) {
    span.html(e.val() + "|");
}
function RemoveValue(span) {
    span.html("|"); // Remove the value but keep the field.
}
function RemoveField(span) {
    span.html(""); // Remove the value and the field.
}