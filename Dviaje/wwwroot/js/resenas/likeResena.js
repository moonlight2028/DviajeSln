export const likeResena = () => {
    const likeButtons = document.querySelectorAll('[data-like="resena"]');

    likeButtons.forEach((element, index) => {
        let likeIcon = element.querySelector("i");

        element.addEventListener("click", () => {
            const resenaId = element.dataset.resenaId;

            fetch(`/Turista/Resena/MeGusta/${resenaId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            })
                .then(response => response.json())
                .then(data => {
                    //  Me Gusta en el DOM
                    const meGustaCount = document.querySelector(`#me-gusta-count-${resenaId}`);
                    meGustaCount.textContent = data.meGusta;

                    // Cambiar el icono al estado seleccionado
                    likeIcon.classList.replace("fa-regular", "fa-solid");
                })
                .catch(error => console.error('Error:', error));
        });
    });
}
