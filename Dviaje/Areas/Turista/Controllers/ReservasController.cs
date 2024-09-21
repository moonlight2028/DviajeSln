using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = RolesUtility.RoleTurista)]
    public class ReservasController : Controller
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IEnvioEmail _envioEmail;

        // Constructor con inyección de dependencias para el repositorio de reservas y el servicio de envío de correos
        public ReservasController(IReservaRepository reservaRepository, IEnvioEmail envioEmail)
        {
            _reservaRepository = reservaRepository;
            _envioEmail = envioEmail;
        }

        // GET: Muestra el formulario para reservar una publicación específica
        public async Task<IActionResult> Reservar(int? idPublicacion)
        {
            // Verifica si el ID de publicación es válido
            if (!idPublicacion.HasValue)
            {
                return RedirectToAction("Index", "Publicaciones"); // Redirige si no hay una publicación seleccionada
            }

            // Inicializa un ViewModel de ReservaCrearVM para la vista
            var reservaFormulario = new ReservaCrearVM
            {
                IdPublicacion = idPublicacion.Value,
                ServiciosAdicionales = new List<ServicioAdicionalVM>() // Cargar servicios adicionales 
            };



            return View(reservaFormulario);
        }

        // POST: Crea y guarda una nueva reserva en la base de datos
        [HttpPost]
        public async Task<IActionResult> Reservar(ReservaCrearVM reservaFormCrear)
        {
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {
                return View(reservaFormCrear); // Devuelve el formulario con errores
            }

            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reservaFormCrear.IdUsuario = userId; // Asigna el ID del usuario (string) al ViewModel

            // Llama al método del repositorio para registrar la reserva
            var success = await _reservaRepository.RegistrarReservaAsync(reservaFormCrear);

            // Si la reserva es exitosa
            if (success)
            {
                // Opción para enviar correos de confirmación
                // await _envioEmail.EnviarCorreoDeReservaAsync(...);
                return RedirectToAction(nameof(MisReservas)); // Redirige a la lista de reservas
            }

            return View(reservaFormCrear); // Si falla, muestra nuevamente el formulario
        }

        // GET: Muestra la lista de reservas del usuario autenticado
        [Route("reservas/mis-reservas")]
        public async Task<IActionResult> MisReservas(int? pagina, string? estado)
        {
            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtiene todas las reservas del usuario a través del repositorio
            // implementar paginación,  en la consulta
            // Corregir. Error: MySqlException: Unknown column 'r.Estado' in 'field list'
            //var reservas = await _reservaRepository.GetAllReservasAsync(userId);


            // Paso de argumentos de paginación a la vista
            //ViewBag.PaginacionPaginas = paginasTotales;
            //ViewBag.PaginacionItems = numeroPublicaciones;
            //ViewBag.PaginacionResultados = publicacionesTotales;




            // Datos de test borrar cuando esté la consulta
            List<ReservaTarjetaV2VM>? datosTest = new List<ReservaTarjetaV2VM> {
                new ReservaTarjetaV2VM{
                    IdReserva = 2,
                    FechaInicial = new DateTime(2023, 11, 18),
                    FechaFinal = new DateTime(2023, 11, 20),
                    ReservaEstado = ReservaEstado.Aprobado,
                    IdPublicacion = 1,
                    TituloPublicacion = "Titulo publicación ajdsklfjkaldsf adsfjakldsjfl aldkfjlkadsjfl adslkfjkladsjf aadkfjlkadj aldskfjkalds adsfjlkjdkls",
                    PuntuacionPublicacion = 4.3m,
                    NumeroResenasPublicacion = 4561,
                    imagenPublicacion = "https://images.unsplash.com/photo-1726266852911-ee5f5b49ea0d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "DASF",
                    NombreAliado = "Barca",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = true,
                    NumeroPublicacionesAliado  = 1542
                },
                    new ReservaTarjetaV2VM{
                    IdReserva = 3,
                    FechaInicial = new DateTime(2024, 02, 15),
                    FechaFinal = new DateTime(2024, 02, 17),
                    ReservaEstado = ReservaEstado.Activo,
                    IdPublicacion = 2,
                    TituloPublicacion = "Escapada de fin de semana a las montañas",
                    PuntuacionPublicacion = 4.7m,
                    NumeroResenasPublicacion = 59,
                    imagenPublicacion = "https://images.unsplash.com/photo-1726500087639-0a68be284497?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "XYZ123",
                    NombreAliado = "Mountain Escape",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = true,
                    NumeroPublicacionesAliado = 234
                },
                new ReservaTarjetaV2VM{
                    IdReserva = 4,
                    FechaInicial = new DateTime(2024, 03, 10),
                    FechaFinal = new DateTime(2024, 03, 12),
                    ReservaEstado = ReservaEstado.Cancelado,
                    IdPublicacion = 3,
                    TituloPublicacion = "Aventura tropical en la playa",
                    PuntuacionPublicacion = 3.8m,
                    NumeroResenasPublicacion = 481,
                    imagenPublicacion = "https://images.unsplash.com/photo-1726677644019-c010b789cf12?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "BEACH789",
                    NombreAliado = "Tropical Vibes",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = false,
                    NumeroPublicacionesAliado = 674
                }
            };

            return View(datosTest);
        }

        // GET: Muestra los detalles de una reserva específica
        [Route("reserva/mi-reserva/{id?}")]
        public async Task<IActionResult> MiReserva(int? id)
        {
            // Verifica si el ID de la reserva es válido
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(MisReservas)); // Redirige si no se encuentra el ID de la reserva
            }

            // Obtiene los detalles de la reserva a través del repositorio
            // Corregir. Error: MySqlException: You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near '5 pi.Ruta FROM PublicacionImagenes pi WHERE pi.IdPublicacion = p.IdPublicacio...' at line 5
            // var reservaDetalles = await _reservaRepository.GetReservaByIdAsync(id.Value);

            // Si no se encuentra la reserva, redirige a la lista de reservas
            //if (reservaDetalles == null)
            //{
            //    return RedirectToAction(nameof(MisReservas));
            //}





            // Datos de test borrar cuando esté la consulta
            ReservaTarjetaV3VM datosTest = new ReservaTarjetaV3VM
            {
                IdPublicacion = 1,
                TituloPublicacion = "Titulo publicación ajdsklfjkaldsf adsfjakldsjfl aldkfjlkadsjfl adslkfjkladsjf aadkfjlkadj aldskfjkalds adsfjlkjdkls",
                Puntuacion = 4.3m,
                NumeroResenas = 1156,
                Ubicacion = "Calle 186 #48 - 45",
                Descripcion = "La comunicación efectiva es fundamental en todos los aspectos de la vida. Permite expresar ideas, compartir conocimientos y construir relaciones sólidas. En el ámbito profesional, la comunicación clara y precisa es clave para alcanzar objetivos, resolver conflictos y fomentar la colaboración. Además, una buena comunicación ayuda a motivar a los equipos, a mejorar la productividad y a garantizar el éxito en proyectos. Dominar esta habilidad es esencial para el desarrollo personal y profesional en un entorno cada vez más interconectado.",
                IdAliado = "DFSS",
                AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                NombreAliado = "Barca",
                Verificado = true,
                NumeroPublicaciones = 4562,
                IdReserva = 2,
                FechaInicial = new DateTime(2023, 11, 18),
                FechaFinal = new DateTime(2023, 11, 20),
                NumeroPersonas = 10,
                ReservaEstado = ReservaEstado.Aprobado,
                ServiciosAdicionales = new List<ServicioAdicionalVM> {
                    new ServicioAdicionalVM {
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                },
                Servicios = new List<Servicio> {
                    new Servicio {
                        IdServicio = 1,
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new Servicio {
                        IdServicio = 2,
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new Servicio {
                        IdServicio = 3,
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new Servicio {
                        IdServicio = 4,
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new Servicio {
                        IdServicio = 5,
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new Servicio {
                        IdServicio = 6,
                        NombreServicio = "Visita a Viñedos",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new Servicio {
                        IdServicio = 7,
                        NombreServicio = "Cena Romántica",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                },
                Imagen = new List<PublicacionImagenVM> {
                    new PublicacionImagenVM{
                        Ruta = "https://images.unsplash.com/photo-1726461974101-d98a3c616dcc?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Vista panorámica del paisaje al atardecer"
                    },
                    new PublicacionImagenVM{
                        Ruta = "https://images.unsplash.com/photo-1726533870778-8be51bf99bb1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Interior de una cabaña de lujo en la montaña"
                    },
                    new PublicacionImagenVM{
                        Ruta = "https://images.unsplash.com/photo-1726715245558-69afa5ded798?q=80&w=1925&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Turistas disfrutando de una caminata por el bosque"
                    },
                    new PublicacionImagenVM{
                        Ruta = "https://plus.unsplash.com/premium_photo-1699566447802-0551b84a186d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Piscina al aire libre con vistas a las montañas"
                    }
                }
            };


            return View(datosTest);
        }

        // DELETE: Cancela una reserva específica
        [HttpDelete]
        public async Task<IActionResult> CancelarReserva(int reservaId)
        {
            // Llama al método del repositorio para cancelar la reserva
            var success = await _reservaRepository.CancelarReservaAsync(reservaId);

            // Si la cancelación es exitosa, retorna una respuesta Ok
            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false }); // Si falla, retorna un error
        }
    }
}
