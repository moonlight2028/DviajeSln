// Elementos barra de navegación del menú mobile
const btnMobileMenu = document.querySelector(".icono-menu");
const menuMobile = document.querySelector(".items-mobile");

document.addEventListener("click", (event) => {
    // Barra de navegación del menú mobile
    if (btnMobileMenu.contains(event.target)) {
        // Si el clic es en el botón del menú, alternar la visibilidad del menú
        if (menuMobile.classList.contains('items-mobile-show')) {
            menuMobile.classList.replace('items-mobile-show', 'items-mobile');
            btnMobileMenu.classList.replace('icono-menu-show','icono-menu');
        } else {
            menuMobile.classList.replace('items-mobile', 'items-mobile-show');
            btnMobileMenu.classList.replace('icono-menu','icono-menu-show');
        }
    } else if (!menuMobile.contains(event.target) && menuMobile.classList.contains('items-mobile-show')) {
        // Si el clic es fuera del menú y el menú está visible, ocultarlo
        menuMobile.classList.replace('items-mobile-show', 'items-mobile');
    }
});




