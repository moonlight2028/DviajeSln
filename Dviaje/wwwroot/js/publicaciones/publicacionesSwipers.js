/* swiper v11 */
import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.mjs'

export const publicacionesSwipers = () => {
    let swiperCarrusel = new Swiper(".swiper-imagenes", {
        lazy: true,
        loop: true,
        grabCursor: true,
        pagination: {
            el: ".swiper-imagenes-pagination",
            type: "fraction",
        },
        navigation: {
            nextEl: ".swiper-imagenes-next",
            prevEl: ".swiper-imagenes-prev",
        },
    });

    let swiperCategorias = new Swiper(".swiper-wrapper-categorias", {
        lazy: true,
        slidesPerView: 16,
        spaceBetween: 5,
        grabCursor: true,
        freeMode: true,
        loop: true,
    });
}
