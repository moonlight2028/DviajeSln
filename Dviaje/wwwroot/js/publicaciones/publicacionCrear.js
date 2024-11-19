import { galeriaImagenes } from "../general/galeriaFancybox.js";

galeriaImagenes();
document.addEventListener('DOMContentLoaded', () => {
    const editables = [
        { divId: 'DivInputTitulo', inputId: 'Titulo' },
        { divId: 'DivInputDireccion', inputId: 'Direccion' },
        { divId: 'DivInputDescripcion', inputId: 'Descripcion' }
    ];


    // Imagenes
    const dropZone = document.getElementById('drop-zone');
    const imageInput = document.getElementById('imageInput');
    const previewContainer = document.getElementById('preview-container');
    let fileList = [];

    // Checkboxes inputs
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');

    // Inputs fechas
    const agregarFechaButtonSm = document.getElementById('agregar-fecha-sm');
    const agregarFechaButtonLg = document.getElementById('agregar-fecha-lg');
    const fechaInicialInput = document.getElementById('booking-busqueda-llegada');
    const fechaFinalInput = document.getElementById('booking-busqueda-salida');
    const fechasAgregadasContainer = document.getElementById('fechas-agregadas');


    // Eventos DOM
    // Eventos inputs
    editables.forEach(({ divId, inputId }) => {
        const div = document.getElementById(divId);
        const input = document.getElementById(inputId);

        if (div && input) {
            const defaultValue = div.textContent.trim(); // Valor inicial del div editable

            // Evento al perder el foco (blur)
            div.addEventListener('blur', () => {
                const value = div.textContent.trim();
                if (!value) {
                    div.textContent = defaultValue;
                    input.value = "";
                } else {
                    input.value = div.textContent;
                }
            });

            // Evento mientras se escribe (input)
            div.addEventListener('input', () => {
                input.value = div.textContent;
            });
        } else {
            console.error(`No se encontró el elemento con id "${divId}" o "${inputId}"`);
        }
    });


    // Eventos imagenes
    dropZone.addEventListener('dragover', (e) => {
        e.preventDefault();
        dropZone.classList.add('active');
    });

    dropZone.addEventListener('dragleave', () => {
        dropZone.classList.remove('active');
    });

    dropZone.addEventListener('drop', (e) => {
        e.preventDefault();
        dropZone.classList.remove('active');
        handleFiles(e.dataTransfer.files);
    });

    dropZone.addEventListener('click', () => {
        imageInput.click();
    });

    imageInput.addEventListener('change', (e) => {
        handleFiles(e.target.files);
    });

    // Evento checkboxes inputs
    checkboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            // Seleccionar el div contenedor más cercano
            const container = this.closest('.checkbox-item');
            const label = container.querySelector(`label[for="${this.id}"]`);

            if (this.checked) {
                container.classList.add('active');
                label.classList.add('active');
            } else {
                container.classList.remove('active');
                label.classList.remove('active');
            }
        });
    });


    // Funcion fechas
    const agregarFecha = () => {
        const fechaInicial = fechaInicialInput.value;
        const fechaFinal = fechaFinalInput.value;

        if (fechaInicial && fechaFinal) {
            const fechaItem = document.createElement('div');
            fechaItem.classList.add('fecha-item');
            fechaItem.innerHTML = `
                <div class="fecha">
                    <div>
                        <span class="fecha-agregada-titulo">Fecha Inicial</span>
                        <span class="fecha-agregada-valor">${fechaInicial}</span>
                    </div>
                    <div>
                        <span class="fecha-agregada-titulo">Fecha Final</span>
                        <span class="fecha-agregada-valor">${fechaFinal}</span>
                    </div>
                </div>
                <button class="remove-fecha">
                    <i class="fa-solid fa-xmark"></i>
                </button>
            `;

            fechasAgregadasContainer.appendChild(fechaItem);

            fechaInicialInput.value = '';
            fechaFinalInput.value = '';

            const removeButton = fechaItem.querySelector('.remove-fecha');
            removeButton.addEventListener('click', () => {
                fechaItem.remove();
            });
        } else {
            alert('Por favor, ingrese ambas fechas.');
        }
    };

    // Evento fechas
    agregarFechaButtonSm.addEventListener('click', agregarFecha);
    agregarFechaButtonLg.addEventListener('click', agregarFecha);


    // Funciones imagenes
    function handleFiles(files) {
        Array.from(files).forEach((file) => {
            if (!file.type.startsWith('image/')) return;

            const reader = new FileReader();
            reader.onload = (e) => {
                const url = e.target.result;

                fileList.push(file);

                const previewItem = document.createElement('div');
                previewItem.classList.add('preview-item');
                previewItem.innerHTML = `
                    <a href="${url}" data-fancybox="gallery">
                        <img src="${url}" alt="Image">
                        <button class="remove-btn">&times;</button>
                    </a>
                `;

                previewItem.querySelector('.remove-btn').addEventListener('click', () => {
                    const index = Array.from(previewContainer.children).indexOf(previewItem);
                    fileList.splice(index, 1);
                    previewItem.remove();
                    updateInput();
                });

                previewContainer.appendChild(previewItem);
                updateInput();
            };
            reader.readAsDataURL(file);
        });
    }

    function updateInput() {
        const dataTransfer = new DataTransfer();
        fileList.forEach((file) => dataTransfer.items.add(file));
        imageInput.files = dataTransfer.files;
    }

    Sortable.create(previewContainer, {
        animation: 150,
        onEnd: () => {
            const sortedItems = Array.from(previewContainer.children);
            fileList = sortedItems.map((item) => {
                const index = Array.from(previewContainer.children).indexOf(item);
                return fileList[index];
            });
            updateInput();
        },
    });
});
