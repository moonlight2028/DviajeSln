export const estrellasPuntuacion = () => {
    const estrellasPuntuacionLabel = document.querySelectorAll('[data-estrellas="puntuacion"]');
    let estrellaPuntuacionActual = -1;

    estrellasPuntuacionLabel.forEach((element, index) => {
        let estrellasIconos = Array.from(estrellasPuntuacionLabel).map(e => e.querySelector("i"));

        element.addEventListener("mouseover", () => {
            seleccionarEstrellas(estrellasIconos, index);
        })
        element.addEventListener("mouseout", () => {
            seleccionarEstrellas(estrellasIconos, estrellaPuntuacionActual);
        })

        element.addEventListener("click", () => {
            estrellaPuntuacionActual = index;
            seleccionarEstrellas(estrellasIconos, index);
        });
    })
}

const seleccionarEstrellas = (estrellas, seleccion) => {
    for (let i = 0; i < estrellas.length; i++) {
        if (i <= seleccion) {
            estrellas[i].classList.replace("fa-regular", "fa-solid");
        } else {
            estrellas[i].classList.replace("fa-solid", "fa-regular");
        }
    }
}