function changePic(x) {
    console.log("case01");

    switch (x) {
        case 0:
            var stringsrc = document.picture0.src;
            var startingchar = stringsrc.substr(stringsrc.length - 5);
            console.log(startingchar);
            if (startingchar === "3.png") {
                document.picture0.src = "images/3-green.png";
            } else {
                document.picture0.src = "images/3.png";
            }
            break;
        case 1:
            var stringsrc = document.picture1.src;
            var startingchar = stringsrc.substr(stringsrc.length - 5);
            console.log(startingchar);
            if (startingchar === "5.png") {
                document.picture1.src = "images/5-green.png";
            } else {
                document.picture1.src = "images/5.png";
            }
            break;
        case 2:
            var stringsrc = document.picture2.src;
            var startingchar = stringsrc.substr(stringsrc.length - 5);
            console.log(startingchar);
            if (startingchar === "4.png") {
                document.picture2.src = "images/4-green.png";
            } else {
                document.picture2.src = "images/4.png";
            }
            break;
        case 3:
            var stringsrc = document.picture3.src;
            var startingchar = stringsrc.substr(stringsrc.length - 5);
            console.log(startingchar);
            if (startingchar === "2.png") {
                document.picture3.src = "images/2-green.png";
            } else {
                document.picture3.src = "images/2.png";
            }
            break;
        case 4:
            var stringsrc = document.picture4.src;
            var startingchar = stringsrc.substr(stringsrc.length - 5);
            console.log(startingchar);
            if (startingchar === "1.png") {
                document.picture4.src = "images/1-green.png";
            } else {
                document.picture4.src = "images/1.png";
            }
            break;
        case 5:
            console.log("case01");
            var stringsrc = document.img01.src;
            var startingchar = stringsrc.substr(stringsrc.length - 17);
            console.log(startingchar);
            if (startingchar === "setup-service.png") {
                document.img01.src = "images/setup-service-white.png";
            } else {
                document.img01.src = "images/setup-service.png";
            }
            break;
        case 6:
            console.log("case01");
            var stringsrc = document.img02.src;
            var startingchar = stringsrc.substr(stringsrc.length - 12);
            console.log(startingchar);
            if (startingchar === "schedule.png") {
                document.img02.src = "images/schedule-white.png";
            } else {
                document.img02.src = "images/schedule.png";
            }
            break;
        case 7:
            console.log("case01");
            var stringsrc = document.img03.src;
            var startingchar = stringsrc.substr(stringsrc.length - 11);
            console.log(startingchar);
            if (startingchar === "details.png") {
                document.img03.src = "images/details-white.png";
            } else {
                document.img03.src = "images/details.png";
            }
            break;
        case 8:
            console.log("case01");
            var stringsrc = document.img04.src;
            var startingchar = stringsrc.substr(stringsrc.length - 11);
            console.log(startingchar);
            if (startingchar === "payment.png") {
                document.img04.src = "images/payment-white.png";
            } else {
                document.img04.src = "images/payment.png";
            }
            break;
    }
}

function add(value) {
    console.log(value);
    if (value === "addbutton") {
        var button = document.getElementById('addaddress');
        var div = document.getElementById('newaddress');

        button.style.display = "none";
        div.style.display = "flex";

    } else if (value === "removediv") {
        var button = document.getElementById('addaddress');
        var div = document.getElementById('newaddress');

        button.style.display = "block";
        div.style.display = "none";
    }
}