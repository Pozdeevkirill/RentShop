// import Swiper JS

const swiper = new Swiper('.swiper', {
    autoplay: {
        delay: 4000,
        disableOnInteraction: false,
    },
    loop: true,
    // Navigation arrows 
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});
const swiperTwo = new Swiper('.swiper-two', {
    autoplay: {
        delay: 4000,
        disableOnInteraction: false,
    },
    slidesPerView: 1,
    spaceBetween: 30,
    breakpoints: {
        765: {
            slidesPerView: 2,
        },
        992: {
            slidesPerView: 3,
        },
    },
    loop: true,
    // Navigation arrows 
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});
const swiperExplore = new Swiper('.swiper-explore', {
    autoplay: {
        delay: 4000,
        disableOnInteraction: false,
    },
    slidesPerView: 1,
    spaceBetween: 30,
    breakpoints: {
        765: {
            slidesPerView: 2,
        },
        992: {
            slidesPerView: 3,
        },
    },
    loop: true,
    // Navigation arrows 
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});

// start header
let header = document.querySelector("header");
// scroll
document.onscroll = () => {
    if (window.scrollY >= 400) {
        header.classList.add("scroll-header");
    } else {
        header.classList.remove("scroll-header");
    }
};

// menu
let buttonMenu = document.querySelector("header .menu");
let mainMenu = document.querySelector("header .linkes");

buttonMenu.addEventListener("click", (e) => {
    mainMenu.classList.toggle("open");
    buttonMenu.classList.toggle("cloce");
});

// linkes
let linkes = document.querySelectorAll("header .linkes ul li a");
linkes.forEach((li) => {
    if (li.href === document.location.href) {
        li.classList.add("active");
    } else {
        li.classList.remove("active");
    }
});

// end header


// start filters
let filters = document.querySelectorAll(".currently-market .filters li");
let item = document.querySelectorAll(".currently-market .grid .item");
filters.forEach((li) => {
    li.addEventListener("click", (e) => {
        // console.log(e.target);
        e.target.parentElement.querySelectorAll(".active").forEach((el) => {
            el.classList.remove("active");
        });
        e.target.classList.add("active");
        item.forEach((it) => {
            it.style.display = "none";
        });
        document.querySelectorAll(e.target.dataset.filter).forEach((it) => {
            it.style.display = "flex";
        });
    });
});
// end filters

/*// Page loading animation
const loaderContainer = document.querySelector('#js-preloader');
window.addEventListener('load', () => {
    loaderContainer.classList.add("loaded");
});*/