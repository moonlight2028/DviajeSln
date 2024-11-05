document.addEventListener('DOMContentLoaded', function () {
    // Selecciona todos los contenedores de input de imagen
    var contenedoresAvatar = document.querySelectorAll('.contenedor-input-img, .contenedor-input-banner');;

    contenedoresAvatar.forEach(function (contenedor) {
        var inputArchivo = contenedor.querySelector('.input-archivo-img');
        var imagenAvatar = contenedor.querySelector('.imagen-avatar');

        // Evento para hacer clic en el contenedor y activar el input de carga
        contenedor.addEventListener('click', function () {
            inputArchivo.click();
        });

        // Evento para mostrar la imagen cargada
        inputArchivo.addEventListener('change', function (evento) {
            var archivo = evento.target.files[0];
            if (archivo) {
                var lector = new FileReader();
                lector.onload = function (e) {
                    imagenAvatar.src = e.target.result;
                }
                lector.readAsDataURL(archivo);
            }
        });
    });
});
