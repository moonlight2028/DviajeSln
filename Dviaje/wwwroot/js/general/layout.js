const menuAvatarNavMain = document.querySelector(".nav-principal-avatar");

document.addEventListener("click", (event) => {
    // Menú desplegable
    const btnMenuDesplegable = event.target.closest('.menu-desplegable-boton');
    const btnMenuDesplegableContenido = event.target.closest('.menu-desplegable-contenido');

    if (btnMenuDesplegable) {
        // Cerrar otros menús desplegables antes de abrir el actual
        const menusDesplegables = document.querySelectorAll('.menu-desplegable-contenido.show');
        menusDesplegables.forEach(menu => {
            if (menu !== btnMenuDesplegable.nextElementSibling) {
                menu.classList.remove('show');
            }
        });

        // Alternar el menú seleccionado
        const contenido = btnMenuDesplegable.nextElementSibling;
        contenido.classList.toggle('show');

        // Menú avatar nav principal
        if (btnMenuDesplegable.classList.contains("nav-principal-avatar")) {
            menuAvatarNavMain.classList.toggle("principal-avatar-show");
        }
    } else if (!btnMenuDesplegableContenido && !event.target.closest('.menu-desplegable')) {
        // Cerrar el menú avatar nav principal
        if (menuAvatarNavMain != null) {
            menuAvatarNavMain.classList.remove("principal-avatar-show");
        }

        // Cerrar todos los menús desplegables si se hace clic fuera de ellos
        const menusDesplegables = document.querySelectorAll('.menu-desplegable-contenido');
        menusDesplegables.forEach(menu => {
            menu.classList.remove('show');
        });
    }
});
