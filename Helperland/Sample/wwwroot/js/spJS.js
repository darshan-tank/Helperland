window.addEventListener('load', (event) => {
    openUpcomingService();
});

function openUpcomingService() {
        $("#right-container").html("Loading Address...").load('/spDashboard/UpcomingService');
    }