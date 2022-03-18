window.addEventListener('load', (event) => {
    openNewServiceRequest();
});

var serviceIDForDialogNewService;
var serviceIDForDialogUpcomingService;

function openUpcomingService() {
    $("#right-container").html("Loading Address...").load('/spDashboard/UpcomingService');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    document.getElementById("upcomingServiceLI").classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    document.getElementById("UpcomingServiceLI").classList.add("active-li-menu");
}

function openNewServiceRequest() {
    $("#right-container").html("Loading Address...").load('/spDashboard/dashboard');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    document.getElementById("dashboardLI").classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    document.getElementById("DashboardLI").classList.add("active-li-menu");
}

function openServiceSchedule() {
    $("#right-container").html("Loading...").load('/spDashboard/ServiceSchedule');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("ServiceScheduleLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("serviceScheduleMenuLI");
    currentMenu.classList.add("active-li-menu");
}

function openServiceScheduleHistory() {
    $("#right-container").html("Loading...").load('/spDashboard/ServiceHistory');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("serviceHistoryLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("ServiceHistoryLI");
    currentMenu.classList.add("active-li-menu");
}

function openMyRatings() {
    $("#right-container").html("Loading...").load('/spDashboard/MyRating');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("myRatingsLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("MyRatingsLI");
    currentMenu.classList.add("active-li-menu");
}

function openBlockCustomer() {
    $("#right-container").html("Loading...").load('/spDashboard/BlockCustomer');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("blockCustomerLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("BlockCustomerLI");
    currentMenu.classList.add("active-li-menu");
}

function acceptService(id) {
    document.getElementById("displayNewServiceForSP").style.display = "none";
    var ServiceId = id;
    var formData = new FormData();
    formData.append("serviceID", ServiceId);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/acceptService',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("Service Request : " + ServiceId + " Accepted.");
            setTimeout(function () {
                window.location.href = "/spDashboard";
            }, 6000);
        } else if (response.status == "fail") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("Something went wrong.");
        } else if (response.status == "Error") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("This service request is no more available. It has been assigned to another provider.");
        } else if (response.status == "Conflict") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("Another service request has already been assigned which has time overlap with this service request. You can’t pick this one.");
        }
    });
}

function PetsToggel() {
    if (document.getElementById('petsCheckbox').checked) {
        var items = document.getElementsByClassName("True");
        for (var i = 0; i < items.length; i++) {
            items[i].style.setProperty('display', 'table-row', 'important');
        }
    } else {
        var items = document.getElementsByClassName("True");
        for (var i = 0; i < items.length; i++) {
            items[i].style.setProperty('display', 'none', 'important');
        }
    }
}

function showServiceDetails(id) {
    showLoader();
    serviceIDForDialogNewService = id;
    var formData = new FormData();
    formData.append("serviceID", id);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/fetchServiceDetails',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "flex";
            document.getElementById("containerService").style.alignItems = "flex-start";
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
            document.getElementById("dateTimeDisplay").innerHTML = final;
            var duration = (response.serviceData.serviceHours + response.serviceData.extraHours);

            if (response.serviceData.serviceRequestExtras.length == 0) {
                document.getElementById("extraUL").innerHTML = "";
                var li = document.createElement("li");
                li.appendChild(document.createTextNode("No extra services."));
                document.getElementById("extraUL").appendChild(li);
            } else {
                document.getElementById("extraUL").innerHTML = "";
                for (var i = 0; i < response.serviceData.serviceRequestExtras.length; i++) {
                    var li = document.createElement("li");
                    li.appendChild(document.createTextNode(response.serviceData.serviceRequestExtras[i].serviceExtra.serviceExtraName));
                    document.getElementById("extraUL").appendChild(li);
                }
            }

            document.getElementById("durationDisplay").innerHTML = duration;
            document.getElementById("customerNameDisplay").innerHTML = response.serviceData.user.firstName + " " + response.serviceData.user.lastName;
            document.getElementById("serviceAddressDisplay").innerHTML = response.serviceData.serviceRequestaddress.addressLine1 + " " + response.serviceData.serviceRequestaddress.addressLine2 + " , " + response.serviceData.serviceRequestaddress.city + " " + response.serviceData.serviceRequestaddress.postalCode;
            document.getElementById("serviceIdDisplay").innerHTML = response.serviceData.serviceRequestId;
            document.getElementById("paymentDisplay").innerHTML = response.serviceData.totalCost;
            document.getElementById("commentsDisplay").innerHTML = response.serviceData.comments;
            if (response.serviceData.hasPets) {
                var text = "I have pets at home";
            } else {
                var text = "I don't have pets at home";
            }
            document.getElementById("petsDisplay").innerHTML = text;
        } 
    });
}

