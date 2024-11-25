// Datos globales
let datos = {};
let pasoActual = 0;

// Pasos
const pasos = [
    {
        renderizar: () => `
            <h2>Información Básica</h2>

            <div class="informacion-inputs">
                <div class="contenedor-textarea">
                    <label for="titulo" class="input-label">
                        <textarea id="titulo" aria-required="true"
                                    class="input-field input-field-textarea" placeholder="Título"
                                    maxlength="50"></textarea>
                        <span class="input-placeholder">Título</span>
                    </label>
                    <p class="contador-text">0/50</p>
                </div>

                <div class="contenedor-textarea">
                    <label for="descripcion" class="input-label">
                        <textarea id="descripcion" aria-required="true"
                                    class="input-field input-field-textarea" placeholder="Descripción"
                                    maxlength="500"></textarea>
                        <span class="input-placeholder">Descripción</span>
                    </label>
                    <p class="contador-text">0/500</p>
                </div>
            </div>
        `,
        renderizarImagen: () => `<img src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Imagen datos básicos en crear publicación" class="img-f" />`,
        renderizarTitulo: () => `<h1>azadfjlkajdkl adksjflakdjslf adklfjakldf kaldjflakdjf</h1>`,
        guardar: () => {
            datos.titulo = document.getElementById('titulo').value.trim();
            datos.descripcion = document.getElementById('descripcion').value.trim();
        },
        validar: () => {
            const titulo = document.getElementById('titulo').value.trim();
            const descripcion = document.getElementById('descripcion').value.trim();
            if (!titulo) {
                alert('Por favor, ingrese su nombre.');
                return false;
            }
            if (!descripcion) {
                alert('Por favor, ingrese un correo valido.');
                return false;
            }
            return true;
        },
        alCargar: () => {
            // Selecciona todos los textareas y sus contadores relacionados
            const textareas = document.querySelectorAll('.contenedor-textarea textarea');
            const counters = document.querySelectorAll('.contenedor-textarea .contador-text');

            // Itera sobre cada textarea para agregar un evento "input" y rellenar los valores existentes
            textareas.forEach((textarea, index) => {
                const id = textarea.id;

                if (datos[id]) {
                    textarea.value = datos[id];

                    const charCount = datos[id].length;
                    const maxLength = textarea.getAttribute('maxlength');
                    counters[index].textContent = `${charCount}/${maxLength}`;
                }
                textarea.addEventListener('input', function () {
                    const charCount = this.value.length;
                    const maxLength = this.getAttribute('maxlength');
                    counters[index].textContent = `${charCount}/${maxLength}`;
                });
            });
        }
    },
    {
        renderizar: () => `
            <h2>Dirección</h2>

            <div class="informacion-inputs">
                <div class="contenedor-textarea">
                    <label for="direccion" class="input-label">
                        <textarea id="direccion" aria-required="true"
                                    class="input-field input-field-textarea" placeholder="Título"
                                    maxlength="50"></textarea>
                        <span class="input-placeholder">Dirección</span>
                    </label>
                    <p class="contador-text">0/100</p>
                </div>
            </div>
        `,
        renderizarImagen: () => `<img src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Imagen dirección en crear publicación" class="img-f" />`,
        renderizarTitulo: () => `<h1>azadfjlkajdkl adksjflakdjslf adklfjakldf kaldjflakdjf</h1>`,
        guardar: () => {
            datos.direccion = document.getElementById('direccion').value.trim();
        },
        validar: () => {
            const direccion = document.getElementById('direccion').value.trim();
            if (!direccion) {
                alert('Por favor, ingrese su nombre.');
                return false;
            }
            return true;
        },
        alCargar: () => {
            // Selecciona todos los textareas y sus contadores relacionados
            const textareas = document.querySelectorAll('.contenedor-textarea textarea');
            const counters = document.querySelectorAll('.contenedor-textarea .contador-text');

            // Itera sobre cada textarea para agregar un evento "input" y rellenar los valores existentes
            textareas.forEach((textarea, index) => {
                const id = textarea.id;

                if (datos[id]) {
                    textarea.value = datos[id];

                    const charCount = datos[id].length;
                    const maxLength = textarea.getAttribute('maxlength');
                    counters[index].textContent = `${charCount}/${maxLength}`;
                }
                textarea.addEventListener('input', function () {
                    const charCount = this.value.length;
                    const maxLength = this.getAttribute('maxlength');
                    counters[index].textContent = `${charCount}/${maxLength}`;
                });
            });
        }
    },
    {
        renderizar: () => `
      <h2>Paso 3: Confirmacion</h2>
      <p>Revisa los datos:</p>
      <pre>${JSON.stringify(datos, null, 2)}</pre>
    `,
        guardar: () => { },
        validar: () => true, // Siempre valido en el paso final
        alCargar: () => console.log('Paso 3 cargado.')
    }
];


