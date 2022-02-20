window.addEventListener('load', (event) => {
    console.log("function start");
    opensetuptab();
    popupFuction();

    var today = new Date();
    document.getElementById("datePick").value = today.getFullYear() + '-' + ('0' + (today.getMonth() + 1)).slice(-2) + '-' + ('0' + today.getDate()).slice(-2);
    document.getElementById("dateDisplay").innerHTML = ('0' + today.getDate()).slice(-2) + '-' + ('0' + (today.getMonth() + 1)).slice(-2) + '-' + today.getFullYear();
});

document.getElementById('startTime').onchange = function () {
    document.getElementById("timeDisplay").innerHTML = $('select#startTime option:selected').val();
};

document.getElementById('number-of-bed').onchange = function () {
    document.getElementById("bedDisplay").innerHTML = $('select#number-of-bed option:selected').val();
};

document.getElementById('number-of-bath').onchange = function () {
    document.getElementById("bathDisplay").innerHTML = $('select#number-of-bath option:selected').val();
};

document.getElementById('totalHRS').onchange = function () {
    document.getElementById("basicTime").innerHTML = $('select#totalHRS option:selected').val();
    updateTotal();
};
function updateTotal() {
    let basic = parseInt($('select#totalHRS option:selected').val());
    console.log(basic);
    var checkboxs = document.querySelectorAll('.ch');
    var count = 0;
    for (var i = 0; i < checkboxs.length; i++) {
        if (checkboxs[i].checked == true) {
            count = count + 1;
            basic = (basic + (30 / 60));
        }
    }
    if (count == 0) {
        document.getElementById("totaltimeDisplay").innerHTML = $('select#totalHRS option:selected').val();
        document.getElementById("perClean").innerHTML = Math.floor((parseInt($('select#totalHRS option:selected').val()) * 2034));
        document.getElementById("totalPayment").innerHTML = Math.floor((parseInt($('select#totalHRS option:selected').val()) * 2034));
        var discount = ((parseInt($('select#totalHRS option:selected').val()) * 2034) * 0.2);
        document.getElementById("discount").innerHTML = Math.floor(discount);
        document.getElementById("effectivePrice").innerHTML = Math.floor((parseInt($('select#totalHRS option:selected').val() * 2034) - discount));
    } else {
        document.getElementById("totaltimeDisplay").innerHTML = basic;
        document.getElementById("perClean").innerHTML = Math.floor((basic * 2034));
        document.getElementById("totalPayment").innerHTML = Math.floor((basic * 2034));
        var discount = ((basic * 2034) * 0.2);
        document.getElementById("discount").innerHTML = Math.floor(discount);
        document.getElementById("effectivePrice").innerHTML = Math.floor(((basic * 2034) - discount));
    }
}
function checkbox() {
    $('#extralist').empty();
    $('#extralistMin').empty();
var checkboxs = document.querySelectorAll('.ch');
    const values = [];
    var ul = document.getElementById("extralist");
    var ul1 = document.getElementById("extralistMin");
for (var i = 0; i < checkboxs.length; i++) {
    if (checkboxs[i].checked == true) {
        values.push(checkboxs[i].value);
        var li = document.createElement("li");
        var li1 = document.createElement("li");
        li1.appendChild(document.createTextNode("30 Mins"));
        ul1.appendChild(li1);
        li.appendChild(document.createTextNode(checkboxs[i].value + " (extra)"));
        ul.appendChild(li);
        updateTotal();
    }
    }
    updateTotal();
    console.log(values);
}
/*$(function () {
    $("#number-of-bed").change(function () {
        document.getElementById("timeDisplay").innerHTML = $('option:selected', this).text();
    });
    var date = new Date($('#datePick').val());
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    document.getElementById("dateDisplay").innerHTML = [day, month, year].join('/');
});*/

var servicetab = document.getElementById("servicetab");
var plantab = document.getElementById("plantab");
var detailstab = document.getElementById("detailstab");
var paymenttab = document.getElementById("paymenttab");

