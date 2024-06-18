import { swipers } from "./publicacionSwiper.js";
import { galeriaImagenes } from "./publicacionFancybox.js";
import { btnMostrarMas } from "./botones.js";
import { checksServiciosAdicionales } from "./publicacionServiciosAdicionales.js";


swipers();
galeriaImagenes();
btnMostrarMas("btn-descripcion", "Leer más", "Leer menos", "descripcion-texto-activo");
checksServiciosAdicionales();