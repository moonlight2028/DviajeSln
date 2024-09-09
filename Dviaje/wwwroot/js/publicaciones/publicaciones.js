/* swiper v11 */
import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.mjs'

// Swiper Tarjetas
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
// Fin Swiper Tarjetas



//const btnOrdenar = document.getElementById("btn-ordenar");
//const itemsOrdenar = document.getElementById("items-ordenar");



// Elimina los acentos usando una expresión regular
const eliminarTilde = (str) => {
    return str.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
};

const renderFiltroOrdenar = (filtro, items) => {
    // Creación del template del filtro ordenar
    let templateOrdenar = `
    <button class="dropdown-toggle" id="btn-ordenar">${items[0]}</button>
    <div class="dropdown-content b-s-95" id="items-ordenar">
        ${items.map((valor, index) => {
        if (index !== 0) {
            return `<div data-ordenar="${eliminarTilde(valor).toLowerCase()}">${valor}</div>`
        }
    }).join('')}
    </div>`.trim();

    // Carga del template filtro ordenar
    filtro.innerHTML = templateOrdenar;
}


/* Elementos */
const main = document.querySelector('main');
const filtroOrdenar = document.getElementById("ordenar-filtro");

// URL
let url = new URL(window.location.href);
let parametros = new URLSearchParams(url.search);

// Valores default del filtro ordenar
const valoresOrdenar = ["Puntuación", "Precio Mayor", "Precio Menor"];

// Asignación a valores ordenar
if (parametros.has("ordenar")) {
    switch (parametros.get("ordenar").trim().toLocaleUpperCase()) {
        case "PRECIOMENOR":
            valoresOrdenar = ["Precio Menor", "Precio Mayor", "Puntuación"];
            break;
        case "PRECIOMAYOR":
            valoresOrdenar = ["Precio Mayor", "Precio Menor", "Puntuación"];
            break;
    }
}

renderFiltroOrdenar(filtroOrdenar, valoresOrdenar);






main.addEventListener('click', (event) => {
    const btnDropdownOrdenar = event.target.closest('.dropdown-toggle');
    const itemsDropdownOrdenar = event.target.closest('.dropdown-content');

    //console.log(btnDropdownOrdenar)
    //console.log(itemsDropdownOrdenar)


    if (btnDropdownOrdenar) {
        const dropdown = btnDropdownOrdenar.nextElementSibling;
        dropdown.classList.toggle('show');
    } else if (!itemsDropdownOrdenar && !event.target.closest('.dropdown')) {
        const allDropdowns = document.querySelectorAll('.dropdown-content');
        allDropdowns.forEach(dropdown => {
            dropdown.classList.remove('show');
        });
    }
});