var modal2 = document.getElementById("myModal2");

var service = document.getElementById("setup");
var plan = document.getElementById("plan");
var details = document.getElementById("details");
var payment = document.getElementById("payment");

function login() {
    modal2.style.display = "block";
    //Set the URL.
    var url = $("#myForm").attr("action");

    //Add the Field values to FormData object.
    var formData = new FormData();
    formData.append("email", $("#email").val());
    formData.append("password", $("#password").val());

    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    if (email == "") {
        document.getElementById("emailerror").innerHTML = "Required";
    } else if (password == "") {
        document.getElementById("passworderror").innerHTML = "Required";
    } else {
        $.ajax({
            type: 'POST',
            url: '/bookservice/loginservice',
            data: formData,
            processData: false,
            contentType: false,
        }).done(function (response) {
            console.log(response+"11");
            if (response.status == "success") {
                var email = response.email;
                modal2.style.display = "none";
                opendetails(email);
            } else if (response.status == "fail") {
                $("#formerror").html("Email or Password are incorrect");
            } else if (response.status == "wrong") {
                $("#formerror").html("Only customers can access this part of the system");
            }
        });
    }
}

function openplan() {

    var formData = new FormData();
    formData.append("code", $("#postalID").val());
    var postalValue = document.getElementById("postalID").value;

    if (postalValue == "") {
        document.getElementById("postalError").innerHTML = "Required";
    } else {
    $.ajax({
        type: 'POST',
        url: '/bookservice/code',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            service.style.display = "none";
            plan.style.display = "block";
            plantab.classList.add("arrow-dwn");
            plantab.classList.add("bookService-active");
            servicetab.classList.remove("arrow-dwn");
            document.img02.src = "images/schedule-white.png";
        } else {
            $("#postalError").html("No Service provider are available");
        }
    });
    }

}

function bookingDone() {

    var postal = document.getElementById("postalID").value;
    var noOfBed = $('select#number-of-bed option:selected').val();
    var noOfBath = $('select#number-of-bath option:selected').val();
    var date = new Date($('#datePick').val());
    var time = document.getElementById('timeDisplay').innerText;
    console.log(date);
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0');
    var yyyy = date.getFullYear();
    var date1 = mm + '/' + dd + '/' + yyyy + " " + time;
    console.log(date1);
    var totalHrs = $('select#totalHRS option:selected').val();
    var totalHour = document.getElementById("totaltimeDisplay").innerText;
    console.log(totalHour);
    var extraHour = totalHour - totalHrs;
    var extra=[];

    var checkboxs = document.querySelectorAll('.ch');

    /*for (var i = 0; i < checkboxs.length; i++) {
        if (checkboxs[i].checked == true) {
            extra.push(checkboxs[i].id);
        }
    }*/

    $("input[name='extraService']:checked").each(function () { var id = $(this).attr("value"); extra.push(id); });
    var comments = $('#comments').val();
    var pets = $("input[name='pets']").is(':checked');
    var address = $('input[name="add"]:checked').val();
    var subtotal = document.getElementById('totalPayment').innerText;
    var discount = document.getElementById('discount').innerText;
    var totalAmount = document.getElementById('effectivePrice').innerText;
    console.log("subtotal= " + subtotal + "\ndiscount = " + discount + "\ntotalamount =" + totalAmount);
    console.log(extra);

    var formData = new FormData();
    formData.append("postal", postal);
    formData.append("noOfBed", noOfBed);
    formData.append("noOfBath", noOfBath);
    formData.append("date", date1);
    formData.append("totalHrs", totalHrs);
    formData.append("extraHrs", extraHour);
    formData.append("extra", extra);
    formData.append("comments", comments);
    formData.append("pets", pets);
    formData.append("address", address);
    formData.append("subtotal", subtotal);
    formData.append("discount", discount);
    formData.append("totalAmount", totalAmount);

    $.ajax({
        type: 'POST',
        url: '/bookservice/completeBook',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            showMsg("Request Added");
            window.location.href = '/bookservice';
        } else {
            alert("Something went wrong");
            window.location.href = '/bookservice';
        }
    });
}

