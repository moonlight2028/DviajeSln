export const btnMostrarMas = (botones, primerTexto, segundoTexto, claseElementoMostrar) => {
    const btnMas = document.querySelectorAll(`[data-btn="${botones}"]`);

    btnMas.forEach(btn => {
        btn.addEventListener("click", (e) => {
            let spanTexto = btn.firstElementChild;
            let icono = btn.lastElementChild;
            let elementoOculto = btn.previousElementSibling;

            if (spanTexto.textContent === primerTexto) {
                spanTexto.textContent = segundoTexto;
                icono.classList = "fa-solid fa-chevron-up";
            } else {
                spanTexto.textContent = primerTexto;
                icono.classList = "fa-solid fa-chevron-down";
            }

            elementoOculto.classList.toggle(claseElementoMostrar);
        })
    });
}