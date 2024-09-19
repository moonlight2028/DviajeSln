export const paginacionNav = (paginaActual, numeroDePaginas, itemsMostrados,resultados, contenedorPaginacion) => {
    const fragmentPaginacion = document.createDocumentFragment();
    const div = document.createElement("div");
    const divItems = document.createElement("div");
    divItems.classList = "paginacion-items";
    const pPaginacion = document.createElement("p");
    pPaginacion.classList = "paginacion-items-informacion";
    pPaginacion.textContent = `Mostrando resultados de ${((itemsMostrados * (paginaActual - 1)) + 1)} a ${Math.min(itemsMostrados * paginaActual, resultados)} de ${resultados}`;

    if (paginaActual != 1) {
        divItems.appendChild(crearDivNav());
    }
    if (numeroDePaginas > 3) {
        if (paginaActual > 2) {
            crearDivItemPaginacion("paginacion-items-numbers", 1, divItems, true);
        }
        if (paginaActual > 3) {
            crearDivItemPaginacion("paginacion-items-points", "...", divItems);
        }
        let inicio = paginaActual - 1;
        let ciclo = paginaActual + 2;

        if (inicio === 0) {
            inicio = 1;
            ciclo += 1;
        }

        if (ciclo === numeroDePaginas + 2) {
            inicio--;
            ciclo = numeroDePaginas + 1;
        }

        for (let i = inicio; i < ciclo; i++) {
            if (i === paginaActual) {
                crearDivItemPaginacion("paginacion-items-numbers items-numbers-activo", i, divItems, true);
            } else {
                crearDivItemPaginacion("paginacion-items-numbers", i, divItems, true);
            }
        }
        if (paginaActual + 2 < numeroDePaginas) {
            crearDivItemPaginacion("paginacion-items-points", "...", divItems);
        }
        if (paginaActual < numeroDePaginas - 1) {
            crearDivItemPaginacion("paginacion-items-numbers", numeroDePaginas, divItems, true);
        }
    } else {
        for (let i = 1; i <= numeroDePaginas; i++) {
            if (i === paginaActual) {
                crearDivItemPaginacion("paginacion-items-numbers items-numbers-activo", i, divItems, true);
            } else {
                crearDivItemPaginacion("paginacion-items-numbers", i, divItems, true);
            }
        }
    }
    if (paginaActual < numeroDePaginas) {
        divItems.appendChild(crearDivNav(false));
    }

    // Cargando elementos
    div.appendChild(divItems);
    div.appendChild(pPaginacion);
    fragmentPaginacion.appendChild(div);

    // Renderizando paginación
    contenedorPaginacion.appendChild(fragmentPaginacion);
}

const crearDivItemPaginacion = (clases, contenido,padre, dataset = false) => {
    const div = document.createElement("div");
    div.classList = clases;
    div.textContent = contenido;
    if (dataset) {
        div.dataset.pagina = contenido;
    }
    padre.appendChild(div);
}

const crearDivNav = (siguiente = true) => {
    const div = document.createElement("div");
    div.classList = "paginacion-items-nav";
    const i = document.createElement("i");
    
    if (siguiente) {
        div.setAttribute("data-pagina-nav", "anterior");
        i.classList = "fa-solid fa-chevron-left";
    } else {
        div.setAttribute("data-pagina-nav", "siguiente");
        i.classList = "fa-solid fa-chevron-right";
    }

    div.appendChild(i);
    return div;
}
