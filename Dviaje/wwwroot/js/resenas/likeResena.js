export const likeResena = () => {
    const likeButtons = document.querySelectorAll('[data-like="resena"]');

    likeButtons.forEach((element) => {
        let likeIcon = element.querySelector("i");
        let resenaId = element.dataset.resenaId;
        let userHasLiked = element.dataset.userHasLiked === 'true'; // Inicializa el estado de "Me Gusta"

        element.addEventListener("click", () => {
            const url = "/Dviaje/Resenas/me-gusta";

            fetch(url, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({ idResena: resenaId })
            })
                .then(response => response.json())
                .then(data => {
                    // Actualiza el contador de "Me Gusta" en el DOM
                    const meGustaCount = document.querySelector(`#likeCount-${resenaId}`);
                    meGustaCount.textContent = data.likes;

                    // Cambia el icono y el estado del botón según el nuevo valor
                    if (data.yaLeDioLike) {
                        likeIcon.classList.replace("fa-regular", "fa-solid");
                        element.classList.add("liked");
                        userHasLiked = true;
                    } else {
                        likeIcon.classList.replace("fa-solid", "fa-regular");
                        element.classList.remove("liked");
                        userHasLiked = false;
                    }
                })
                .catch(error => console.error('Error:', error));
        });
    });
}
