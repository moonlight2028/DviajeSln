import { galeriaImagenes } from "../general/galeriaFancybox.js";
import { validacionInputFechas } from "../general/inputsFechas.js";


galeriaImagenes();


// Datos globales
const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
const formData = new FormData();
let datos = {
    titulo: null,
    descripcion: null,
    direccion: null,
    categoriaSeleccionada: null,
    propiedadSeleccionada: null,
    serviciosSeleccionados: [],
    restriccionesSeleccionadas: [],
    huespedes: 0,
    recamaras: 0,
    numeroCamas: 0,
    banios: 0,
    imagenes: [],
    fechasNoDisponibles: [],
    precioNoche: null
};

let pasoActual = 0;
let categoriasLista = [];
let tipoPropiedadLista = [];
let serviciosLista = {
    habitacion: null,
    accesibilidad: null,
    establecimiento: null
};
let restricciones = [];
let fileList;


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
                        <span class="input-placeholder">Título*</span>
                    </label>
                    <p class="contador-text">0/50</p>
                </div>

                <div class="contenedor-textarea">
                    <label for="descripcion" class="input-label">
                        <textarea id="descripcion" aria-required="true"
                                    class="input-field input-field-textarea" placeholder="Descripción"
                                    maxlength="500"></textarea>
                        <span class="input-placeholder">Descripción*</span>
                    </label>
                    <p class="contador-text">0/500</p>
                </div>
            </div>
        `,
        renderizarImagen: () => `<img src="https://images.unsplash.com/photo-1500835556837-99ac94a94552?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Imagen datos básicos en crear publicación" class="img-f" />`,
        renderizarTitulo: () => `<h1>Descubre lo esencial, vive la experiencia.</h1>`,
        guardar: () => {
            datos.titulo = document.getElementById('titulo').value.trim();
            datos.descripcion = document.getElementById('descripcion').value.trim();
        },
        validar: () => {
            const titulo = document.getElementById('titulo').value.trim();
            const descripcion = document.getElementById('descripcion').value.trim();
            if (!titulo) {
                return false;
            }
            if (!descripcion) {
                return false;
            }
            return true;
        },
        alCargar: () => {
            agregarEventosTextarea('.contenedor-textarea textarea', '.contenedor-textarea .contador-text');
            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
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
                        <span class="input-placeholder">Dirección*</span>
                    </label>
                    <p class="contador-text">0/100</p>
                </div>
            </div>
        `,
        renderizarImagen: () => `<img src="https://images.unsplash.com/photo-1479888230021-c24f136d849f?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="Imagen dirección en crear publicación" class="img-f" />`,
        renderizarTitulo: () => `<h1>Tu punto de partida hacia la aventura.</h1>`,
        guardar: () => {
            datos.direccion = document.getElementById('direccion').value.trim();
        },
        validar: () => {
            const direccion = document.getElementById('direccion').value.trim();
            if (!direccion) {
                return false;
            }
            return true;
        },
        alCargar: () => {
            agregarEventosTextarea('.contenedor-textarea textarea', '.contenedor-textarea .contador-text');
            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
        }
    },
    {
        renderizar: async () => {
            if (categoriasLista == null || categoriasLista.length < 1) {
                categoriasLista = await getDatos("/categorias");
            }

            return `
                <h2>Categoría</h2>
                <div class="lista-categorias">
                    ${categoriasLista.map(c => `
                            <input
                                type="radio"
                                name="categoria"
                                value="${c.idCategoria}" 
                                id="categoria-${c.idCategoria}" 
                                ${datos.categoriaSeleccionada === c.idCategoria.toString() ? 'checked' : ''} />
                            <label class="categoria-label" for="categoria-${c.idCategoria}">
                                <div class="categoria-label-texto">
                                    <span class="categoria-label-titulo">
                                        <i class="${c.rutaIcono}"></i>
                                        ${c.nombreCategoria}
                                    </span>
                                    <span class="categoria-label-descripcion">
                                        ${c.descripcion}
                                    </span>
                                </div>
                                <div class="categoria-label-imagen">
                                    <img src="${c.urlImagen}" alt="Categoria ${c.nombreCategoria}" />
                                </div>
                            </label>
                    `).join('')}
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Descubre la categoría perfecta para destacar.</h1>
        `,
        guardar: () => {},
        validar: () => {
            return !!datos.categoriaSeleccionada;
        },
        alCargar: () => {
            // Agregar eventos "change" para capturar cambios en los radio inputs
            const radios = document.querySelectorAll('input[name="categoria"]');
            radios.forEach(radio => {
                radio.addEventListener('change', (e) => {
                    datos.categoriaSeleccionada = e.target.value; // Actualizar el valor en tiempo real

                    agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
                });
            });

            // Si ya se seleccionó previamente, marcar el input correspondiente
            if (datos.categoriaSeleccionada) {
                const seleccionado = document.querySelector(`input[name="categoria"][value="${datos.categoriaSeleccionada}"]`);
                if (seleccionado) {
                    seleccionado.checked = true;
                }
            }

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
        }
    },
    {
        renderizar: async () => {
            if (tipoPropiedadLista == null || tipoPropiedadLista.length < 1) {
                tipoPropiedadLista = await getDatos(`/propiedades/${datos.categoriaSeleccionada}`);
            } else if (tipoPropiedadLista[0].idCategoria.toString() !== datos.categoriaSeleccionada) {
                tipoPropiedadLista = await getDatos(`/propiedades/${datos.categoriaSeleccionada}`);
                datos.propiedadSeleccionada = null;
            }

            return `
                <h2>Propiedad</h2>
                <div class="lista-propiedades">
                    ${tipoPropiedadLista.map(p => `
                        <input
                            type="radio"
                            name="propiedad"
                            value="${p.idPropiedad}" 
                            id="propiedad-${p.idPropiedad}" 
                            ${datos.propiedadSeleccionada === p.idPropiedad.toString() ? 'checked' : ''} />
                        <label class="propiedad-label" for="propiedad-${p.idPropiedad}">
                            <span class="propieadad-label-titulo">
                                <i class="${p.rutaIcono}"></i>
                                ${p.nombre}
                            </span>
                            <span class="propieadad-label-descripcion">
                                ${p.descripcion}
                            </span>
                        </label>
                    `).join('')}
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1504609773096-104ff2c73ba4?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Encuentra el lugar perfecto para tu estancia.</h1>
        `,
        guardar: () => { },
        validar: () => { return !!datos.propiedadSeleccionada; },
        alCargar: () => {
            const radios = document.querySelectorAll('input[name="propiedad"]');
            radios.forEach(radio => {
                radio.addEventListener('change', (e) => {
                    datos.propiedadSeleccionada = e.target.value; // Actualizar el valor en tiempo real

                    agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
                });
            });

            if (datos.propiedadSeleccionada) {
                const seleccionado = document.querySelector(`input[name="propiedad"][value="${datos.propiedadSeleccionada}"]`);
                if (seleccionado) {
                    seleccionado.checked = true;
                }
            }

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
        }
    },
    {
        renderizar: async () => {
            // Cargar servicios si aún no están cargados
            if (serviciosLista.habitacion == null) {
                let serviciosGet = await getDatos("/servicios");

                serviciosLista.habitacion = serviciosGet.filter(x => x.servicioTipo === "Habitacion");
                serviciosLista.establecimiento = serviciosGet.filter(x => x.servicioTipo === "Establecimiento");
                serviciosLista.accesibilidad = serviciosGet.filter(x => x.servicioTipo === "Accesibilidad");
            }

            // Generar HTML para cada tipo de servicio con una lista desplegable
            const renderServicios = (servicios, tipo) => `
                <div class="tipo-servicio">
                    <div class="contenedor-servicio-titulo" data-tipo="${tipo.toLowerCase()}">
                        <h3 class="tipo-titulo">${tipo}</h3>
                        <i class="fa-solid fa-chevron-down" id="icono-${tipo.toLowerCase()}"></i>
                    </div>
                    <div class="tipo-lista" id="lista-${tipo.toLowerCase()}" style="display: none;">
                        <div class="lista-servicios">
                            ${servicios.map(s => `
                                <div>
                                    <input
                                        type="checkbox"
                                        name="${tipo.toLowerCase()}" 
                                        value="${s.idServicio}" 
                                        id="servicio-${s.idServicio}" 
                                        ${datos.serviciosSeleccionados.includes(s.idServicio.toString()) ? 'checked' : ''} />
                                    <label class="servicio-item-label" for="servicio-${s.idServicio}">
                                        <i class="${s.rutaIcono}"></i>
                                        <span>${s.nombreServicio}</span>
                                    </label>
                                </div>
                            `).join('')}
                        </div>
                    </div>
                </div>
            `;

            return `
                <h2>Servicios</h2>
                <div class="desplegables-servicios">
                    ${renderServicios(serviciosLista.habitacion, "Habitación")}
                    ${renderServicios(serviciosLista.establecimiento, "Establecimiento")}
                    ${renderServicios(serviciosLista.accesibilidad, "Accesibilidad")}
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1498354178607-a79df2916198?q=80&w=1376&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Todo lo que necesitas para una experiencia inolvidable.</h1>
        `,
        guardar: () => {
            // Guardar los servicios seleccionados
            const checkboxes = document.querySelectorAll('input[type="checkbox"]');
            datos.serviciosSeleccionados = Array.from(checkboxes)
                .filter(checkbox => checkbox.checked)
                .map(checkbox => checkbox.value);
        },
        validar: () => {
            // Validar que al menos un servicio de habitación y uno de establecimiento estén seleccionados
            const serviciosHabitacion = serviciosLista.habitacion.map(s => s.idServicio.toString());
            const serviciosEstablecimiento = serviciosLista.establecimiento.map(s => s.idServicio.toString());

            const seleccionados = datos.serviciosSeleccionados || [];
            const tieneHabitacion = seleccionados.some(id => serviciosHabitacion.includes(id));
            const tieneEstablecimiento = seleccionados.some(id => serviciosEstablecimiento.includes(id));

            return tieneHabitacion && tieneEstablecimiento;
        },
        alCargar: () => {
            // Inicializar los eventos para las listas desplegables
            const titulos = document.querySelectorAll('.contenedor-servicio-titulo');
            titulos.forEach(titulo => {
                titulo.addEventListener('click', () => {
                    const tipo = titulo.getAttribute('data-tipo');
                    const lista = document.getElementById(`lista-${tipo}`);
                    const icono = document.getElementById(`icono-${tipo}`);
                    if (lista) {
                        lista.style.display = lista.style.display === 'none' ? 'block' : 'none';
                        icono.classList.toggle('icono-rotado');
                    }
                });
            });

            // Manejar la selección de checkboxes y validar el botón
            const checkboxes = document.querySelectorAll('input[type="checkbox"]');
            checkboxes.forEach(checkbox => {
                checkbox.addEventListener('change', () => {
                    pasos[pasoActual].guardar();

                    agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
                });
            });

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
        }
    },
    {
        renderizar: async () => {
            // Cargar servicios si aún no están cargados
            if (restricciones == null || restricciones.length < 1) {
                restricciones = await getDatos("/restricciones");
            }

            return `
                <h2>Restricciones</h2>
                <div class="contenedor-restricciones">
                    ${restricciones.map(r => `
                            <input
                                type="checkbox"
                                name="restriccion"
                                value="${r.idRestriccion}" 
                                id="restriccion-${r.idRestriccion}" 
                                ${datos.restriccionesSeleccionadas.includes(r.idRestriccion.toString()) ? 'checked' : ''} />
                            <label for="restriccion-${r.idRestriccion}" class="servicio-item-label">
                                <i class="${r.rutaIcono}"></i>
                                <span>${r.nombreRestriccion}</span>
                            </label>
                    `).join('')}
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1497302347632-904729bc24aa?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Define los detalles, asegura una experiencia transparente.</h1>
        `,
        guardar: () => {
            // Guardar los servicios seleccionados
            const checkboxes = document.querySelectorAll('input[type="checkbox"]');
            datos.restriccionesSeleccionadas = Array.from(checkboxes)
                .filter(checkbox => checkbox.checked)
                .map(checkbox => checkbox.value);
        },
        validar: () => {return true},
        alCargar: () => {
            const checkboxes = document.querySelectorAll('input[type="checkbox"]');
            checkboxes.forEach(checkbox => {
                checkbox.addEventListener('change', () => {
                    pasos[pasoActual].guardar();
                });
            });

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
        }
    },
    {
        renderizar: async () => {
            return `
                <h2>Detalles</h2>
                <div class="contenedor-detalles">
                    <div>
                        <label for="huespedes">Cantidad de Huespedes*</label>
                        <div class="input-group">
                            <button type="button" class="btn-decrement" data-target="huespedes"><i class="fas fa-minus"></i></button>
                            <input type="number" value="${datos.huespedes || 0}" id="huespedes" min="1" max="50" />
                            <button type="button" class="btn-increment" data-target="huespedes"><i class="fas fa-plus"></i></button>
                        </div>
                    </div>
                    <div>
                        <label for="recamaras">Cantidad de Recamaras</label>
                        <div class="input-group">
                            <button type="button" class="btn-decrement" data-target="recamaras"><i class="fas fa-minus"></i></button>
                            <input type="number" value="${datos.recamaras || 0}" id="recamaras" min="1" max="50" />
                            <button type="button" class="btn-increment" data-target="recamaras"><i class="fas fa-plus"></i></button>
                        </div>
                    </div>
                    <div>
                        <label for="camas">Numero de Camas</label>
                        <div class="input-group">
                            <button type="button" class="btn-decrement" data-target="camas"><i class="fas fa-minus"></i></button>
                            <input type="number" value="${datos.numeroCamas || 0}" id="camas" min="1" max="50" />
                            <button type="button" class="btn-increment" data-target="camas"><i class="fas fa-plus"></i></button>
                        </div>
                    </div>
                    <div>
                        <label for="banios">Numero de Baños</label>
                        <div class="input-group">
                            <button type="button" class="btn-decrement" data-target="banios"><i class="fas fa-minus"></i></button>
                            <input type="number" value="${datos.banios || 0}" id="banios" min="1" max="50" />
                            <button type="button" class="btn-increment" data-target="banios"><i class="fas fa-plus"></i></button>
                        </div>
                    </div>
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Diseña cada opción para ofrecer experiencias únicas.</h1>
        `,
        guardar: () => {
            datos.huespedes = parseInt(document.getElementById("huespedes").value, 10);
            datos.recamaras = parseInt(document.getElementById("recamaras").value, 10);
            datos.numeroCamas = parseInt(document.getElementById("camas").value, 10);
            datos.banios = parseInt(document.getElementById("banios").value, 10);
        },
        validar: () => { return datos.huespedes >= 1 && datos.huespedes <= 50; },
        alCargar: () => {
            const updateValue = (id, delta) => {
                const input = document.getElementById(id);
                let value = parseInt(input.value, 10) + delta;
                if (value < 0) value = 0;
                if (value > 50) value = 50;
                input.value = value;
                pasos[pasoActual].guardar();
                agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
            };

            document.querySelectorAll(".btn-decrement").forEach(button => {
                button.addEventListener("click", () => {
                    const target = button.getAttribute("data-target");
                    updateValue(target, -1);
                });
            });

            document.querySelectorAll(".btn-increment").forEach(button => {
                button.addEventListener("click", () => {
                    const target = button.getAttribute("data-target");
                    updateValue(target, 1);
                });
            });

            document.querySelectorAll("input[type='number']").forEach(input => {
                input.addEventListener("input", () => {
                    let value = parseInt(input.value, 10);
                    if (isNaN(value) || value < 1) value = 0;
                    if (value > 50) value = 50;
                    input.value = value;
                    pasos[pasoActual].guardar();
                    agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
                });
            });

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
        }
    },
    {
        renderizar: async () => {
            return `
                <h2>Imágenes</h2>
                <div>
                    <section class="upload-container">
                        <h2>Carga al menos 5 imágenes.</h2>
                        <div id="drop-zone" class="drop-zone">
                            <p>Arrastra y suelta tus imágenes aquí o haz clic para cargar</p>
                            <input type="file" id="imageInput" name="imagenes" accept="image/*" multiple>
                        </div>
                        <div id="preview-container" class="preview-container"></div>
                    </section>
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Muestra tu espacio, inspira experiencias.</h1>
        `,
        guardar: () => { },
        validar: () => { return datos.imagenes.length > 4; },
        alCargar: () => {
            const dropZone = document.getElementById('drop-zone');
            const imageInput = document.getElementById('imageInput');
            const previewContainer = document.getElementById('preview-container');
            fileList = datos.imagenes;

            // Mostrar imágenes previamente cargadas
            datos.imagenes.forEach((file) => {
                addImagePreview(file, file.content);
            });

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);

            // Eventos de arrastre
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
                imageInput.value = '';
            });

            function handleFiles(files) {
                Array.from(files).forEach((file) => {
                    if (!file.type.startsWith('image/')) return;

                    // Evitar duplicados comprobando el nombre y tamaño del archivo
                    if (fileList.some(f => f.name === file.name && f.size === file.size)) return;

                    const reader = new FileReader();
                    reader.onload = (e) => {
                        file.content = e.target.result;
                        fileList.push(file);
                        addImagePreview(file, file.content);
                        actualizarDatos();
                    };
                    reader.readAsDataURL(file);
                });
            }

            function addImagePreview(file, url) {
                const previewItem = document.createElement('div');
                previewItem.classList.add('preview-item');
                previewItem.innerHTML = `
                    <a href="${url}" data-fancybox="gallery">
                        <img src="${url}" alt="${file.name}">
                    </a>
                    <button class="remove-btn">&times;</button>
                `;

                previewItem.querySelector('.remove-btn').addEventListener('click', () => {
                    const index = fileList.indexOf(file);
                    if (index > -1) {
                        fileList.splice(index, 1);
                        previewItem.remove();
                        actualizarDatos();
                    }
                });

                previewContainer.appendChild(previewItem);
            }

            function actualizarDatos() {
                // Actualizamos el objeto datos con las imágenes cargadas
                datos.imagenes = fileList.map(file => ({
                    name: file.name,
                    content: file.content,
                    type: file.type,
                }));

                agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
            }

            // Sortable para reordenar imágenes
            Sortable.create(previewContainer, {
                animation: 150,
                onEnd: () => {
                    const sortedItems = Array.from(previewContainer.children);
                    fileList = sortedItems.map(item => {
                        const imgSrc = item.querySelector('img').src;
                        return fileList.find(f => f.content === imgSrc);
                    }).filter(Boolean);
                    actualizarDatos();
                },
            });
        }
    },
    {
        renderizar: async () => {
            return `
                <h2>Fechas no Disponibles</h2>
                <div class="buscar-fechas">
                    <div class="inputs-fechas">
                        <label class="input-label input-fecha">
                            <input type="date" autocomplete="on" aria-required="true" class="input-field"
                                placeholder="Fecha Inicial" id="booking-busqueda-llegada" />
                            <span class="input-placeholder">Fecha Inicial</span>
                        </label>

                        <label class="input-label input-fecha">
                            <input type="date" autocomplete="on" aria-required="true" class="input-field"
                                placeholder="Fecha Final" id="booking-busqueda-salida" />
                            <span class="input-placeholder">Fecha Final</span>
                        </label>
                        <button type="button" class="button-23 btn-fecha-sm" id="agregar-fecha-lg">Agregar Fecha</button>
                    </div>

                    <div class="fechas-agregadas" id="fechas-agregadas">
                    </div>

                    <button type="button" class="button-23 btn-fecha" id="agregar-fecha-sm">Agregar Fecha</button>
                </div>
            `;
        },
        renderizarImagen: () => `
            <img src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
                alt="Imagen dirección en crear publicación" 
                class="img-f" />
        `,
        renderizarTitulo: () => `
            <h1>Planifica con anticipación.</h1>
        `,
        guardar: () => { },
        validar: () => { return true },
        alCargar: () => {
            // Inputs fechas
            const agregarFechaButtonSm = document.getElementById('agregar-fecha-sm');
            const agregarFechaButtonLg = document.getElementById('agregar-fecha-lg');
            const fechaInicialInput = document.getElementById('booking-busqueda-llegada');
            const fechaFinalInput = document.getElementById('booking-busqueda-salida');
            const fechasAgregadasContainer = document.getElementById('fechas-agregadas');
            let indiceFechaNoDisponible = 0;
            let fechaActual = new Date().toISOString().split("T")[0];

            fechaInicialInput.min = fechaActual;
            fechaInicialInput.value = fechaActual;
            fechaFinalInput.min = fechaActual;
            fechaFinalInput.value = fechaActual;

            agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);

            fechaInicialInput.addEventListener("change", (e) => {
                e.stopPropagation();

                fechaFinalInput.min = fechaInicialInput.value;

                if (new Date(fechaFinalInput.value) < new Date(fechaInicialInput.value)) {
                    fechaFinalInput.value = fechaInicialInput.value;
                }
            });

            // Función para agregar fechas
            const agregarFecha = () => {
                const fechaInicial = fechaInicialInput.value;
                const fechaFinal = fechaFinalInput.value;

                if (!fechaInicial || !fechaFinal) {
                    alert('Por favor, ingrese ambas fechas.');
                    return;
                }

                if (new Date(fechaInicial) > new Date(fechaFinal)) {
                    alert('La fecha inicial no puede ser mayor que la fecha final.');
                    return;
                }

                // Guardar las fechas en el objeto 'datos'
                datos.fechasNoDisponibles.push({
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                });

                // Crear un nuevo elemento de fecha
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

                // Limpiar los campos de entrada
                fechaInicialInput.min = fechaActual;
                fechaInicialInput.value = fechaActual;
                fechaFinalInput.min = fechaActual;
                fechaFinalInput.value = fechaActual;

                // Incrementar el índice
                indiceFechaNoDisponible++;
            };

            // Evento para agregar fechas
            agregarFechaButtonSm.addEventListener('click', agregarFecha);
            agregarFechaButtonLg.addEventListener('click', agregarFecha);

            // Delegación de eventos para eliminar fechas
            fechasAgregadasContainer.addEventListener('click', (event) => {
                if (event.target.closest('.remove-fecha')) {
                    const fechaItem = event.target.closest('.fecha-item');
                    if (fechaItem) {
                        // Obtener el índice de la fecha a eliminar
                        const fechaIndex = Array.from(fechasAgregadasContainer.children).indexOf(fechaItem);

                        // Eliminar la fecha del objeto 'datos'
                        datos.fechasNoDisponibles.splice(fechaIndex, 1);

                        // Eliminar el elemento visualmente
                        fechaItem.remove();
                    }
                }
            });
        }
    },
    {
        renderizar: () => `
            <h2>Precio por Noche</h2>
            <div class="informacion-inputs">
                <div class="contenedor-textarea">
                    <label for="precio" class="input-label">
                        <input type="number" class="input-field" id="precio" placeholder="Ingresa un precio" />
                        <span class="input-placeholder">Precio</span>
                    </label>
                </div>
            </div>
        `,
        renderizarImagen: () => `
            <img 
                src="https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
                alt="Imagen datos básicos en crear publicación" 
                class="img-f" 
            />
        `,
        renderizarTitulo: () => `<h1>Establece el valor de cada noche inolvidable.</h1>`,
        guardar: () => {
            const precioInput = document.getElementById('precio');
            datos.precioNoche = parseFloat(precioInput.value.trim());
        },
        validar: () => {
            const precioInput = document.getElementById('precio');
            const precio = parseFloat(precioInput.value.trim());

            if (isNaN(precio)) {
                return false;
            }
            if (precio < 10000) {
                return false;
            }
            if (precio > 100000000) {
                return false;
            }
            if (!Number.isInteger(precio)) {
                return false;
            }
            return true;
        },
        alCargar: () => {
            const precioInput = document.getElementById('precio');
            const botonMain = document.querySelector("#grupo-botones .button-87-main");
            botonMain.textContent = "Publicar";

            // Si el valor existe en datos.precioNoche, cargarlo en el input
            if (datos.precioNoche !== undefined && !isNaN(datos.precioNoche)) {
                precioInput.value = datos.precioNoche;
            }

            // Guardar automáticamente el precio cada vez que se modifique el valor del input
            const guardarAutomaticamente = () => {
                datos.precioNoche = parseFloat(precioInput.value.trim());
            };

            // Validar al cambiar el valor del input
            const validarAlCambiar = () => {
                agregarValidacionBoton('.button-87-main', pasos[pasoActual].validar);
            };

            // Asociar eventos al input
            precioInput.addEventListener('input', () => {
                guardarAutomaticamente();
                validarAlCambiar();
            });

            validarAlCambiar();
        }
    }
];


// Funciones
// Enviar datos
const enviarDatos = async () => {
    formData.append('titulo', datos.titulo);
    formData.append('descripcion', datos.descripcion);
    formData.append('direccion', datos.direccion);
    formData.append('CategoriaSeleccionada', datos.categoriaSeleccionada);
    formData.append('propiedadSeleccionada', datos.propiedadSeleccionada);
    datos.serviciosSeleccionados.forEach(servicio => {
        formData.append('ServiciosSeleccionados', servicio);
    });
    datos.restriccionesSeleccionadas.forEach(restriccion => {
        formData.append('RestriccionesSeleccionadas', restriccion);
    });
    formData.append('huespedes', datos.huespedes);
    formData.append('recamaras', datos.recamaras);
    formData.append('numeroCamas', datos.numeroCamas);
    formData.append('banios', datos.banios);
    datos.fechasNoDisponibles.forEach((rango, index) => {
        formData.append(`FechasNoDisponibles[${index}].FechaInicial`, rango.fechaInicial);
        formData.append(`FechasNoDisponibles[${index}].FechaFinal`, rango.fechaFinal);
    });
    formData.append('precioNoche', datos.precioNoche);

    fileList.forEach((file) => {
        formData.append('imagenes', file);
    });

    document.getElementById('loader').classList.toggle('loader-hide');

    try {
        const response = await fetch('/publicacion/crear', {
            method: 'POST',
            headers: {
                'RequestVerificationToken': token
            },
            body: formData,
        });

        let errores = []; 

        if (response.ok) {
            window.location.href = "/publicaciones/mis-publicaciones";
        } else {
            const result = await response.json();

            if (response.status === 400) {
                errores.push("Errores de validación: " + result.mensaje);
                result.errores.forEach(error => {
                    errores.push(error);
                });
            } else {
                errores.push('Error en el servidor: ' + (result.message || 'Sin mensaje'));
            }
            Swal.fire({
                title: 'Errores',
                text: errores.join('\n'),
                icon: 'error',
                confirmButtonText: 'Cerrar'
            });
        }
    } catch (error) {
        Swal.fire({
            title: 'Errores',
            text: errores.join('\n'),
            icon: 'error',
            confirmButtonText: 'Cerrar'
        });
    } finally {
        document.getElementById('loader').classList.toggle('loader-hide');
    }
};


const getDatos = async (url, datosTitulo) => {
    try {
        const respuesta = await fetch(url);
        if (!respuesta.ok) {
            throw new Error(`HTTP error! status: ${respuesta.status}`);
        }

        return await respuesta.json();
    } catch (error) {
        console.error(`Error al obtener ${datosTitulo}:`, error.message || error);
        throw error;
    }
};


// Contador textarea
const agregarEventosTextarea = (textareaSelector, counterSelector) => {
    const textareas = document.querySelectorAll(textareaSelector);
    const counters = document.querySelectorAll(counterSelector);

    textareas.forEach((textarea, index) => {
        const id = textarea.id;

        // Rellena valores existentes al cargar
        if (datos[id]) {
            textarea.value = datos[id];
            const charCount = datos[id].length;
            const maxLength = textarea.getAttribute('maxlength');
            counters[index].textContent = `${charCount}/${maxLength}`;
        }

        // Actualiza el contador en tiempo real
        textarea.addEventListener('input', function () {
            const charCount = this.value.length;
            const maxLength = this.getAttribute('maxlength');
            counters[index].textContent = `${charCount}/${maxLength}`;
        });
    });
};

// Renderizar un paso
const renderizarPaso = async () => {
    await renderizarBotones();
    contenedor.innerHTML = await pasos[pasoActual].renderizar();
    contenedorImagen.innerHTML = pasos[pasoActual].renderizarImagen();
    contenedorTitulo.innerHTML = pasos[pasoActual].renderizarTitulo();
    pasos[pasoActual].alCargar?.();
};

// Renderizar los botones de navegacion
const renderizarBotones = async () => {
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

        botonAtras.addEventListener('click', async () => {
            pasoActual--;
            await renderizarPaso();
        });
        grupoBotones.appendChild(botonAtras);
    }

    const botonSiguiente = document.createElement('button');
    botonSiguiente.textContent = pasoActual < pasos.length - 1 ? 'Siguiente' : 'Publicar';
    botonSiguiente.classList = 'button-87-main btn-siguiente-deshabilitado';
    botonSiguiente.disabled = true;

    botonSiguiente.addEventListener('click', async () => {
        if (pasos[pasoActual].validar()) {
            pasos[pasoActual].guardar();

            if (pasoActual === pasos.length - 1) {
                await enviarDatos();
            } else {
                pasoActual++;
                await renderizarPaso();
            }
        }
    });

    grupoBotones.appendChild(botonSiguiente);
};

// Validación btn
const agregarValidacionBoton = (botonSelector, validarFn) => {
    const boton = document.querySelector(botonSelector);

    const actualizarEstadoBoton = () => {
        if (validarFn()) {
            boton.classList.remove('btn-siguiente-deshabilitado');
            boton.disabled = false;
        } else {
            boton.classList.add('btn-siguiente-deshabilitado');
            boton.disabled = true;
        }
    };

    // Vincular inputs para validar en tiempo real
    const inputs = document.querySelectorAll('.contenedor-textarea textarea');
    inputs.forEach(input => {
        input.addEventListener('input', actualizarEstadoBoton);
    });

    // Validar inicialmente
    actualizarEstadoBoton();
};


// Inicializar el contenido
const contenedor = document.getElementById('contenido-dinamico');
const contenedorImagen = document.getElementById('contenedor-imagen');
const contenedorTitulo = document.getElementById('contenedor-titulo');
const grupoBotones = document.getElementById('grupo-botones');
await renderizarPaso();
