//export const validacionFechaMaxima = (fechaInicial, fechaFinal) => {
//    const inputFechaInicial = document.getElementById(fechaInicial);
//    const inputFechaFinal = document.getElementById(fechaFinal);

//    const fechaMaximaPermitida = new Date();
//    fechaMaximaPermitida.setFullYear(fechaMaximaPermitida.getFullYear() + 1); // Establecer máximo en 1 año desde hoy
//    const fechaMaxima = fechaMaximaPermitida.toISOString().split("T")[0];

//    inputFechaInicial.max = fechaMaxima;
//    inputFechaFinal.max = fechaMaxima;

//    inputFechaInicial.addEventListener("change", () => {
//        if (inputFechaInicial.value > fechaMaxima) {
//            alert("No se puede seleccionar una fecha más de un año en el futuro.");
//            inputFechaInicial.value = "";
//        }
//    });

//    inputFechaFinal.addEventListener("change", () => {
//        if (inputFechaFinal.value > fechaMaxima) {
//            alert("No se puede seleccionar una fecha más de un año en el futuro.");
//            inputFechaFinal.value = "";
//        }
//    });
//};