function closeNewServiceRequest() {
    document.getElementById("displayNewServiceForSP").style.display = "none";
}

function acceptServiceFromDialog() {
    var formData = new FormData();
    formData.append("serviceID", serviceIDForDialogNewService);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/acceptService',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("Service Request : " + serviceIDForDialogNewService +" Accepted.");
            setTimeout(function () {
                window.location.href = "/spDashboard";
            }, 6000);
        } else if (response.status == "fail") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("Something went wrong.");
        } else if (response.status == "Error") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("This service request is no more available. It has been assigned to another provider.");
        } else if (response.status == "Conflict") {
            hideLoader();
            document.getElementById("displayNewServiceForSP").style.display = "none";
            showMsg("Another service request has already been assigned which has time overlap with this service request. You can’t pick this one.");
        }
    });
}

function showServiceDetailsForUS(id,date) {
    showLoader();
    serviceIDForDialogUpcomingService = id;

    var formData = new FormData();
    formData.append("serviceID", id);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/fetchServiceDetails',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayUpcomingServiceForSP").style.display = "flex";
            var date1 = new Date(response.serviceData.serviceStartDate);
            var dd = String(date1.getDate()).padStart(2, '0');
            var mm = String(date1.getMonth() + 1).padStart(2, '0');
            var yyyy = date1.getFullYear();
            var newdate = dd + '/' + mm + '/' + yyyy;
            var time = date1.toLocaleTimeString();
            date1.setHours(date1.getHours() + response.serviceData.extraHours);
            date1.setHours(date1.getHours() + response.serviceData.serviceHours);
            if (date1 < new Date(date)) {
                document.getElementById("completeButton").disabled = false;
            } else {
                document.getElementById("cancelButton").disabled = false;
            }
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

function closeUpcomingServiceRequest() {
    document.getElementById("displayUpcomingServiceForSP").style.display = "none";
}

function CompleteService(id) {
    document.getElementById("displayUpcomingServiceForSP").style.display = "none";
    var formData = new FormData();
    formData.append("serviceID", id);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/completeService',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayUpcomingServiceForSP").style.display = "none";
            showMsg("Service Request :" + id + " completed.");
        } else {
            showMsg("Something went wrong.");
        }
    });
}

function CancelService(id) {
    document.getElementById("displayUpcomingServiceForSP").style.display = "none";
    var formData = new FormData();
    formData.append("serviceID", id);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/cancelService',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayUpcomingServiceForSP").style.display = "none";
            showMsg("Service Request : " + id + " canceled.");
        } else {
            showMsg("Something went wrong.");
        }
    });
}
function CompleteServiceUS() {

    var formData = new FormData();
    formData.append("serviceID", serviceIDForDialogUpcomingService);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/completeService',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayUpcomingServiceForSP").style.display = "none";
            showMsg("Service Request :" + serviceIDForDialogUpcomingService +" completed.");
        } else {
            showMsg("Something went wrong.");
        }
    });
}

function CancelServiceUS() {

    var formData = new FormData();
    formData.append("serviceID", serviceIDForDialogUpcomingService);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/cancelService',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayUpcomingServiceForSP").style.display = "none";
            showMsg("Service Request : " + serviceIDForDialogUpcomingService +" canceled.");
        } else {
            showMsg("Something went wrong.");
        }
    });
}

function openModelForServiceHistory(id) {
    showLoader();
    var formData = new FormData();
    formData.append("serviceID", id);

    $.ajax({
        type: 'POST',
        url: '/spDashboard/getServiceDetail',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("displayServiceHistoryC").style.display = "flex";
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
            document.getElementById("dateTimeDisplayC").innerHTML = final;
            document.getElementById("customerNameDisplayC").innerHTML = response.serviceData.user.firstName + " " + response.serviceData.user.lastName;
            document.getElementById("serviceAddressDisplayC").innerHTML = response.serviceData.serviceRequestaddress.addressLine1 + " " + response.serviceData.serviceRequestaddress.addressLine2 + " , " + response.serviceData.serviceRequestaddress.city + " " + response.serviceData.serviceRequestaddress.postalCode;
            document.getElementById("serviceIdDisplayC").innerHTML = response.serviceData.serviceRequestId;
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function closeServiceHistory() {
    document.getElementById("displayServiceHistoryC").style.display = "none";
}