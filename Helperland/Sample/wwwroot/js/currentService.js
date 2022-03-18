var serviceRequestId;
var serviceIDForDialogCurrentService;

function rescheduleOpen(id) {
    console.log("function called");
    serviceRequestId = id;
    var popup = document.getElementById("reschedule");
    popup.style.display = "flex";
}

function cancelServiceOpen(id) {
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
            document.getElementById("displayCurrentServiceForCustomer").style.display = "none";
            var popup = document.getElementById("reschedule");
            popup.style.display = "none";
            showMsg("Service Rescheduled.");
            serviceRequestId = "";
            $("#right-container").html("Loading...").load('/customerDashboard/CurrentService');
        } else if (response.status == "Conflict") {
            hideLoader();
            document.getElementById("displayCurrentServiceForCustomer").style.display = "none";
            var popup = document.getElementById("reschedule");
            popup.style.display = "none";
            showMsg("Another service request has been assigned to the service provider on " + response.datePOST + " from " + response.startTimePOST + " to " + response.endTimePOST +". Either choose another date or pick up a different time slot.");
        } else {
            hideLoader();
            document.getElementById("displayCurrentServiceForCustomer").style.display = "none";
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
            document.getElementById("displayCurrentServiceForCustomer").style.display = "none";
            var popup = document.getElementById("cancelToast");
            popup.style.display = "none";
            showMsg("Service Canceld.");
            serviceRequestId = "";
            $("#right-container").html("Loading...").load('/customerDashboard/CurrentService');
        } else {
            document.getElementById("displayCurrentServiceForCustomer").style.display = "none";
            hideLoader();
            $("#Error").html("Something went wrong");
        }
    });
}

function closeCancel() {
    var popup = document.getElementById("cancelToast");
    popup.style.display = "none";
}

function showServiceDetailsForC(id,date) {
    showLoader();
    serviceIDForDialogCurrentService = id;
    var formData = new FormData();
    formData.append("serviceID", id);

    $.ajax({
        type: 'POST',
        url: '/customerDashboard/fetchServiceDetails',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayCurrentServiceForCustomer").style.display = "flex";
            var date1 = new Date(response.serviceData.serviceStartDate);
            var dd = String(date1.getDate()).padStart(2, '0');
            var mm = String(date1.getMonth() + 1).padStart(2, '0');
            var yyyy = date1.getFullYear();
            var newdate = dd + '/' + mm + '/' + yyyy;
            var time = date1.toLocaleTimeString();
            date1.setHours(date1.getHours() + response.serviceData.extraHours);
            date1.setHours(date1.getHours() + response.serviceData.serviceHours);
            var time2 = date1.toLocaleTimeString();
            var final = newdate + " " + time + " - " + time2;
            document.getElementById("dateTimeDisplayUS").innerHTML = final;
            var duration = (response.serviceData.serviceHours + response.serviceData.extraHours);

            if (response.serviceData.serviceRequestExtras.length == 0) {
                document.getElementById("extraULUS").innerHTML = "";
                var li = document.createElement("li");
                li.appendChild(document.createTextNode("No extra services."));
                document.getElementById("extraULUS").appendChild(li);
            } else {
                document.getElementById("extraULUS").innerHTML = "";
                for (var i = 0; i < response.serviceData.serviceRequestExtras.length; i++) {
                    var li = document.createElement("li");
                    li.appendChild(document.createTextNode(response.serviceData.serviceRequestExtras[i].serviceExtra.serviceExtraName));
                    document.getElementById("extraULUS").appendChild(li);
                }
            }

            document.getElementById("durationDisplayUS").innerHTML = duration;
            document.getElementById("customerNameDisplayUS").innerHTML = response.serviceData.user.firstName + " " + response.serviceData.user.lastName;
            document.getElementById("serviceAddressDisplayUS").innerHTML = response.serviceData.serviceRequestaddress.addressLine1 + " " + response.serviceData.serviceRequestaddress.addressLine2 + " , " + response.serviceData.serviceRequestaddress.city + " " + response.serviceData.serviceRequestaddress.postalCode;
            document.getElementById("serviceIdDisplayUS").innerHTML = response.serviceData.serviceRequestId;
            document.getElementById("paymentDisplayUS").innerHTML = response.serviceData.totalCost;
            document.getElementById("commentsDisplayUS").innerHTML = response.serviceData.comments;
            if (response.serviceData.hasPets) {
                var text = "I have pets at home";
            } else {
                var text = "I don't have pets at home";
            }
            document.getElementById("petsDisplayUS").innerHTML = text;
        }
    });
}

function reschedule() {
    console.log("fun called");
    serviceRequestId = serviceIDForDialogCurrentService;
    var popup = document.getElementById("reschedule");
    popup.style.display = "flex";
}

function cancelService() {
    serviceRequestId = serviceIDForDialogCurrentService;
    var popup = document.getElementById("cancelToast");
    popup.style.display = "flex";
}

function closeCurrentServiceForCustomer(){
    document.getElementById("displayCurrentServiceForCustomer").style.display = "none";
}