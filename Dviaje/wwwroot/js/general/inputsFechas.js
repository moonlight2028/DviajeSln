export const validacionInputFechas = (fechaInicial, fechaFinal) => {
    const bookingLlegada = document.getElementById(fechaInicial);
    const bookingSalida = document.getElementById(fechaFinal);

    // Establece la fecha actual y el valor minimo en la fecha actual
    let fechaActual = new Date().toISOString().split("T")[0];
    bookingLlegada.min = fechaActual;
    bookingLlegada.value = fechaActual;
    bookingSalida.min = fechaActual;
    bookingSalida.value = fechaActual;

    bookingLlegada.addEventListener("change", (e) => {
        e.stopPropagation();

        bookingSalida.min = bookingLlegada.value;

        if (new Date(bookingSalida.value) < new Date(bookingLlegada.value)) {
            bookingSalida.value = bookingLlegada.value;
        }
    });
} 
