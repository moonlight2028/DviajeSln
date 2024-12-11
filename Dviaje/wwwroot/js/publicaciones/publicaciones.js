import { validacionInputFechas } from "../general/inputsFechas.js"
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
let numeroDePaginas = null;
let itemsPorPagina = null;
let resultadosTotales;
if (contenedorPaginacion != null) {
    numeroDePaginas = parseInt(contenedorPaginacion.getAttribute("data-paginacion-paginas"));
    itemsPorPagina = parseInt(contenedorPaginacion.getAttribute("data-paginacion-items"));
    resultadosTotales = parseInt(contenedorPaginacion.getAttribute("data-paginacion-resultados"));
}
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


// Validación de fechas en la nav de búsqueda
validacionInputFechas("booking-busqueda-llegada", "booking-busqueda-salida");

// Render filtro ordenar
if (filtroOrdenar != null) {
    publicacionesOrdenar(filtroOrdenar, valoresOrdenar);
}

// Swiper tarjetas
publicacionesSwipers();

// Render paginación
if (contenedorPaginacion != null) {
    paginacionNav(paginaActual, numeroDePaginas, itemsPorPagina, resultadosTotales, contenedorPaginacion);
}


// Eventos
// Redirige según el filtro de ordenar
const itemsFiltroOrdenar = document.getElementById("items-ordenar");
if (itemsFiltroOrdenar != null) {
    itemsFiltroOrdenar.addEventListener("click", (e) => {
        e.stopPropagation();

        let valorItemClick = e.target.getAttribute('data-ordenar');
        parametros.set("ordenar", valorItemClick);
        url.search = parametros.toString();
        window.location.href = url;
    })
}

// Pagiancion
if (contenedorPaginacion != null) {
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
}

















// Obtener elementos principales
const modal = document.getElementById("myModal");
const openModalBtn = document.getElementById("openModalBtn");
let filtrosCargados = false;

const toggleCategoriasBtn = document.getElementById("toggle-categorias-btn");
const filtroCategorias = document.getElementById("filtro-categorias");
const filtroCategoriasChevron = document.getElementById("filtro-categorias-chevron");

const togglePropiedadesBtn = document.getElementById("toggle-propiedades-btn");
const filtroPropiedades = document.getElementById("filtro-propiedades");
const filtropropiedadesChevron = document.getElementById("filtro-propiedades-chevron");

const toggleRestriccionesBtn = document.getElementById("toggle-restricciones-btn");
const filtroRestricciones = document.getElementById("filtro-restricciones");
const filtroRestriccionesChevron = document.getElementById("filtro-restricciones-chevron");

// Función genérica para cargar datos
const getDatos = async (url) => {
    try {
        const respuesta = await fetch(url);
        if (!respuesta.ok) {
            throw new Error(`HTTP error! status: ${respuesta.status}`);
        }
        return await respuesta.json();
    } catch (error) {
        console.error("Error:", error.message || error);
        throw error;
    }
};

// Función para cargar los filtros
const cargarFiltros = async () => {
    if (!filtrosCargados) {
        try {
            // Cargar categorías
            const categorias = await getDatos("/categorias");
            filtroCategorias.innerHTML = `
            <div class="filtros-inputs-checks">
                ${categorias.map(c => `
                    <div class="filtro-input-categorias">
                        <input type="checkbox" id="categoria-${c.idCategoria}" name="categorias" value="${c.idCategoria}">
                        <label for="categoria-${c.idCategoria}">
                            <i class="${c.rutaIcono}"></i>
                            <span>${c.nombreCategoria}</span>
                        </label>
                    </div>
                `).join("")}
            </div>`;


            // Cargar propiedades
            const propiedades = await getDatos("/propiedades");
            filtroPropiedades.innerHTML = `<div class="filtros-inputs-checks">
                ${propiedades.map(p => `
                    <div class="filtro-input-propiedades">
                        <input type="checkbox" id="propiedad-${p.idPropiedad}" name="propiedades" value="${p.idPropiedad}">
                        <label for="propiedad-${p.idPropiedad}">
                            <i class="${p.rutaIcono}"></i>
                            <span>${p.nombre}</span>
                        </label>
                    </div>
                `).join("")}
            </div>`;

            // Cargar restricciones
            const restricciones = await getDatos("/restricciones");
            filtroRestricciones.innerHTML = `<div class="filtros-inputs-checks">
                ${restricciones.map(r => `
                    <div class="filtro-input-restricciones">
                        <input type="checkbox" id="restriccion-${r.idRestriccion}" name="restricciones" value="${r.idRestriccion}">
                        <label for="restriccion-${r.idRestriccion}">
                            <i class="${r.rutaIcono}"></i>
                            <span>${r.nombreRestriccion}</span>
                        </label>
                    </div>
                `).join("")}
            </div>`;

            filtrosCargados = true;
        } catch (error) {
            console.error("Error al cargar los filtros:", error);
        }
    }
};

// Función para mostrar el modal
openModalBtn.addEventListener("click", (e) => {
    e.preventDefault();
    e.stopPropagation();
    modal.style.display = "flex"; // Mostrar el modal
    cargarFiltros(); // Cargar los filtros
});

// Ocultar el modal al hacer clic fuera de él
window.addEventListener("click", (event) => {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});

// Alternar visibilidad de listas desplegables
toggleCategoriasBtn.addEventListener("click", () => {
    filtroCategorias.classList.toggle("show");
    filtroCategoriasChevron.classList.toggle("fa-rotate-180");
});

togglePropiedadesBtn.addEventListener("click", () => {
    filtroPropiedades.classList.toggle("show");
    filtropropiedadesChevron.classList.toggle("fa-rotate-180");
});

toggleRestriccionesBtn.addEventListener("click", () => {
    filtroRestricciones.classList.toggle("show");
    filtroRestriccionesChevron.classList.toggle("fa-rotate-180");
});





const precioMinInput = document.getElementById("precio-min");
const precioMaxInput = document.getElementById("precio-max");
const sliderMin = document.getElementById("slider-min");
const sliderMax = document.getElementById("slider-max");
const valorMin = document.getElementById("valor-min");
const valorMax = document.getElementById("valor-max");

// Sincronizar sliders y inputs
const sincronizarValores = () => {
    const min = Math.min(parseInt(sliderMin.value), parseInt(sliderMax.value) - 1);
    const max = Math.max(parseInt(sliderMin.value) + 1, parseInt(sliderMax.value));

    sliderMin.value = min;
    sliderMax.value = max;
    precioMinInput.value = min;
    precioMaxInput.value = max;
    valorMin.textContent = `$${min}`;
    valorMax.textContent = `$${max}`;
};

sliderMin.addEventListener("input", sincronizarValores);
sliderMax.addEventListener("input", sincronizarValores);

// Validar inputs
precioMinInput.addEventListener("input", () => {
    if (parseInt(precioMinInput.value) >= parseInt(precioMaxInput.value)) {
        precioMinInput.value = parseInt(precioMaxInput.value) - 1;
    }
    sliderMin.value = precioMinInput.value;
    sincronizarValores();
});

precioMaxInput.addEventListener("input", () => {
    if (parseInt(precioMaxInput.value) <= parseInt(precioMinInput.value)) {
        precioMaxInput.value = parseInt(precioMinInput.value) + 1;
    }
    sliderMax.value = precioMaxInput.value;
    sincronizarValores();
});


const btnBuscarFiltros = document.getElementById("filtros-Buscar-btn");
btnBuscarFiltros.addEventListener("click", (e) => {
    //e.preventDefault();
    //e.stopPropagation();






})


