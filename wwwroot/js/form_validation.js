window.validate_input = function () {

    var form = document.getElementsByName("dateForm");

    if (form.getElementsByName("endDate") < form.getElementsByName("startDate")) {

        alert("End date cannot be before star date");

        return false;
    }

    return true;
}
