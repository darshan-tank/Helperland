var serviceProviderID;
var customerID;
var rating1 = 0;
var rating2 = 0;
var rating3 = 0;
var serviceRequestId;

function rateSP(Providerid,CustomerID,ServiceRequestID) {
    serviceProviderID = Providerid;
    customerID = CustomerID;
    serviceRequestId = ServiceRequestID;

    var popup = document.getElementById("rate");
    popup.style.display = "flex";

    var formData = new FormData();
    formData.append("providerID", serviceProviderID);
    formData.append("customerID", customerID);

    $.ajax({
        type: 'POST',
        url: '/customerDashboard/checkFavorite',
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            var favButton = document.getElementById("unfavoriteButton");
            favButton.style.display = "block";
        } else {
            console.log(document.getElementById("favoriteButton"));
            var favButton = document.getElementById("favoriteButton");
            favButton.style.display = "block";
        }
    });

    var formDataforName = new FormData();
    formDataforName.append("providerID", serviceProviderID);
    formDataforName.append("serviceRequestID", serviceRequestId);
    $.ajax({
        type: 'POST',
        url: '/customerDashboard/getProviderName',
        data: formDataforName,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            console.log(response);
            var rating = response.ratingObject;
            var user = response.user;
            var NameDisplay = document.getElementById("ServiceProviderName");
            NameDisplay.textContent = user.firstName + " " + user.lastName;
            readyRating(response.finalrate, response.ratingObject.onTimeArrival, response.ratingObject.friendly, response.ratingObject.qualityOfService, "true");
            var ratingDisplay = document.getElementById("ratingDisplay");
            ratingDisplay.textContent = response.finalrate;
            var textArea = document.getElementById("feedback");
            if (response.ratingObject.comments == null) {
                textArea.value = "No comments was added by customer.";
                textArea.disabled = true;
                document.getElementById("submitRatings").disabled = true;
            } else {
                textArea.value = response.ratingObject.comments;
                textArea.disabled = true;
                document.getElementById("submitRatings").disabled = true;
            }
            
        } else {
            console.log(response);
            var user = response.user;
            var NameDisplay = document.getElementById("ServiceProviderName");
            console.log(user.firstName + " " + user.lastName);
            NameDisplay.textContent = user.firstName + " " + user.lastName;
            readyRating(response.finalrate, 0, 0, 0, "false");
            var ratingDisplay = document.getElementById("ratingDisplay");
            ratingDisplay.textContent = response.finalrate;
        }
    });
}

function closeRate() {
    var popup = document.getElementById("rate");
    popup.style.display = "none";
}

function readyRating(finalRate,r1,r2,r3,state) {
    $(document).ready(function () {
        //your code here
        $(".my-rating").starRating({
            starSize: 25,
            initialRating: finalRate,
            hoverColor: '#ffd800',
            ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
            readOnly: true
        });

        if (state == "true") {

            console.log("true");

            $("#r1").starRating({
                starSize: 25,
                initialRating: r1,
                minRating: 0,
                hoverColor: '#ffd800',
                ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
                readOnly: true
            });

            $("#r2").starRating({
                starSize: 25,
                initialRating: r2,
                minRating: 0,
                hoverColor: '#ffd800',
                ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
                readOnly: true
            });

            $("#r3").starRating({
                starSize: 25,
                initialRating: r3,
                minRating: 0,
                hoverColor: '#ffd800',
                ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
                readOnly: true
            });
        } else {
            console.log("false");
        $("#r1").starRating({
            starSize: 25,
            initialRating: 0,
            minRating: 0,
            hoverColor: '#ffd800',
            ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
            callback: function (currentRating, $el) {
                rating1 = currentRating;
            }
        });

        $("#r2").starRating({
            starSize: 25,
            initialRating: 0,
            minRating: 0,
            hoverColor: '#ffd800',
            ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
            callback: function (currentRating, $el) {
                rating2 = currentRating;
            }
        });

        $("#r3").starRating({
            starSize: 25,
            initialRating: 0,
            minRating: 0,
            hoverColor: '#ffd800',
            ratedColors: ['ffd800', 'ffd800', 'ffd800', 'ffd800', 'ffd800'],
            callback: function (currentRating, $el) {
                rating3 = currentRating;
            }
        });
        }
    });
}

function submitRating() {
    showLoader();
    console.log(serviceProviderID);
    console.log(customerID);
    console.log(rating1);
    console.log(rating2);
    console.log(rating3);
    console.log($('#feedback').val());
    var formDataforName = new FormData();
    formDataforName.append("providerID", serviceProviderID);
    formDataforName.append("customerID", customerID);
    formDataforName.append("ratingOnTime", rating1);
    formDataforName.append("ratingFriendly", rating2);
    formDataforName.append("ratingQuality", rating3);
    formDataforName.append("serviceRequestID", serviceRequestId);
    formDataforName.append("comments", $('#feedback').val());
    $.ajax({
        type: 'POST',
        url: '/customerDashboard/RatingSubmit',
        data: formDataforName,
        processData: false,
        contentType: false,
        dataType: "json"
    }).done(function (response) {
        if (response.status == "success") {
            hideLoader();
            showMsg("Rating submitted.");
            var popup = document.getElementById("rate");
            popup.style.display = "none";
        } else {
            hideLoader();
            showMsg("Something went wrong.");
            var popup = document.getElementById("rate");
            popup.style.display = "none";
        }
    });
}

function favorite(type) {
    showLoader();
    if (type == "favorite") {
        var formDataforFavorite = new FormData();
        formDataforFavorite.append("type", type);
        formDataforFavorite.append("providerID", serviceProviderID);
        formDataforFavorite.append("customerID", customerID);

        $.ajax({
            type: 'POST',
            url: '/customerDashboard/Favorite',
            data: formDataforFavorite,
            processData: false,
            contentType: false,
            dataType: "json"
        }).done(function (response) {
            if (response.status == "success") {
                hideLoader();
                showMsg("Added to Favorite.");
                var popup = document.getElementById("rate");
                popup.style.display = "none";
                var favButton = document.getElementById("favoriteButton");
                favButton.style.display = "none";
            } else {
                hideLoader();
                showMsg("Something went wrong.");
                var popup = document.getElementById("rate");
                popup.style.display = "none";
            }
        });
    } else if (type == "unfavorite") {
        var formDataforFavorite = new FormData();
        formDataforFavorite.append("type", type);
        formDataforFavorite.append("providerID", serviceProviderID);
        formDataforFavorite.append("customerID", customerID);

        $.ajax({
            type: 'POST',
            url: '/customerDashboard/Favorite',
            data: formDataforFavorite,
            processData: false,
            contentType: false,
            dataType: "json"
        }).done(function (response) {
            if (response.status == "success") {
                hideLoader();
                showMsg("Removed from Favorite.");
                var popup = document.getElementById("rate");
                popup.style.display = "none";
                var favButton = document.getElementById("unfavoriteButton");
                favButton.style.display = "none";
            } else {
                hideLoader();
                showMsg("Something went wrong.");
                var popup = document.getElementById("rate");
                popup.style.display = "none";
            }
        });
    }
}