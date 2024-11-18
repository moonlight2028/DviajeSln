import { galeriaImagenes } from "../general/galeriaFancybox.js";

galeriaImagenes();
document.addEventListener('DOMContentLoaded', () => {

    const dropZone = document.getElementById('drop-zone');
    const imageInput = document.getElementById('imageInput');
    const previewContainer = document.getElementById('preview-container');
    let fileList = [];

    dropZone.addEventListener('dragover', (e) => {
        e.preventDefault();
        dropZone.classList.add('active');
    });

    dropZone.addEventListener('dragleave', () => {
        dropZone.classList.remove('active');
    });

    dropZone.addEventListener('drop', (e) => {
        e.preventDefault();
        dropZone.classList.remove('active');
        handleFiles(e.dataTransfer.files);
    });

    dropZone.addEventListener('click', () => {
        imageInput.click();
    });

    imageInput.addEventListener('change', (e) => {
        handleFiles(e.target.files);
    });

    function handleFiles(files) {
        Array.from(files).forEach((file) => {
            if (!file.type.startsWith('image/')) return;

            const reader = new FileReader();
            reader.onload = (e) => {
                const url = e.target.result;

                fileList.push(file);

                const previewItem = document.createElement('div');
                previewItem.classList.add('preview-item');
                previewItem.innerHTML = `
                    <a href="${url}" data-fancybox="gallery">
                        <img src="${url}" alt="Image">
                        <button class="remove-btn">&times;</button>
                    </a>
                `;

                previewItem.querySelector('.remove-btn').addEventListener('click', () => {
                    const index = Array.from(previewContainer.children).indexOf(previewItem);
                    fileList.splice(index, 1);
                    previewItem.remove();
                    updateInput();
                });

                previewContainer.appendChild(previewItem);
                updateInput();
            };
            reader.readAsDataURL(file);
        });
    }

    function updateInput() {
        const dataTransfer = new DataTransfer();
        fileList.forEach((file) => dataTransfer.items.add(file));
        imageInput.files = dataTransfer.files;
    }

    Sortable.create(previewContainer, {
        animation: 150,
        onEnd: () => {
            const sortedItems = Array.from(previewContainer.children);
            fileList = sortedItems.map((item) => {
                const index = Array.from(previewContainer.children).indexOf(item);
                return fileList[index];
            });
            updateInput();
        },
    });
});
