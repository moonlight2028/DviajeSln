import { publicacionesOrdenar } from "./publicacionesOrdenar.js"
import { publicacionesSwipers } from "./publicacionesSwipers.js"
import { paginacionNav } from "../general/paginacionNav.js"

// URL
let url = new URL(window.location.href);
let parametros = new URLSearchParams(url.search);

// Elementos
// Filtro ordenar
const filtroOrdenar = document.getElementById("ordenar-filtro");
// Paginación
const contenedorPaginacion = document.getElementById("paginacion");
const numeroDePaginas = parseInt(contenedorPaginacion.getAttribute("data-paginacion-paginas"));
const itemsPorPagina = parseInt(contenedorPaginacion.getAttribute("data-paginacion-items"));
const resultadosTotales = parseInt(contenedorPaginacion.getAttribute("data-paginacion-resultados"));
let paginaActual = 1;


// Valores default del filtro ordenar
let valoresOrdenar = ["Puntuación", "Precio Mayor", "Precio Menor"];

// Asignación a valores ordenar
if (parametros.has("ordenar")) {
    switch (parametros.get("ordenar").trim().toUpperCase()) {
        case "PRECIO_MENOR":
            valoresOrdenar = ["Precio Menor", "Precio Mayor", "Puntuación"];
            break;
        case "PRECIO_MAYOR":
            valoresOrdenar = ["Precio Mayor", "Precio Menor", "Puntuación"];
            break;
    }
}

// Valores paginación
if (parametros.has("pagina")) {
    paginaActual = parseInt(parametros.get("pagina"));
}

// Render filtro ordenar
publicacionesOrdenar(filtroOrdenar, valoresOrdenar);

// Swiper tarjetas
publicacionesSwipers();

// Render paginación
paginacionNav(paginaActual, numeroDePaginas, itemsPorPagina, resultadosTotales, contenedorPaginacion);


// Eventos
// Redirige según el filtro de ordenar
const itemsFiltroOrdenar = document.getElementById("items-ordenar");
itemsFiltroOrdenar.addEventListener("click", (e) => {
    e.stopPropagation();

    let valorItemClick = e.target.getAttribute('data-ordenar');
    parametros.set("ordenar", valorItemClick);
    url.search = parametros.toString();
    window.location.href = url;
})

// Pagiancion
contenedorPaginacion.addEventListener("click", (event) => {
    event.stopPropagation();

    if (event.target.matches("div[data-pagina]")) {
        const paginaNumero = parseInt(event.target.getAttribute('data-pagina'));
        parametros.set("pagina", paginaNumero);
        url.search = parametros.toString();
        window.location.href = url;
    }
    if (event.target.closest("div[data-pagina-nav]")) {
        let paginaNumero = paginaActual + 1;
        if (event.target.closest("div[data-pagina-nav]").getAttribute("data-pagina-nav") === "anterior") {
            paginaNumero = paginaActual - 1;
        }
        parametros.set("pagina", paginaNumero);
        url.search = parametros.toString();
        window.location.href = url;
    }
})