function opendetails(email) {
    console.log("detail function");
    console.log(email);
    if (email == null || email == "") {
        login();
    } else {
        plan.style.display = "none";
        details.style.display = "block";
        detailstab.classList.add("bookService-active");
        detailstab.classList.add("arrow-dwn");
        plantab.classList.remove("arrow-dwn");
        document.img03.src = "images/details-white.png";
        plantab.removeAttribute('disabled');

        var noOfBed = $('select#number-of-bed option:selected').val();
        console.log(noOfBed);
        var noOfBath = $('select#number-of-bath option:selected').val();
        var date = new Date($('#datePick').val());
        console.log(date);
        var time = $('select#startTime option:selected').val();
        var totalHrs = $('select#totalHRS option:selected').val();
        var extra;
        $('input[type=checkbox]:checked').each(function () { var id = $(this).attr("value"); extra = extra + id; });
        console.log("bed" + noOfBed + "/nbath" + noOfBath + "/ndate" + date + "/ntime" + time + "/nHour" + totalHrs + "/ncheckbox" + extra);
        

        $("#address-container-id").html("Loading Address...").load('/bookservice/getaddress');
    }
}

function openpayment() {
    
    var checked_add = document.querySelector('input[name = "add"]:checked');

    if (checked_add != null) {
        details.style.display = "none";
        payment.style.display = "block";
        paymenttab.classList.add("bookService-active");
        paymenttab.classList.add("arrow-dwn");
        detailstab.classList.remove("arrow-dwn");
        document.img04.src = "images/payment-white.png";
        detailstab.removeAttribute('disabled');
    } else {
        alert('Nothing checked');
    }
}

function opensetuptab() {
    console.log("function setup");
    console.log(plantab);
    plantab.disabled = "true";
    detailstab.disabled = "true";
    paymenttab.disabled = "true";

    service.style.display = "block";
    plan.style.display = "none";
    details.style.display = "none";
    payment.style.display = "none";
    document.img01.src = "images/setup-service-white.png";
    plantab.classList.remove("bookService-active");
    plantab.classList.remove("arrow-dwn");
    detailstab.classList.remove("arrow-dwn");
    paymenttab.classList.remove("arrow-dwn");
    servicetab.classList.add("arrow-dwn");
    detailstab.classList.remove("bookService-active");
    paymenttab.classList.remove("bookService-active");
    document.img02.src = "images/schedule.png";
    document.img04.src = "images/payment.png";
    document.img03.src = "images/details.png";
}

function openplantab() {
    console.log("plan called");
    detailstab.disabled = "true";
    plantab.disabled = "true";
    detailstab.classList.remove("bookService-active");
    detailstab.classList.remove("arrow-dwn");
    plantab.classList.add("arrow-dwn");
    document.img03.src = "images/details.png";
    plan.style.display = "block";
    details.style.display = "none";
    paymenttab.classList.remove("bookService-active");
    paymenttab.classList.remove("arrow-dwn");
    document.img04.src = "images/payment.png";
    payment.style.display = "none";
}

function opendetailstab() {
    paymenttab.disabled = "true";
    paymenttab.classList.remove("bookService-active");
    paymenttab.classList.remove("arrow-dwn");
    detailstab.classList.add("arrow-dwn");
    document.img04.src = "images/payment.png";
    details.style.display = "block";
    payment.style.display = "none";
}

function saveAddress() {
    var formData = new FormData();
    formData.append("add1", $("#add1").val());
    formData.append("add2", $("#add2").val());
    formData.append("pscode", $("#pscode").val());
    formData.append("city", $("#city").val());
    formData.append("number", $("#number").val());

    $.ajax({
        type: 'POST',
        url: '/bookservice/addaddress',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            alert("Address Added");
            $("#address-container-id").html("Loading Address view...").load('/bookservice/getaddress');
            $("#newaddress").hide();
        } else {
            alert("Someting went wrong");
        }
    });
}