// Enviar datos
const enviarDatos = async () => {
    try {
        const respuesta = await fetch('/api/enviar', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(datos)
        });
        const resultado = await respuesta.json();
        alert('Datos enviados con exito: ' + JSON.stringify(resultado));
    } catch (error) {
        console.error('Error al enviar los datos:', error);
    }
};

// Renderizar un paso
const renderizarPaso = () => {
    contenedor.innerHTML = pasos[pasoActual].renderizar();
    contenedorImagen.innerHTML = pasos[pasoActual].renderizarImagen();
    contenedorTitulo.innerHTML = pasos[pasoActual].renderizarTitulo();
    pasos[pasoActual].alCargar?.();
    renderizarBotones();
};

// Renderizar los botones de navegacion
const renderizarBotones = () => {
    grupoBotones.innerHTML = '';
    if (pasoActual > 0) {
        const botonAtras = document.createElement('button');
        const icono = document.createElement('i');
        const texto = document.createElement('span');
        botonAtras.className = 'btn-atras';
        icono.classList = 'fa-solid fa-chevron-left';
        texto.textContent = 'Atrás';
        botonAtras.appendChild(icono);
        botonAtras.appendChild(texto);

        botonAtras.addEventListener('click', () => {
            pasoActual--;
            renderizarPaso();
        });
        grupoBotones.appendChild(botonAtras);
    }

    const botonSiguiente = document.createElement('button');
    botonSiguiente.textContent = pasoActual < pasos.length - 1 ? 'Siguiente' : 'Publicar';
    botonSiguiente.classList = 'button-87-main';
    botonSiguiente.addEventListener('click', () => {
        if (pasos[pasoActual].validar()) {
            pasos[pasoActual].guardar();
            if (pasoActual < pasos.length - 1) {
                pasoActual++;
                renderizarPaso();
            } else {
                enviarDatos();
            }
        }
    });
    grupoBotones.appendChild(botonSiguiente);
};


// Inicializar el contenido
const contenedor = document.getElementById('contenido-dinamico');
const contenedorImagen = document.getElementById('contenedor-imagen');
const contenedorTitulo = document.getElementById('contenedor-titulo');
//const contenedorDatos = document.getElementById('contenedor-datos');
const grupoBotones = document.getElementById('grupo-botones');
renderizarPaso();










//import { galeriaImagenes } from "../general/galeriaFancybox.js";

//galeriaImagenes();
//document.addEventListener('DOMContentLoaded', () => {
//    // Inputs datos
//    const editables = [
//        { divId: 'DivInputTitulo', inputId: 'Titulo' },
//        { divId: 'DivInputDireccion', inputId: 'Direccion' },
//        { divId: 'DivInputDescripcion', inputId: 'Descripcion' }
//    ];

//    // Imagenes
//    const dropZone = document.getElementById('drop-zone');
//    const imageInput = document.getElementById('imageInput');
//    const previewContainer = document.getElementById('preview-container');
//    let fileList = [];

//    // Checkboxes inputs
//    const checkboxes = document.querySelectorAll('input[type="checkbox"]');

//    // Inputs fechas
//    const agregarFechaButtonSm = document.getElementById('agregar-fecha-sm');
//    const agregarFechaButtonLg = document.getElementById('agregar-fecha-lg');
//    const fechaInicialInput = document.getElementById('booking-busqueda-llegada');
//    const fechaFinalInput = document.getElementById('booking-busqueda-salida');
//    const fechasAgregadasContainer = document.getElementById('fechas-agregadas');
//    let indiceFechaNoDisponible = 0;


//    // Eventos DOM
//    // Eventos inputs
//    editables.forEach(({ divId, inputId }) => {
//        const div = document.getElementById(divId);
//        const input = document.getElementById(inputId);

//        if (div && input) {
//            const defaultValue = div.textContent.trim();

//            // Evento al enfocar (focus)
//            div.addEventListener('focus', () => {
//                if (div.textContent.trim() === defaultValue) {
//                    div.textContent = '';
//                }
//            });

//            // Evento al perder el foco (blur)
//            div.addEventListener('blur', () => {
//                const value = div.textContent.trim();
//                if (!value) {
//                    div.textContent = defaultValue;
//                    input.value = "";
//                } else {
//                    input.value = div.textContent;
//                }
//            });

//            // Evento mientras se escribe (input)
//            div.addEventListener('input', () => {
//                input.value = div.textContent;
//            });
//        } else {
//            console.error(`No se encontró el elemento con id "${divId}" o "${inputId}"`);
//        }
//    });


//    // Eventos imagenes
//    dropZone.addEventListener('dragover', (e) => {
//        e.preventDefault();
//        dropZone.classList.add('active');
//    });

