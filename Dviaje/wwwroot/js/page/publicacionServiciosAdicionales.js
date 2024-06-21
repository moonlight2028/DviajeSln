const cambiarTextoPrecio = (precio, suma) => {
    const textoPrecio = document.querySelectorAll('[data-precio="valor"]');

    textoPrecio.forEach(element => {
        let precioActual = parseInt(element.textContent.replace(/\./g, ''), 10);

        if (suma) {
            element.textContent = (precioActual + parseInt(precio, 10)).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
        } else {
            element.textContent = (precioActual - parseInt(precio, 10)).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
        }
    });
};

export const checksServiciosAdicionales = () => {
    const labelsServiciosAdicionales = document.querySelectorAll('[data-servicio="adicional"]');

    labelsServiciosAdicionales.forEach(el => {
        el.addEventListener("click", () => {
            let estadoInicial = el.classList.contains("border");
            let icono = el.querySelector("i");
            let valorPrecio = document.getElementById(el.getAttribute("for")).value;

            if (estadoInicial) {
                el.classList.replace("border", "border-[2px]");
                el.classList.replace("border-cyan-400", "border-orange-500");
                icono.classList.replace("text-cyan-400", "text-orange-500");
                cambiarTextoPrecio(valorPrecio, true);
            } else {
                el.classList.replace("border-[2px]", "border");
                el.classList.replace("border-orange-500", "border-cyan-400");
                icono.classList.replace("text-orange-500", "text-cyan-400");
                cambiarTextoPrecio(valorPrecio, false);
            }
        })
    });
};