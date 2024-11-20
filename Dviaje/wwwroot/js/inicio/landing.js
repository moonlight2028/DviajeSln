document.addEventListener("DOMContentLoaded", () => {
    const carouselItems = document.querySelectorAll(".carousel-item");
    const prevButton = document.querySelector(".carousel-control-prev");
    const nextButton = document.querySelector(".carousel-control-next");
    let currentIndex = 0;
    let autoPlayInterval = null;
    const autoPlayTime = 5000; // 5 segundos entre transiciones

    // Actualiza el estado del carrusel
    const updateCarousel = () => {
        carouselItems.forEach((item, index) => {
            item.classList.remove("active");
            item.style.transition = "opacity 0.5s ease"; // Suaviza la transici�n
            if (index === currentIndex) {
                item.classList.add("active");
            }
        });
    };

    // Funci�n para mover el carrusel al siguiente elemento
    const nextSlide = () => {
        currentIndex = (currentIndex + 1) % carouselItems.length;
        updateCarousel();
    };

    // Funci�n para mover el carrusel al elemento anterior
    const prevSlide = () => {
        currentIndex = (currentIndex - 1 + carouselItems.length) % carouselItems.length;
        updateCarousel();
    };

    // Iniciar la reproducci�n autom�tica
    const startAutoPlay = () => {
        stopAutoPlay(); // Asegura que no haya intervalos duplicados
        autoPlayInterval = setInterval(nextSlide, autoPlayTime);
    };

    // Detener la reproducci�n autom�tica
    const stopAutoPlay = () => {
        if (autoPlayInterval) {
            clearInterval(autoPlayInterval);
        }
    };

    // Escuchar eventos en los botones de control
    prevButton.addEventListener("click", () => {
        stopAutoPlay(); // Det�n temporalmente la reproducci�n autom�tica
        prevSlide();
        startAutoPlay(); // Reinicia despu�s del clic
    });

    nextButton.addEventListener("click", () => {
        stopAutoPlay(); // Det�n temporalmente la reproducci�n autom�tica
        nextSlide();
        startAutoPlay(); // Reinicia despu�s del clic
    });

    // Pausar reproducci�n autom�tica al pasar el mouse
    const carouselContainer = document.getElementById("template-mo-zay-hero-carousel");
    carouselContainer.addEventListener("mouseenter", stopAutoPlay);
    carouselContainer.addEventListener("mouseleave", startAutoPlay);

    // Inicializar
    updateCarousel();
    startAutoPlay();
});
