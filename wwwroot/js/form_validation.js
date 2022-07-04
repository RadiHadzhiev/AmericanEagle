
window.onload = function () {

    let dateForm = document.getElementById("dateForm");
    let pictureDate = document.getElementById("pictureDate");

    if (dateForm != null) {
        dateForm.addEventListener('submit', validate_input);
    }
    if (pictureDate != null) {
        pictureDate.addEventListener("submit", check_date);
    }
    

}

function validate_input(e) {

    let endDate = new Date(document.getElementById('endDatetbl').value);
    let startDate = new Date(document.getElementById('startDatetbl').value);

    let days_diff = Math.floor((endDate - startDate) / (1000 * 60 * 60 * 24));

    if (endDate < startDate) {

        alert('End date cannot be before star date');
        e.preventDefault();
        return false;
    }

    if (days_diff > 7) {

        alert('Date range can be maximum of 7 days');
        e.preventDefault();
        return false;
    }

    return true;
}


function check_date(e) {

    let selectedDate = new Date(document.getElementById("dateInput").value);
    let today = new Date();

    if (selectedDate > today) {
        alert("I don't know what the future holds");
        e.preventDefault();
        return false;
    }

    return true;

}