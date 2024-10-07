import { inputTypeFile } from "../general/inputFile.js";

// Acordeón
const items = document.querySelectorAll(".accordion button");

function toggleAccordion() {
    const itemToggle = this.getAttribute('aria-expanded');

    items.forEach(item => item.setAttribute('aria-expanded', 'false'));

    if (itemToggle === 'false') {
        this.setAttribute('aria-expanded', 'true');
    }
}

items.forEach(item =>
    item.addEventListener('click', toggleAccordion)
);
// Fin Acordeón

inputTypeFile();
