using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = RolesUtility.RoleTurista)]
    public class ResenasController : Controller
    {
        private readonly IResenasRepository _resenaRepository;

        public ResenasController(IResenasRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
        }

        // Acción para mostrar las reseñas con más "Me Gusta"
        public async Task<IActionResult> TopResenas(int cantidad = 10)
        {
            var resenasTop = await _resenaRepository.ObtenerResenasTopAsync(cantidad);

            if (resenasTop == null || !resenasTop.Any())
            {
                return View("SinResenas");
            }

            return View(resenasTop);
        }

        // Muestra las reseñas disponibles para que el usuario pueda reseñar
        [Route("reseñas/disponibles/{pagina?}")]
        public async Task<IActionResult> Disponibles(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado

            var paginaActual = pagina ?? 1;
            // Corregir. Error: MySqlException: Unknown column 'p.ImagenUrl' in 'field list'
            //var resenasDisponibles = await _resenaRepository.ObtenerResenasDisponiblesAsync(userId, paginaActual);




            // Datos de test borrar cuando esté la consulta
            List<ResenaDisponibleTarjetaVM>? datosTest = new List<ResenaDisponibleTarjetaVM> {
                new ResenaDisponibleTarjetaVM {
                    TituloPublicacion = "Aventura en la Montaña",
                    DescripcionPublicacion = "Una experiencia inolvidable rodeado de naturaleza, perfecta para quienes buscan desconectarse y disfrutar del aire libre.",
                    IdPublicacion = 2,
                    PuntuacionPublicacion = 4.8m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 3,
                    FechaInicial = new DateTime(2024, 01, 15),
                    FechaFinal = new DateTime(2024, 01, 18)
                },
                new ResenaDisponibleTarjetaVM {
                    TituloPublicacion = "Relax en la Playa",
                    DescripcionPublicacion = "El lugar perfecto para relajarse con vistas al mar, disfrutar de la tranquilidad y desconectar del mundo.",
                    IdPublicacion = 3,
                    PuntuacionPublicacion = 4.5m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 4,
                    FechaInicial = new DateTime(2024, 02, 05),
                    FechaFinal = new DateTime(2024, 02, 10)
                },
                new ResenaDisponibleTarjetaVM {
                    TituloPublicacion = "Escapada Rural",
                    DescripcionPublicacion = "Una hermosa casa de campo con vistas espectaculares, ideal para una escapada romántica o con amigos.",
                    IdPublicacion = 4,
                    PuntuacionPublicacion = 4.9m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 5,
                    FechaInicial = new DateTime(2024, 03, 12),
                    FechaFinal = new DateTime(2024, 03, 15)
                },
                new ResenaDisponibleTarjetaVM {
                    TituloPublicacion = "Tour en la Ciudad",
                    DescripcionPublicacion = "Descubre los secretos y maravillas de la ciudad con este tour guiado por los principales puntos de interés.",
                    IdPublicacion = 5,
                    PuntuacionPublicacion = 4.3m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 6,
                    FechaInicial = new DateTime(2024, 04, 02),
                    FechaFinal = new DateTime(2024, 04, 05)
                },
                new ResenaDisponibleTarjetaVM {
                    TituloPublicacion = "Aventura en la Selva",
                    DescripcionPublicacion = "Una experiencia emocionante para quienes buscan adentrarse en la selva y vivir la naturaleza de cerca.",
                    IdPublicacion = 6,
                    PuntuacionPublicacion = 4.7m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 7,
                    FechaInicial = new DateTime(2024, 05, 10),
                    FechaFinal = new DateTime(2024, 05, 15)
                }
            };

            return View(datosTest);
        }

        // Muestra las reseñas realizadas por el usuario
        [Route("reseñas/mis-reseñas/{pagina?}")]
        public async Task<IActionResult> MisReseñas(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var paginaActual = pagina ?? 1;

            // Corregir debe retornar una lista del modelo ResenaTarjetaV2VM
            // var resenas = await _resenaRepository.ObtenerMisResenasAsync(userId, paginaActual);




            // Datos de test borrar cuando esté la consulta
            List<ResenasTarjetaV2VM>? datosTest = new List<ResenasTarjetaV2VM>
            {
                new ResenasTarjetaV2VM
                {
                    IdPublicacion = 1,
                    TituloPublcacion = "Aventura en la Montaña",
                    Opinion = "Una experiencia increíble, todo estuvo perfecto.",
                    Fecha = new DateTime(2024, 1, 15),
                    Puntuacion = 4.8m,
                    MeGusta = 120,
                    IdAliado = "A123",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Juan Pérez",
                    NumeroPublicacionesAliado = 15,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenasTarjetaV2VM
                {
                    IdPublicacion = 2,
                    TituloPublcacion = "Relajación en la Playa",
                    Opinion = "El lugar es hermoso, pero el servicio podría mejorar.",
                    Fecha = new DateTime(2023, 8, 23),
                    Puntuacion = 3.7m,
                    MeGusta = 85,
                    IdAliado = "B456",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "María Gómez",
                    NumeroPublicacionesAliado = 10,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenasTarjetaV2VM
                {
                    IdPublicacion = 3,
                    TituloPublcacion = "Escapada Rural",
                    Opinion = "La cabaña era acogedora y perfecta para desconectar.",
                    Fecha = new DateTime(2024, 2, 10),
                    Puntuacion = 4.5m,
                    MeGusta = 95,
                    IdAliado = "C789",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Pedro Sánchez",
                    NumeroPublicacionesAliado = 8,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenasTarjetaV2VM
                {
                    IdPublicacion = 4,
                    TituloPublcacion = "Tour por la Ciudad klajdslkfjalk adslkfjalksd aldkjflkads alsdkjflk adkjflkadsjf adkfjlkadsjfl asdfjkladsjf adfjlkadsjflk",
                    Opinion = "La tecnología avanza rápidamente, transformando la forma en que vivimos y trabajamos. Adaptarse a estos cambios es clave para mantenerse competitivo. Aprender nuevas habilidades y mejorar constantemente es esencial en un mundo donde la innovación es la norma diaria.",
                    Fecha = new DateTime(2023, 11, 18),
                    Puntuacion = 4.9m,
                    MeGusta = 135,
                    IdAliado = "D321",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Ana López",
                    NumeroPublicacionesAliado = 20,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenasTarjetaV2VM
                {
                    IdPublicacion = 5,
                    TituloPublcacion = "Viaje en Familia",
                    Opinion = "Todo estuvo bien, aunque la comida no fue tan buena.",
                    Fecha = new DateTime(2023, 5, 5),
                    Puntuacion = 3.9m,
                    MeGusta = 65,
                    IdAliado = "E654",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Carlos Ruiz",
                    NumeroPublicacionesAliado = 12,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                }
            };

            return View(datosTest);
        }

        // Crea una nueva reseña asociada a una reserva
        [Route("reseña/escribir/{id?}")]
        public IActionResult Crear(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Disponibles));
            }

            // Agregar validaciones de lógica de negocio

            var resenaFormulario = new ResenaCrearVM
            {
                IdReserva = id.Value
            };

            return View(resenaFormulario);
        }

        // POST: Guarda la nueva reseña
        [HttpPost]
        public async Task<IActionResult> Crear(ResenaCrearVM resenaCrear)
        {
            if (!ModelState.IsValid)
            {
                return View(resenaCrear);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var validacion = await _resenaRepository.ValidarReservaParaResenaAsync(resenaCrear.IdReserva, userId);

            if (!validacion)
            {
                return RedirectToAction(nameof(MisReseñas));
            }

            var success = await _resenaRepository.CrearResenaAsync(resenaCrear);
            if (success)
            {
                return RedirectToAction(nameof(MisReseñas));
            }

            return View(resenaCrear);
        }

        // POST: Incrementa el contador de "Me Gusta" en una reseña (usando endpoint asíncrono)
        [HttpPost]
        [ActionName("MeGusta")]
        public async Task<IActionResult> CrearMeGusta(int? idResena)
        {
            if (!idResena.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _resenaRepository.AgregarMeGustaAsync(idResena.Value, userId);
            if (success)
            {
                var meGustaCount = await _resenaRepository.ObtenerMeGustaCountAsync(idResena.Value);
                return Ok(new { meGusta = meGustaCount });
            }

            return BadRequest();
        }


        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta(int? idResena)
        {
            if (!idResena.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _resenaRepository.EliminarMeGustaAsync(idResena.Value, userId);
            if (success)
            {
                var meGustaCount = await _resenaRepository.ObtenerMeGustaCountAsync(idResena.Value);
                return Ok(new { meGusta = meGustaCount });
            }

            return BadRequest();
        }

    }
}

