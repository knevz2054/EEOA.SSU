window.disableBackButton = function () {
    window.history.pushState(null, "", window.location.href);
    window.addEventListener('popstate', disableBackButtonHandler);
};

function disableBackButtonHandler() {
    window.history.pushState(null, "", window.location.href);
    window.location.href = '/notfound'; // Navigate to the "not found" page
}