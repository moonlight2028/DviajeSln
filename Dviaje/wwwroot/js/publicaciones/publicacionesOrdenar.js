export const publicacionesOrdenar = (filtro, items) => {
    // Valores para el Query
    const dataOrdenar = items.map(elemento =>
        elemento
            .toLowerCase()
            .normalize('NFD')
            .replace(/[\u0300-\u036f]/g, '')
            .replace(/ /g, '_')
    );

    // Creación del template del filtro ordenar
    let templateOrdenar = `
    <button class="menu-desplegable-boton" id="btn-ordenar">${items[0]}</button>
    <div class="menu-desplegable-contenido b-s-95" id="items-ordenar">
        ${items.map((valor, index) => {
        if (index !== 0) {
            return `<div data-ordenar="${dataOrdenar[index]}">${valor}</div>`
        }
    }).join('')}
    </div>`.trim();

    // Carga del template filtro ordenar
    filtro.innerHTML = templateOrdenar;
}
