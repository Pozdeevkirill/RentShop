// Page loading animation
const loaderContainer = document.querySelector('#js-preloader');
window.addEventListener('load', () => {
    loaderContainer.classList.add("loaded");
});