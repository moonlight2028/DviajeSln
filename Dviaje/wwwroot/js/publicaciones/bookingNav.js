export const bookingFechaValidacion = () => {
    // Fechas del booking
    const bookingLlegada = document.getElementById("booking-busqueda-llegada");
    const bookingSalida = document.getElementById("booking-busqueda-salida");

    // Establece la fecha actual y el valor minimo en la fecha actual
    let fechaActual = new Date().toISOString().split("T")[0];
    bookingLlegada.min = fechaActual;
    bookingLlegada.value = fechaActual;
    bookingSalida.min = fechaActual;
    bookingSalida.value = fechaActual;

    bookingLlegada.addEventListener("change", (e) => {
        bookingSalida.min = bookingLlegada.value;

        if (new Date(bookingSalida.value) < new Date(bookingLlegada.value)) {
            bookingSalida.value = bookingLlegada.value;
        }
    });
};

export const bookingBotonesFiltros = () => {
    const botonesBookingFiltros = document.querySelectorAll('[data-booking="btn-filtro"]');

    // URL
    let url = new URL(window.location.href);
    let parametros = new URLSearchParams(url.search);

    // Parametros del filtro
    let valoresTextDefault = [];
    let spanOpcionesBtns = document.querySelector("[data-booking='btn-span-options']");

    // Asignacion de parametros
    if(parametros.has("ordenar")){
        switch (parametros.get("ordenar").toUpperCase()) {
            case "PRECIOMENOR":
                valoresTextDefault = ["Precio Menor", "Precio Mayor", "Puntuación"];
                break;
            case "PRECIOMAYOR":
                valoresTextDefault = ["Precio Mayor", "Precio Menor", "Puntuación"];
                break;
            default:
                valoresTextDefault = ["Puntuación", "Precio Mayor", "Precio Menor"];
                break;
        }
    }else{
        valoresTextDefault = ["Puntuación", "Precio Mayor", "Precio Menor"];
    }
    
    // Cargando valores
    document.querySelector("[data-booking='btn-span-select']").textContent = valoresTextDefault[0];
    spanOpcionesBtns.innerHTML = `<span class="px-4 py-2 hover:bg-orange-500 hover:text-white cursor-pointer">${valoresTextDefault[1]}</span>
<span class="px-4 py-2 hover:bg-orange-500 hover:text-white cursor-pointer">${valoresTextDefault[2]}</span>`;

    // Evento btn general
    botonesBookingFiltros.forEach(element => {
        element.addEventListener("click", (e) => {
            e.preventDefault();

            let modalFiltro = document.querySelector(`[data-booking-filtro="${element.getAttribute("data-booking-filtro")}-modal"]`);
            let textoElemento = element.querySelector("span");
            let iconoBonton = element.querySelector("i");

            if (modalFiltro.classList.contains("hidden")) {
                modalFiltro.classList.replace("hidden", "block");
                element.classList.add("border-orange-500");
                textoElemento.classList.add("border-e-orange-500");
                iconoBonton.classList.add("-rotate-180");
                iconoBonton.classList.add("text-orange-500");
            } else {
                modalFiltro.classList.replace("block", "hidden");
                element.classList.remove("border-orange-500");
                textoElemento.classList.remove("border-e-orange-500");
                iconoBonton.classList.remove("-rotate-180");
                iconoBonton.classList.remove("text-orange-500");
            }
        });
    });

    // Evento opciones
    spanOpcionesBtns.addEventListener("click", (e) => {
        let valorClick = e.target.textContent.toLowerCase().replace(/\s+/g, '').trim();
        console.log(valorClick);
        parametros.set("ordenar",valorClick);
        url.search = parametros.toString();

        window.location.href = url;
    })
}

export const bookingModalFiltros = () => {
    const modalFiltros = document.getElementById("booking-filtrar-modal");
    const btnBookingFiltrar = document.getElementById("booking-btn-filtrar");

    modalFiltros.addEventListener("click", (e) => {
        if (e.target.id === "booking-filtrar-modal" || e.target.id === "filtrar-modal-cerrar") {
            modalFiltros.classList.add("hidden");
        }
    });

    btnBookingFiltrar.addEventListener("click", (e) => {
        e.preventDefault();
        modalFiltros.classList.remove("hidden");
    })
}