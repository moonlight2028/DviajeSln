// URL
let url = new URL(window.location.href);
let parametros = new URLSearchParams(url.search);

let paginaActual = parametros.has("pagina") ? parseInt(parametros.get("pagina")) : 1;

export const renderPagination = () => {
    // Datos
    const paginasTotales = parseInt(document.querySelector("[data-paginacion-total]").getAttribute("data-paginacion-total"));
    const resultadosMostrados = parseInt(document.querySelector("[data-paginacion-resultados-mostrados]").getAttribute("data-paginacion-resultados-mostrados"));
    const resultadosTotales = parseInt(document.querySelector("[paginacion-resultados-totales]").getAttribute("paginacion-resultados-totales"));

    const paginationContainer = document.createElement('ol');
    paginationContainer.className = 'flex justify-center items-center gap-1 text-lg mt-20';

    // Función para crear un elemento de página
    const createPageElement = (page, isActive = false) => {
        const pageElement = document.createElement('li');
        const div = document.createElement('div');
        div.className = isActive 
            ? 'block size-9 rounded border border-orange-500 bg-orange-500 text-center leading-8 text-white cursor-pointer'
            : 'block size-8 rounded border border-gray-100 bg-white text-center leading-8 text-gray-900 hover:border-orange-500 hover:bg-orange-500 hover:text-white cursor-pointer';
        div.textContent = page;
        div.addEventListener('click', () => {
            parametros.set("pagina", page);
            window.location.search = parametros.toString();
        });
        pageElement.appendChild(div);
        return pageElement;
    };

    // Prev Page
    if (paginaActual > 1) {
        const prevPage = document.createElement('li');
        const div = document.createElement('div');
        div.className = 'inline-flex size-8 items-center justify-center rounded border border-gray-100 bg-white text-gray-900 rtl:rotate-180 hover:bg-orange-500 hover:text-white cursor-pointer';
        div.innerHTML = `
            <span class="sr-only">Prev Page</span>
            <svg xmlns="http://www.w3.org/2000/svg" class="h-3 w-3" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 011.414 0z" clip-rule="evenodd" />
            </svg>`;
        div.addEventListener('click', () => {
            parametros.set("pagina", paginaActual - 1);
            window.location.search = parametros.toString();
        });
        prevPage.appendChild(div);
        paginationContainer.appendChild(prevPage);
    }

    // Páginas y rangos
    let rango = paginaActual + 2 >= paginasTotales ? paginasTotales : paginaActual + 2;

    if (paginaActual >= 4 && paginasTotales >= 6) {
        paginationContainer.appendChild(createPageElement(1));

        const dots = document.createElement('li');
        dots.innerHTML = `<div class="block size-8 rounded border border-gray-100 bg-white text-center leading-8 text-gray-900">...</div>`;
        paginationContainer.appendChild(dots);

        for (let i = paginaActual - 2; i <= rango; i++) {
            paginationContainer.appendChild(createPageElement(i, i === paginaActual));
        }

        if (paginaActual + 2 < paginasTotales) {
            const dotsEnd = document.createElement('li');
            dotsEnd.innerHTML = `<div class="block size-8 rounded border border-gray-100 bg-white text-center leading-8 text-gray-900">...</div>`;
            paginationContainer.appendChild(dotsEnd);

            paginationContainer.appendChild(createPageElement(paginasTotales));
        }
    } else {
        for (let i = 1; i <= Math.min(paginasTotales, 5); i++) {
            paginationContainer.appendChild(createPageElement(i, i === paginaActual));
        }

        if (paginasTotales > 5) {
            const dotsEnd = document.createElement('li');
            dotsEnd.innerHTML = `<div class="block size-8 rounded border border-gray-100 bg-white text-center leading-8 text-gray-900">...</div>`;
            paginationContainer.appendChild(dotsEnd);

            paginationContainer.appendChild(createPageElement(paginasTotales));
        }
    }

    // Next Page
    if (paginaActual < paginasTotales) {
        const nextPage = document.createElement('li');
        const div = document.createElement('div');
        div.className = 'inline-flex size-8 items-center justify-center rounded border border-gray-100 bg-white text-gray-900 rtl:rotate-180 hover:bg-orange-500 hover:text-white cursor-pointer';
        div.innerHTML = `
            <span class="sr-only">Next Page</span>
            <svg xmlns="http://www.w3.org/2000/svg" class="h-3 w-3" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" />
            </svg>`;
        div.addEventListener('click', () => {
            parametros.set("pagina", paginaActual + 1);
            window.location.search = parametros.toString();
        });
        nextPage.appendChild(div);
        paginationContainer.appendChild(nextPage);
    }

    // Texto informativo
    const infoText = document.createElement('p');
    infoText.className = 'text-center mt-4 font-light';
    infoText.textContent = `Mostrando resultados de ${((resultadosMostrados * (paginaActual - 1)) + 1)} a ${Math.min(resultadosMostrados * paginaActual, resultadosTotales)} de ${resultadosTotales}`;

    // Interacción única con el DOM
    const paginationWrapper = document.getElementById('pagination-wrapper');
    paginationWrapper.innerHTML = '';
    paginationWrapper.appendChild(paginationContainer);
    paginationWrapper.appendChild(infoText);
};
