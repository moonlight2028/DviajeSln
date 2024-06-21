/* swiper v11 */
import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.mjs'

export const swipers = () => {
    var swiperThumbsMain = new Swiper(".swiper-thumbs", {
        lazy: true,
        loop: true,
        spaceBetween: 4,
        slidesPerView: 3,
        freeMode: true,
        breakpoints: {
            768: {
                direction: "vertical",
            },
        },
        keyboard: {
            enabled: true,
        },
    });

    var swiperCarruselMain = new Swiper('.carrusel-imagenes-main', {
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

    var swiperCategorias = new Swiper(".swiper-categorias", {
        lazy: true,
        slidesPerView: "auto",
        spaceBetween: 5,
        grabCursor: true,
        freeMode: true,
        loop: true,
    });
}