var serviceRequestId;

function reschedule(id) {
    serviceRequestId = id;
    var popup = document.getElementById("reschedule");
    popup.style.display = "flex";
}

function cancelService(id) {
    serviceRequestId = id;
    var popup = document.getElementById("cancelToast");
    popup.style.display = "flex";
}

function reschedulePost() {
    showLoader();
    var formData = new FormData();
    formData.append("id", serviceRequestId);

    var date = new Date($('#datePick').val());
    var time = $('select#timeService option:selected').val();
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0');
    var yyyy = date.getFullYear();
    var date1 = mm + '/' + dd + '/' + yyyy + " " + time;
    formData.append("date", date1);

    $.ajax({
        type: 'POST',
        url: '/customerDashboard/reschedule',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            var popup = document.getElementById("reschedule");
            popup.style.display = "none";
            showMsg("Service Rescheduled.");
            serviceRequestId = "";
            $("#right-container").html("Loading...").load('/customerDashboard/CurrentService');
        } else {
            hideLoader();
            $("#Error").html("Something went wrong");
        }
    });
}

function closeRescchedule() {
    var popup = document.getElementById("reschedule");
    popup.style.display = "none";
}

function cancelPost() {
    showLoader();
    var formData = new FormData();
    formData.append("id", serviceRequestId);
    var message = $('#reason').val();
    formData.append("message", message);

    $.ajax({
        type: 'POST',
        url: '/customerDashboard/cancel',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        hideLoader();
        if (response.status == "success") {
            var popup = document.getElementById("cancelToast");
            popup.style.display = "none";
            showMsg("Service Canceld.");
            serviceRequestId = "";
            $("#right-container").html("Loading...").load('/customerDashboard/CurrentService');
        } else {
            hideLoader();
            $("#Error").html("Something went wrong");
        }
    });
}

function closeCancel() {
    var popup = document.getElementById("cancelToast");
    popup.style.display = "none";
}