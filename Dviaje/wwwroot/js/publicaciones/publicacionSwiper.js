/* swiper v11 */
import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.mjs'

export const publicacionSwiper = () => {
    var swiperThumbsMain = new Swiper(".swiper-thumbs", {
        lazy: true,
        loop: true,
        spaceBetween: 4,
        slidesPerView: 3,
        freeMode: true,
        grabCursor: true,
        breakpoints: {
            768: {
                direction: "vertical",
            },
        },
        keyboard: {
            enabled: true,
        },
    });

    var swiperCarruselMain = new Swiper('.carrusel-main', {
        lazy: true,
        loop: true,
        pagination: {
            el: ".swiper-main-pagination",
            type: "fraction",
        },
        navigation: {
            prevEl: ".swiper-prev",
            nextEl: ".swiper-next",
        },
        thumbs: {
            swiper: swiperThumbsMain,
        },
        keyboard: {
            enabled: true,
        },
    });
}
