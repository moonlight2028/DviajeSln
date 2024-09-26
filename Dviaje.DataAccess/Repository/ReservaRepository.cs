using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IDbConnection _db;


        public ReservaRepository(IDbConnection db)
        {
            _db = db;
        }


        public async Task<ReservaMiReservaVM?> ObtenerReservaMiReservaAsync(int idReserva, string idUsuario)
        {
            // Corregir. Error: MySqlException: You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near '5 pi.Ruta FROM PublicacionImagenes pi WHERE pi.IdPublicacion = p.IdPublicacio...' at line 5
            //var sql = @"
            //    SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.NumeroPersonas, r.Estado AS ReservaEstado,
            //           p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion, p.NumeroResenas, p.Ubicacion,
            //           u.Id AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS Verificado,
            //           (SELECT TOP 5 pi.Ruta FROM PublicacionImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden) AS Imagen
            //    FROM Reservas r
            //    INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
            //    INNER JOIN aspnetusers u ON p.IdAliado = u.Id
            //    WHERE r.IdReserva = @IdReserva";

            //return await _db.QueryFirstOrDefaultAsync<ReservaMiReserva>(sql, new { IdReserva = idReserva });


            // Datos de test borrar cuando esté la consulta
            ReservaMiReservaVM datosTest = new ReservaMiReservaVM
            {
                IdPublicacion = 1,
                TituloPublicacion = "Titulo publicación ajdsklfjkaldsf adsfjakldsjfl aldkfjlkadsjfl adslkfjkladsjf aadkfjlkadj aldskfjkalds adsfjlkjdkls",
                PuntuacionPublicacion = 4.3m,
                NumeroReseñasPublicacion = 1156,
                Direccion = "Calle 186 #48 - 45",
                DescripcionPublicacion = "La comunicación efectiva es fundamental en todos los aspectos de la vida. Permite expresar ideas, compartir conocimientos y construir relaciones sólidas. En el ámbito profesional, la comunicación clara y precisa es clave para alcanzar objetivos, resolver conflictos y fomentar la colaboración. Además, una buena comunicación ayuda a motivar a los equipos, a mejorar la productividad y a garantizar el éxito en proyectos. Dominar esta habilidad es esencial para el desarrollo personal y profesional en un entorno cada vez más interconectado.",
                IdAliado = "DFSS",
                AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                NombreAliado = "Barca",
                VerificadoAliado = true,
                NumeroPublicacionesAliado = 4562,
                FechaInicial = new DateTime(2023, 11, 18),
                FechaFinal = new DateTime(2023, 11, 20),
                Personas = 10,
                ReservaEstado = ReservaEstado.Aprobado,
                Precio = 464165m,
                ServiciosAdicionalesPublicacion = new List<ServicioVM> {
                    new ServicioVM {
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                },
                ServiciosPublicacion = new List<ServicioVM> {
                    new ServicioVM {
                        IdServicio = 1,
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 2,
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 3,
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 4,
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 5,
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 6,
                        NombreServicio = "Visita a Viñedos",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 7,
                        NombreServicio = "Cena Romántica",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                },
                ImagenesPublicacion = new List<PublicacionImagenVM> {
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

            return datosTest;
        }

        public Task<ReservaMiReservaVM?> ObtenerReservaMiReservaPorAliadoAsync(int idReserva, string idAliado)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ReservaTarjetaBasicaVM>?> ObtenerListaReservaTarjetaBasicaVMAsync(int pagina = 1, int resultadosMostrados = 10, string? estado = null)
        {
            // Datos de test borrar cuando esté la consulta
            List<ReservaTarjetaBasicaVM>? datosTest = new List<ReservaTarjetaBasicaVM> {
                new ReservaTarjetaBasicaVM {
                    IdReserva = 2,
                    FechaInicial = new DateTime(2023, 11, 18),
                    FechaFinal = new DateTime(2023, 11, 20),
                    ReservaEstado = ReservaEstado.Aprobado,
                    IdPublicacion = 1,
                    TituloPublicacion = "Titulo publicación ajdsklfjkaldsf adsfjakldsjfl aldkfjlkadsjfl adslkfjkladsjf aadkfjlkadj aldskfjkalds adsfjlkjdkls",
                    PuntuacionPublicacion = 4.3m,
                    NumeroResenasPublicacion = 4561,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852911-ee5f5b49ea0d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "DASF",
                    NombreAliado = "Barca",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = true,
                    NumeroPublicacionesPublicacion  = 1542
                },
                new ReservaTarjetaBasicaVM {
                    IdReserva = 3,
                    FechaInicial = new DateTime(2024, 02, 15),
                    FechaFinal = new DateTime(2024, 02, 17),
                    ReservaEstado = ReservaEstado.Activo,
                    IdPublicacion = 2,
                    TituloPublicacion = "Escapada de fin de semana a las montañas",
                    PuntuacionPublicacion = 4.7m,
                    NumeroResenasPublicacion = 59,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726500087639-0a68be284497?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "XYZ123",
                    NombreAliado = "Mountain Escape",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = true,
                    NumeroPublicacionesPublicacion = 234
                },
                new ReservaTarjetaBasicaVM {
                    IdReserva = 4,
                    FechaInicial = new DateTime(2024, 03, 10),
                    FechaFinal = new DateTime(2024, 03, 12),
                    ReservaEstado = ReservaEstado.Cancelado,
                    IdPublicacion = 3,
                    TituloPublicacion = "Aventura tropical en la playa",
                    PuntuacionPublicacion = 3.8m,
                    NumeroResenasPublicacion = 481,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726677644019-c010b789cf12?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "BEACH789",
                    NombreAliado = "Tropical Vibes",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = false,
                    NumeroPublicacionesPublicacion = 674
                }
            };

            return datosTest;
        }

        public async Task<int> ObtenerTotalReservas(string idUsuario, string? estado)
        {
            return 10;
        }

        public async Task<ReservaCrearVM?> ObtenerReservaCrearVMAsync(int idPublicacion)
        {
            // Cargar en la consulta solo los datos de IdPublicacion , PrecioTotal, ServiciosAdicionales

            // Datos de test borrar cuando esté la consulta
            ReservaCrearVM datosTest = new ReservaCrearVM
            {
                IdPublicacion = idPublicacion,
                PrecioTotal = 1561524m,
                ServiciosAdicionales = new List<ServicioAdicionalVM> {
                    new ServicioAdicionalVM {
                        IdServicioAdicional = 1,
                        Precio = 45615m,
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        IdServicioAdicional = 2,
                        Precio = 4185615m,
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        IdServicioAdicional = 3,
                        Precio = 4895123m,
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        IdServicioAdicional = 4,
                        Precio = 4123m,
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioAdicionalVM {
                        IdServicioAdicional = 5,
                        Precio = 21345m,
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                }
            };

            return datosTest;
        }

        public async Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM)
        {
            var sql = @"
                INSERT INTO Reservas (FechaInicial, FechaFinal, NumeroPersonas, PrecioTotal, IdUsuario, IdPublicacion)
                VALUES (@FechaInicial, @FechaFinal, @NumeroPersonas, @PrecioTotal, @IdUsuario, @IdPublicacion)";

            var result = await _db.ExecuteAsync(sql, reservaCrearVM);

            return result > 0;
        }

        public async Task<bool> CancelarReservaAsync(int idReserva)
        {
            var sql = "UPDATE Reservas SET Estado = 'Cancelado' WHERE IdReserva = @IdReserva";
            var result = await _db.ExecuteAsync(sql, new { IdReserva = idReserva });
            return result > 0;
        }

        public Task<ReservaTarjetaResumenVM?> ObtenerReservaTarjetaResumenVMAsync(int idReserva, string idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReservaTablaItemVM>?> ObtenerListaReservaTablaItemVMAsync(string idAliado)
        {
            throw new NotImplementedException();
        }
    }
}
