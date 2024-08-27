// Elementos barra de navegación main


document.addEventListener("click", (e) => {
    /* Lógica, menú desplegable */
    const desplegableBtn = e.target.closest('[data-desplegable]');
    const desplegableItems = document.querySelector('.desplegable-items-show');

    if (desplegableBtn) {
        const desplegableValor = desplegableBtn.getAttribute('data-desplegable');
        const items = document.querySelector(`[data-desplegable-items="${desplegableValor}"]`);

        // Alterna la visibilidad del menú
        if (items.classList.contains('desplegable-items-show')) {
            items.classList.replace('desplegable-items-show', 'desplegable-items');
            desplegableBtn.classList.remove('d-c-t-500');
        } else {
            if (desplegableItems) {
                desplegableItems.classList.replace('desplegable-items-show', 'desplegable-items');
            }
            items.classList.replace('desplegable-items', 'desplegable-items-show');
            desplegableBtn.classList.add('d-c-t-500');
        }
    } else if (desplegableItems && !desplegableItems.contains(e.target)) {
        // Oculta el menú si se hace clic fuera de él
        desplegableItems.classList.replace('desplegable-items-show', 'desplegable-items');
        const btnActivo = document.querySelector('.d-c-t-500');
        if (btnActivo) {
            btnActivo.classList.remove('d-c-t-500');
        }
    }
});



//// Elementos barra de navegación del menú mobile
//const btnMobileMenu = document.querySelector(".icono-menu");
//const menuMobile = document.querySelector(".items-mobile");

//document.addEventListener("click", (event) => {
//    // Barra de navegación del menú mobile
//    if (btnMobileMenu.contains(event.target)) {
//        // Si el clic es en el botón del menú, alternar la visibilidad del menú
//        if (menuMobile.classList.contains('items-mobile-show')) {
//            menuMobile.classList.replace('items-mobile-show', 'items-mobile');
//            btnMobileMenu.classList.replace('icono-menu-show','icono-menu');
//        } else {
//            menuMobile.classList.replace('items-mobile', 'items-mobile-show');
//            btnMobileMenu.classList.replace('icono-menu','icono-menu-show');
//        }
//    } else if (!menuMobile.contains(event.target) && menuMobile.classList.contains('items-mobile-show')) {
//        // Si el clic es fuera del menú y el menú está visible, ocultarlo
//        menuMobile.classList.replace('items-mobile-show', 'items-mobile');
//    }
//});




