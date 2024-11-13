document.addEventListener("DOMContentLoaded", () => {
    const btnSolicitarVerificado = document.getElementById("btn-solicitar-verificado");
    if (btnSolicitarVerificado != null) {
        btnSolicitarVerificado.addEventListener("click", (e) => {
            e.stopPropagation();
            e.preventDefault();
        })
    }
})
