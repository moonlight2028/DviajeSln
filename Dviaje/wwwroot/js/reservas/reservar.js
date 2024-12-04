import { validacionInputFechas } from "../general/inputsFechas.js";

document.addEventListener("DOMContentLoaded", async () => {
    const titulo = document.getElementById("titulo-reserva");
    const contenedorTarjeta = document.getElementById('tarjeta-publicacion');

    validacionInputFechas("FechaInicial", "FechaFinal");


    const currentUrl = window.location.href;
    const segments = currentUrl.split('/');
    const id = parseInt(segments[segments.length - 1], 10);

    if (isNaN(id)) {
        console.error('No se pudo obtener un ID válido.');
    }


    const datos = await fetchImageData(id); 
    titulo.textContent = datos.titulo;
    const tarjeta = `
        <div class="publicacion-informacion">
            <img src="${datos.imagen}" alt="" class="img-f">
                <div class="publicacion-informacion-texto">
                    <div class="ubicacion-avatar">
                        <div class="publicacion-ubicacion">
                            <i class="fa-solid fa-location-dot"></i>
                            <span>${datos.direccion}</span>
                        </div>
                        <a href="/perfil/${datos.idAliado}" class="publicacion-avatar">
                            <img src="${datos.avatarAliado}" alt="Avatar del aliado ${datos.nombreAliado}" class="img-f">
                        </a>
                    </div>
                    <div class="publicacion-nota">
                        <span>${datos.puntuacion}</span>
                        <a href="/publicacion/${datos.idPublicacion}" class="button-23 button-23-mas">Ver Más</a>
                    </div>
                </div>
        </div>
    `;
    contenedorTarjeta.innerHTML = tarjeta;

});

const fetchImageData = async (id) => { 
    try {
        const response = await fetch(`/publicacion/imagen/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`Error en la solicitud: ${response.status}`);
        }

        const data = await response.json(); 
        return data;
    } catch (error) {
        console.error('Error al obtener los datos de la imagen:', error);
        throw error;
    }
};
