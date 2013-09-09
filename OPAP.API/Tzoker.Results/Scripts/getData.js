$(function () {
    $("#callAPI").click(function () {
        $("#result").empty();
        var URL2Call = $.trim($("#APIurl").html());
        console.log(URL2Call);
        $.ajax({
            type: "GET",
            url: URL2Call,
            cache: false,
            dataType: "json",
            success: onSuccess
        });
    });

    $("#result").ajaxError(function (event, request, settings, exception) {
        $("#result").html("Error Calling: " + settings.url + "<br />HTTP Code: " + request.status);
    });

    function onSuccess(data) {
        $(".modal").modal('show');
        $("#result").append(JSON.stringify(data, null, 4));
    }

    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
});