//    dropZone.addEventListener('dragleave', () => {
//        dropZone.classList.remove('active');
//    });

//    dropZone.addEventListener('drop', (e) => {
//        e.preventDefault();
//        dropZone.classList.remove('active');
//        handleFiles(e.dataTransfer.files);
//    });

//    dropZone.addEventListener('click', () => {
//        imageInput.click();
//    });

//    imageInput.addEventListener('change', (e) => {
//        handleFiles(e.target.files);
//    });

//    // Evento checkboxes inputs
//    checkboxes.forEach(checkbox => {
//        checkbox.addEventListener('change', function () {
//            // Seleccionar el div contenedor más cercano
//            const container = this.closest('.checkbox-item');
//            const label = container.querySelector(`label[for="${this.id}"]`);

//            if (this.checked) {
//                container.classList.add('active');
//                label.classList.add('active');
//            } else {
//                container.classList.remove('active');
//                label.classList.remove('active');
//            }
//        });
//    });


//    // Función para agregar fechas
//    const agregarFecha = () => {
//        const fechaInicial = fechaInicialInput.value;
//        const fechaFinal = fechaFinalInput.value;

//        if (!fechaInicial || !fechaFinal) {
//            alert('Por favor, ingrese ambas fechas.');
//            return;
//        }

//        if (new Date(fechaInicial) > new Date(fechaFinal)) {
//            alert('La fecha inicial no puede ser mayor que la fecha final.');
//            return;
//        }

//        // Crear un nuevo elemento de fecha
//        const fechaItem = document.createElement('div');
//        fechaItem.classList.add('fecha-item');
//        fechaItem.innerHTML = `
//            <div class="fecha">
//                <div>
//                    <span class="fecha-agregada-titulo">Fecha Inicial</span>
//                    <input type="hidden" name="FechasNoDisponibles[${indiceFechaNoDisponible}].FechaInicial" value="${fechaInicial}" />
//                    <span class="fecha-agregada-valor">${fechaInicial}</span>
//                </div>
//                <div>
//                    <span class="fecha-agregada-titulo">Fecha Final</span>
//                    <input type="hidden" name="FechasNoDisponibles[${indiceFechaNoDisponible}].FechaFinal" value="${fechaFinal}" />
//                    <span class="fecha-agregada-valor">${fechaFinal}</span>
//                </div>
//            </div>
//            <button class="remove-fecha">
//                <i class="fa-solid fa-xmark"></i>
//            </button>
//        `;

//        fechasAgregadasContainer.appendChild(fechaItem);

//        // Limpiar los campos de entrada
//        fechaInicialInput.value = '';
//        fechaFinalInput.value = '';

//        // Incrementar el índice
//        indiceFechaNoDisponible++;
//    };

//    // Evento para agregar fechas
//    agregarFechaButtonSm.addEventListener('click', agregarFecha);
//    agregarFechaButtonLg.addEventListener('click', agregarFecha);

//    // Delegación de eventos para eliminar fechas
//    fechasAgregadasContainer.addEventListener('click', (event) => {
//        if (event.target.closest('.remove-fecha')) {
//            const fechaItem = event.target.closest('.fecha-item');
//            if (fechaItem) {
//                fechaItem.remove();
//            }
//        }
//    });


//    // Funciones imagenes
//    function handleFiles(files) {
//        Array.from(files).forEach((file) => {
//            if (!file.type.startsWith('image/')) return;

//            const reader = new FileReader();
//            reader.onload = (e) => {
//                const url = e.target.result;

//                fileList.push(file);

//                const previewItem = document.createElement('div');
//                previewItem.classList.add('preview-item');
//                previewItem.innerHTML = `
//                    <a href="${url}" data-fancybox="gallery">
//                        <img src="${url}" alt="Image">
//                        <button class="remove-btn">&times;</button>
//                    </a>
//                `;

//                previewItem.querySelector('.remove-btn').addEventListener('click', () => {
//                    const index = Array.from(previewContainer.children).indexOf(previewItem);
//                    fileList.splice(index, 1);
//                    previewItem.remove();
//                    updateInput();
//                });

//                previewContainer.appendChild(previewItem);
//                updateInput();
//            };
//            reader.readAsDataURL(file);
//        });
//    }

//    function updateInput() {
//        const dataTransfer = new DataTransfer();
//        fileList.forEach((file) => dataTransfer.items.add(file));
//        imageInput.files = dataTransfer.files;
//    }

//    Sortable.create(previewContainer, {
//        animation: 150,
//        onEnd: () => {
//            const sortedItems = Array.from(previewContainer.children);
//            fileList = sortedItems.map((item) => {
//                const index = Array.from(previewContainer.children).indexOf(item);
//                return fileList[index];
//            });
//            updateInput();
//        },
//    });
//});
