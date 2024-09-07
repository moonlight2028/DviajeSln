// Acordeón
const items = document.querySelectorAll(".accordion button");

function toggleAccordion() {
    const itemToggle = this.getAttribute('aria-expanded');

    items.forEach(item => item.setAttribute('aria-expanded', 'false'));

    if (itemToggle === 'false') {
        this.setAttribute('aria-expanded', 'true');
    }
}

items.forEach(item =>
    item.addEventListener('click', toggleAccordion)
);
// Fin Acordeón


// FilePond
// Registrar los plugins de FilePond
FilePond.registerPlugin(
    FilePondPluginFileValidateType, // Validar tipos de archivos
    FilePondPluginImageTransform, // Transformar (comprimir y cambiar formato de imágenes)
    FilePondPluginImageResize // Redimensionar imágenes
);

// Input
const inputCargaArchivos = document.getElementById("pqrs-carga-datos");

// Crear la instancia de FilePond con configuración personalizada
const pond = FilePond.create(inputCargaArchivos, {
    allowMultiple: true,
    acceptedFileTypes: ['image/*', 'application/pdf'],
    labelFileTypeNotAllowed: 'Solo se permiten archivos de imagen y PDF',

    // Configuración para redimensionar y optimizar imágenes
    imageResizeTargetWidth: 1000, // Redimensiona la imagen a un ancho máximo de 1000px
    imageResizeTargetHeight: 1000, // Redimensiona la imagen a un alto máximo de 1000px
    imageTransformOutputQuality: 0.7, // Calidad de imagen optimizada (0.7 = 70%)
    imageTransformOutputMimeType: 'image/webp', // Convierte las imágenes a WEBP

    // Cambiar el texto del botón
    labelIdle: 'Arrastra y suelta tus archivos o <span class="filepond--label-action">Explora</span>',
});
// Fin FilePond