/* swiper v11 */
import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.mjs'

export const swipersTarjetasPublicacion = () => {
    let swiperCarrusel = new Swiper(".swiper-carrusel", {
        lazy: true,
        loop: true,
        grabCursor: true,
        pagination: {
            el: ".swiper-carrusel-pagination",
            type: "fraction",
        },
        navigation: {
            nextEl: ".swiper-carrusel-next",
            prevEl: ".swiper-carrusel-prev",
        },
    });

    let swiperCategorias = new Swiper(".swiper-categorias", {
        lazy: true,
        slidesPerView: "auto",
        spaceBetween: 5,
        grabCursor: true,
        freeMode: true,
        loop: true,
    });
};