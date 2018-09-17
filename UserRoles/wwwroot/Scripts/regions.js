//function that selects a state from a dropdown when country has been selected

    $(function () {
        $("#CountryId").change(function () {
            var countrieId = $(this).val();
            $.ajax({
                url: "/regions/getstatebyId",
                data: { 'Countryid': countrieId },
                datatype: "json",
                success: function (data) {
                    var ddlState = $("#StatesId");
                    var ddlCities = $("#CitiesId");

                    ddlState.empty();
                    ddlState.append($("<option></option>").val("").html("Select state..."));
                    ddlCities.empty();

                    $.each(data, function (val, text) {

                        ddlState.append(
                            $("<option></option>").val(text.value).html(text.text)
                        );
                    });

                }
            });
        });
    });


//function that selects a city from a dropdown when country has been selected

$(function () {
    $("#StatesId").change(function () {
        var stateId = $(this).val();
        $.ajax({
            url: "/regions/getcitybyId",
            data: { 'Stateid': stateId },
            datatype: "json",
            success: function (data) {
               
                var ddlCities = $("#CitiesId");
                ddlCities.empty();

                if (!$.isEmptyObject(data))
                {
                    ddlCities.append($("<option></option>").val("").html("Select city..."));
                }
                $.each(data, function (val, text) {

                    ddlCities.append(
                        $("<option></option>").val(text.value).html(text.text)
                    );
                });

            }
        });
    });
});