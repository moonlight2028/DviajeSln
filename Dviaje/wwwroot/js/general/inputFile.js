export const inputTypeFile = () => {
    const fileInput = document.getElementById('fileInput');
    const fileDropZone = document.querySelector('.file-drop-zone');
    const fileList = document.getElementById('fileList');
    let filesArray = [];

    // Mostrar archivos cargados
    function updateFileList() {
        fileList.innerHTML = '';
        filesArray.forEach((file, index) => {
            const li = document.createElement('li');
            const div = document.createElement('div');
            const fileName = document.createElement('span');
            const fileSize = document.createElement('span');
            const deleteBtn = document.createElement('button');

            fileName.textContent = file.name;
            fileSize.textContent = `${(file.size / 1024).toFixed(2)} KB`;
            fileSize.classList.add('file-size');

            deleteBtn.textContent = 'X';
            deleteBtn.addEventListener('click', (e) => {
                e.stopPropagation();
                removeFile(index);
            });

            div.appendChild(fileName);
            div.appendChild(fileSize);
            li.appendChild(div);
            li.appendChild(deleteBtn);
            fileList.appendChild(li);
        });

        let list = new DataTransfer();
        filesArray.forEach(e => list.items.add(e));

        let data = list.files; 
        fileInput.files = data;
    }

    // Agregar archivos a la lista acumulada
    function addFiles(newFiles) {
        for (let file of newFiles) {
            // Evitar duplicados
            if (!filesArray.some(f => f.name === file.name && f.size === file.size)) {
                filesArray.push(file);
            }
        }
        updateFileList();
    }

    // Eliminar archivo de la lista
    function removeFile(index) {
        filesArray.splice(index, 1);
        updateFileList();
    }

    // Manejar arrastrar y soltar
    fileDropZone.addEventListener('dragover', (e) => {
        e.preventDefault();
        fileDropZone.classList.add('dragover');
    });

    fileDropZone.addEventListener('dragleave', () => {
        fileDropZone.classList.remove('dragover');
    });

    fileDropZone.addEventListener('drop', (e) => {
        e.preventDefault();
        fileDropZone.classList.remove('dragover');
        const files = e.dataTransfer.files;
        addFiles(files);
    });

    // Manejar selección de archivos
    fileInput.addEventListener('change', (e) => {
        const selectedFiles = Array.from(e.target.files); // Convierte el FileList a un Array
        addFiles(selectedFiles); // Agrega los archivos seleccionados
    });

    // Click para abrir el diálogo de archivos
    fileDropZone.addEventListener('click', (e) => {
        e.stopPropagation();
        fileInput.click();
    });
};



