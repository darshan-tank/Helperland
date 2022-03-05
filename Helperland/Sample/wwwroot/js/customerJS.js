window.addEventListener('load', (event) => {
    openDashboard();
});

function openServiceHistory() {
    $("#right-container").html("Loading...").load('/customerDashboard/ServiceHistory');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("ServiceHistoryLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("serviceHistoryMenuLI");
    currentMenu.classList.add("active-li-menu");
}

function openDashboard() {
    $("#right-container").html("Loading...").load('/customerDashboard/CurrentService');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("dashboardLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("dashboardMenuLI");
    currentMenu.classList.add("active-li-menu");
}

function openServiceSchedule() {
    $("#right-container").html("Loading...").load('/customerDashboard/ServiceSchedule');
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

function openBookServicePage() {
    window.location.href = "/bookservice"
}

function openFavoritePro() {
    $("#right-container").html("Loading...").load('/customerDashboard/FavoritePro');
    var allLI = document.getElementsByClassName("li-item");
    for (var i = 0; i < allLI.length; i++) {
        allLI[i].classList.remove("active-li");
    }
    var current = document.getElementById("FavoriteProsLI");
    current.classList.add("active-li");
    var allMenuLI = document.getElementsByName("menuLi");
    for (var i = 0; i < allMenuLI.length; i++) {
        allMenuLI[i].classList.remove("active-li-menu");
    }
    var currentMenu = document.getElementById("favoriteProsMenuLI");
    currentMenu.classList.add("active-li-menu");
}

