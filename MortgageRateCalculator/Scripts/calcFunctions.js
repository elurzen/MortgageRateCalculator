var uri = 'api/Calc/';

function calcRate() {
    $("#creditScore").css("background-color", "white");
    $("#term").css("background-color", "white");
    $("#rate").text("");

    var validVals = true;
    var cs = $('#creditScore').val();
    var t = $('#term').val();

    if (cs < 300 || cs > 850) {
        $("#creditScore").css("background-color", "lightpink");
        validVals = false;
    }

    if (t < 8 || t > 30) {
        $("#term").css("background-color", "lightpink");
        validVals = false;
    }

    if (validVals) {
        $.ajax({
            url: uri + 'calculateRate',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: { creditScore: cs, term: t },
            success: function (data) {
                $('#rate').text((data.toFixed(3)));
            },
            error: function (err) {
                var error;
                error = err.responseText.replace(/\\n/g, "\n");
                alert(error);
            }
        });
    }
}

function openRocketHq() {
    window.open("https://www.rockethq.com/#");
}

$(window).resize(function () {
    //hacky fix to get info icons to resize properly
    $('#calcTable').hide().show(0);
});