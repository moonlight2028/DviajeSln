document.addEventListener("DOMContentLoaded", () => {
    const btnSolicitarVerificado = document.getElementById("btn-solicitar-verificado");
    if (btnSolicitarVerificado != null) {
        btnSolicitarVerificado.addEventListener("click", async (e) => {
            e.stopPropagation();
            e.preventDefault();

            const result = await Swal.fire({
                title: 'Solicitar verificado.',
                text: 'Al solicitar el verificado no podrás actualizar tu información hasta recibir respuesta.',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí, solicitar',
                cancelButtonText: 'Cancelar',
                customClass: {
                    confirmButton: 'confirmar-verificado',
                    cancelButton: 'cancelar-verificado'
                },
                didOpen: () => {
                    const confirmBtn = document.querySelector('.confirmar-verificado');
                    const cancelBtn = document.querySelector('.cancelar-verificado');

                    if (confirmBtn) confirmBtn.className = "button-87-main confirm-btn"
                    if (cancelBtn) cancelBtn.className = "button-23"
                }
            });

            if (result.isConfirmed) {
                try {
                    const response = await fetch('/verificado', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                            'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                        }
                    });

                    if (response.ok) {
                        window.location.reload();
                    }else {
                        Swal.fire('Error', 'Hubo un problema.', 'error');
                    }
                } catch (error) {
                    Swal.fire('Error', 'Error al solicitar el verificado.', 'error');
                }
            }
        })
    }
})
