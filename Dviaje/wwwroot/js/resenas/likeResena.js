export const likeResena = () => {
    const likeButtons = document.querySelectorAll('[data-like="resena"]');

    likeButtons.forEach((button) => {
        const resenaId = button.dataset.resenaId;
        const likeCountElement = document.querySelector(`#likeCount-${resenaId}`);
        const likeIcon = button.querySelector("i");

        button.addEventListener("click", () => {
            const url = "/Dviaje/Resenas/me-gusta";

            fetch(url, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "X-CSRF-TOKEN": document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({ idResena: parseInt(resenaId) }) // Asegurarse de que el ID sea numérico
            })
                .then((response) => {
                    if (!response.ok) {
                        throw new Error("Error en la solicitud: " + response.statusText);
                    }
                    return response.json();
                })
                .then((data) => {
                    if (data && typeof data.likes === "number") {
                        // Actualizar contador de likes
                        likeCountElement.textContent = data.likes;

                        // Actualizar estado del botón
                        if (data.yaLeDioLike) {
                            likeIcon.classList.replace("fa-regular", "fa-solid");
                            button.classList.add("liked");
                        } else {
                            likeIcon.classList.replace("fa-solid", "fa-regular");
                            button.classList.remove("liked");
                        }
                    } else {
                        console.warn("Respuesta inesperada del servidor", data);
                    }
                })
                .catch((error) => {
                    console.error("Error:", error);
                    alert("Ocurrió un error al intentar actualizar el 'Me Gusta'. Por favor, inténtalo más tarde.");
                });
        });
    });
};
