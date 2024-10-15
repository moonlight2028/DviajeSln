document.addEventListener("click", (e) => {
    e.stopPropagation();

    const sideMenu = document.querySelector(".menu-lateral-contenido");
    const inputSideMenu = document.getElementById("nav-menu-lateral");
    if (!sideMenu.contains(e.target) && e.target !== inputSideMenu) {
        if (inputSideMenu.checked == false) {
            inputSideMenu.checked = true;
        }
    }
});
