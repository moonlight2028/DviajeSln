import { swipersTarjetasPublicacion } from "./publicacionesSwiper.js";
import { bookingBotonesFiltros, bookingFechaValidacion, bookingModalFiltros } from "./bookingNav.js";
import { estrellasPuntuacion } from "./estrellas.js";
import { renderPagination } from "./navPaginacion.js";

swipersTarjetasPublicacion();
bookingFechaValidacion();
bookingBotonesFiltros();
renderPagination();

// Modal Filtrar
bookingModalFiltros();
estrellasPuntuacion();
