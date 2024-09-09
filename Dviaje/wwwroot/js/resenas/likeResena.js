export const likeResena = () => {
    const likeButtons = document.querySelectorAll('[data-like="resena"]');

    likeButtons.forEach((element) => {
        let likeIcon = element.querySelector("i");
        let resenaId = element.dataset.resenaId;
        let userHasLiked = element.dataset.userHasLiked === 'true'; // Verifica si el usuario ya ha dado "Me Gusta"

        element.addEventListener("click", () => {
            const url = `/Turista/Resena/MeGusta/${resenaId}`;
            const method = userHasLiked ? 'DELETE' : 'POST'; // Cambia entre agregar o eliminar "Me Gusta"

            fetch(url, {
                method: method,
                headers: {
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            })
                .then(response => response.json())
                .then(data => {
                    // Actualizar el contador de "Me Gusta" en el DOM
                    const meGustaCount = document.querySelector(`#me-gusta-count-${resenaId}`);
                    meGustaCount.textContent = data.meGusta;

                    if (method === 'POST') {
                        likeIcon.classList.replace("fa-regular", "fa-solid");
                        userHasLiked = true; // Cambia el estado a "liked"
                    } else {
                        likeIcon.classList.replace("fa-solid", "fa-regular");
                        userHasLiked = false; // Cambia el estado a "unliked"
                    }
                })
                .catch(error => console.error('Error:', error));
        });
    });
}
