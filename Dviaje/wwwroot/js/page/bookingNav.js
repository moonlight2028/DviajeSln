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
}

export const bookingModalFiltros = ()=>{
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