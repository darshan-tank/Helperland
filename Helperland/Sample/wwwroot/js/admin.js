window.addEventListener('load', (event) => {
    loadDropDowns();
    loadDropDownsUM();
});

var EditID;

function loadDropDowns() {
    $.ajax({
        type: 'GET',
        url: '/adminDashboard/fetchCustomers',
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            var list = document.getElementById('Customernames');
            for (var i = 0; i < response.userData.length; i++) {
                var option = document.createElement("option");
                option.text = response.userData[i].firstName + " " + response.userData[i].lastName;
                option.value = response.userData[i].email;
                list.add(option);
            }
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
    $.ajax({
        type: 'GET',
        url: '/adminDashboard/fetchProviders',
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            var list = document.getElementById('Provdernames');
            for (var i = 0; i < response.userData.length; i++) {
                var option = document.createElement("option");
                option.text = response.userData[i].firstName + " " + response.userData[i].lastName;
                option.value = response.userData[i].email;
                list.add(option);
            }
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function openModel(id) {
    EditID = id;
    document.getElementById("Reschedule").style.display = "block";

    var formData = new FormData();
    formData.append("ServiceID", id);
    $.ajax({
        type: 'POST',
        url: '/adminDashboard/fetchServiceDetail',
        data: formData,
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            var data = response.userData;
            console.log(data);
            console.log(response.userData);
            var today = new Date();
            document.getElementById("date").value = today.getFullYear() + '-' + ('0' + (today.getMonth() + 1)).slice(-2) + '-' + ('0' + today.getDate()).slice(-2);
            document.getElementById("streetName").value = data.serviceRequestaddress.addressLine1;
            document.getElementById("houseNumber").value = data.serviceRequestaddress.addressLine2;
            document.getElementById("postalCode").value = data.serviceRequestaddress.postalCode;
            document.getElementById("phoneNumber").value = data.serviceRequestaddress.mobile;
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function removeModel() {
    document.getElementById("Reschedule").style.display = "none";
}

function EditNReschedule() {

    var date = new Date($('#date').val());
    var time = $('select#timeService option:selected').val();
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0');
    var yyyy = date.getFullYear();
    var date1 = mm + '/' + dd + '/' + yyyy + " " + time;

    var formData = new FormData();
    formData.append("ServiceID", EditID);
    formData.append("date", date1);
    formData.append("streetName", $('#streetName').val());
    formData.append("houseNumber", $('#houseNumber').val());
    formData.append("postalCode", $('#postalCode').val());
    formData.append("phoneNumber", $('#phoneNumber').val());
    formData.append("city", $('select#city option:selected').val());

    $.ajax({
        type: 'POST',
        url: '/adminDashboard/saveServiceDetail',
        data: formData,
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("Reschedule").style.display = "none";
            window.location.href = "adminDashboard";
            showMsg("Service Rescheduled.");
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function cancelService(id) {

    var formData = new FormData();
    formData.append("ServiceID", id);

    $.ajax({
        type: 'POST',
        url: '/adminDashboard/cancelService',
        data: formData,
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            document.getElementById("Reschedule").style.display = "none";
            window.location.href = "/adminDashboard";
            showMsg("Service Rescheduled.");
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function deactivateUser(id) {
    showLoader();
    var formData = new FormData();
    formData.append("UserID", id);

    $.ajax({
        type: 'POST',
        url: '/adminDashboard/deactivateUser',
        data: formData,
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            window.location.href = "/adminDashboard/userManagment";
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function activateUser(id) {
    showLoader();
    var formData = new FormData();
    formData.append("UserID", id);

    $.ajax({
        type: 'POST',
        url: '/adminDashboard/activateUser',
        data: formData,
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            window.location.href = "/adminDashboard/userManagment";
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}

function loadDropDownsUM() {
    $.ajax({
        type: 'GET',
        url: '/adminDashboard/fetchUsers',
        processData: false,
        contentType: false,
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            var list = document.getElementById('CustomernamesUM');
            for (var i = 0; i < response.userData.length; i++) {
                var option = document.createElement("option");
                option.text = response.userData[i].firstName + " " + response.userData[i].lastName;
                option.value = response.userData[i].email;
                list.add(option);
            }
            var listEmail = document.getElementById('UserEmailUM');
            for (var i = 0; i < response.userData.length; i++) {
                var option = document.createElement("option");
                option.text = response.userData[i].email;
                option.value = response.userData[i].email;
                listEmail.add(option);
            }
        } else {
            hideLoader();
            showMsg("Something went wrong.");
        }
    });
}