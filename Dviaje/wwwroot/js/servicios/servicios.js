document.addEventListener("DOMContentLoaded", function () {
    // datos
    let datosServicios = await obtenerDatos("/servicios");




    // Selecciona la tabla usando su id
    var tabla = document.getElementById('miTabla');

    // Verifica si DataTables ya está cargado antes de inicializarlo
    if (typeof $.fn.dataTable === 'function') {
        new DataTable(tabla);  // Inicializa DataTables en la tabla
    }
});











// Funciones
async function obtenerDatos(url) {
    try {
        // Hacemos la solicitud GET
        const respuesta = await fetch(url);

        // Verificamos si la respuesta es exitosa (status 200)
        if (!respuesta.ok) {
            throw new Error('Error en la respuesta de la red');
        }

        // Parseamos la respuesta como JSON
        const datos = await respuesta.json();

        return datos;
    } catch (error) {
        // Si ocurre un error, lo mostramos
        console.error('Hubo un error al obtener los datos:', error);
    }
}