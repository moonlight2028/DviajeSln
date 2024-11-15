document.addEventListener("DOMContentLoaded", function () {
    const reservaForm = document.getElementById("reservaForm");

    reservaForm.addEventListener("submit", async function (e) {
        e.preventDefault();

        // Recoge los datos del formulario
        const formData = new FormData(reservaForm);

        try {
            const response = await fetch(reservaForm.action, {
                method: "POST",
                body: formData
            });

            const result = await response.json();
            const mensajeDiv = document.getElementById("reserva-mensaje");

            // Mostrar mensajes según el resultado
            if (result.success) {
                mensajeDiv.textContent = result.message;
                mensajeDiv.classList.add("alert-success");
            } else {
                mensajeDiv.textContent = result.message;
                mensajeDiv.classList.add("alert-danger");
            }

            mensajeDiv.style.display = "block";
        } catch (error) {
            console.error("Error al realizar la reserva", error);
        }
    });
});
