/*
This library holds user defined jquery function for Cts.Mvc.ExpenseReport
*/

(function ($) {

    $('.datepicker').datepicker();

    $('.miles, .amount').blur(function () {
        var factor = .55;
        var miles = parseInt($('.miles').val());

        $('.mileage').val((miles * factor).toFixed(2));

        var amount = parseFloat($('.amount').val());
        var mileage = parseFloat($('.mileage').val());

        $('.total').val(parseFloat(amount + mileage).toFixed(2));

    });

    $("#search").click(function () {
        $("#log").ajaxError(function (event, jqxhr, settings, exception) {
            alert(exception);
        });

        if ($(this).valid()) {

            var employee = $("select option:selected").first().val();
            var dateFrom = new Date($('#DateFrom').val());
            var dateTo = new Date($('#DateTo').val());

            $('.errorMessage').hide();
            $('.employeeError').hide();
            $('.dateError').hide();

            if (dateTo < dateFrom) {
                $('.errorMessage').show();
                $('.dateError').show();
            };

            if (employee.length == 0) {
                $('.errorMessage').show();
                $('.employeeError').show();
            } else {
                $.get('/Entries/EntriesByEmployee', { id: employee, fromDate: $('#DateFrom').val(), toDate: $('#DateTo').val() }, function (data) {
                    $("#target").html(data);
                });
            }
        }
    });
    
})(jQuery);