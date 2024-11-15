# Dviaje

## Plataforma 
- [.NET8](https://dotnet.microsoft.com/)

## Framework
- [ASP.NET / MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)

## ORMs
- [Dapper](https://github.com/DapperLib/Dapper)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)

## Autorización/Autenticación
- [Identity](https://learn.microsoft.com/aspnet/identity/)

## Servicios
- [Cloudinary](https://cloudinary.com/documentation/dotnet_integration)
- [Sendgrid](https://www.twilio.com/docs/sendgrid/for-developers/sending-email/email-api-quickstart-for-c)

## Librerías Backend
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/aspnet.html)
- [Imagesharp](https://docs.sixlabors.com/articles/imagesharp/index.html?tabs=tabid-1)
- [PomeloEntityFrameworkCoreMySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)

## Librerías Frontend
- [Chart.js](https://www.chartjs.org/)
- [Fancybox](https://fancyapps.com/fancybox/)
- [html2canvas](https://html2canvas.hertzen.com/documentation)
- [iziToast](https://marcelodolza.github.io/iziToast/)
- [jQuery](https://jquery.com/)
- [jsPDF](https://raw.githack.com/MrRio/jsPDF/master/docs/index.html)
- [Sweetalert2](https://sweetalert2.github.io/)
- [Swiper](https://swiperjs.com/)

## Rutas
### MVC Endpoints

| Endpoint                                               | Rol            | Descripción                                                  |T|
|--------------------------------------------------------|----------------|--------------------------------------------------------------|-|
| `gestion/servicios`                                    | Moderador      | Vista CRUD de servicios.                                     | | 
| `gestion/restricciones`                                | Moderador      | Vista CRUD de restricciones.                                 | |
| `gestion/categorias`                                   | Moderador      | Vista CRUD de categorías.                                    | |
| `favoritos?{pagina}`                                   | Turista        | Favoritos guardados por el usuario.                          | |
| `Identity/Account/Manage`                              | Turista        | Gestión de información básica del perfil.                    |✔|
| `Identity/Account/Manage/Aliado`                       | Turista        | Gestión de información del perfil relacionada con el aliado  | |
| `Identity/Account/Manage/Email`                        | Turista        | Gestión del correo electrónico.                              | |
| `Identity/Account/Manage/ChangePassword`               | Turista        | Gestión de la contraseña.                                    | |
| `Identity/Account/Manage/TwoFactorAuthentication`      | Turista        | Gestión de TF2.                                              |✔|
| `perfil?{id}`                                          | Público        | Perfil público.                                              | |
| `publicacion?{id}`                                     | Público        | Información completa de una publicación.                     | |
| `publicacion/crear`                                    | Aliado         | Registra una publicación en Dviaje.                          | |
| `publicacion/editar`                                   | Aliado         | Edita una publicación realizada por el aliado.               | |
| `publicaciones?{pagina}&&{ordenar}`                    | Público        | Lista de todas las publicaciones.                            | |
| `publicaciones/mis-publicaciones?{pagina}&&{ordenar}`  | Aliado         | Publicaciones realizadas por el aliado.                      | |
| `publicaciones/administrar`                            | Moderador      | Vista Datatable de publicaciones.                            | |
| `pqrs`                                                 | Público        | Crear PQRS.                                                  | |
| `pqrs/mis-pqrs`                                        | Turista        | Lista de PQRS enviados.                                      | |
| `pqrs/moderador`                                       | Moderador      | Vista de PQRS del Moderador.                                 | |
| `reportes/publicaciones`                               | Administrador  | Vista de reportes de publicaciones.                          | |
| `reseña/escribir?{id}`                                 | Turista        | Crea una reseña.                                             | |
| `reseñas?{id}`                                         | Público        | Vista de las reseñas de una publicación.                     | |
| `reseñas/disponibles?{pagina}`                         | Turista        | Reseñas disponibles que el usuario aún no ha realizado.      | |
| `reseñas/mis-reseñas?{pagina}`                         | Turista        | Reseñas escritas por el turista.                             | |
| `reseñas/recibidas?{pagina}&&{ordenar}`                | Aliado         | Reseñas recibidas de las publicaciones asociadas al aliado.  | |
| `reserva/mi-reserva?{id}`                              | Turista        | Detalles de la reserva.                                      | |
| `reservar?{id}`                                        | Turista        | Reserva una publicación.                                     | |
| `reservas/detalle?{id}`                                | Aliado         | Detalles de la reserva desde la vista del aliado.            | |
| `reservas/mis-reservas?{pagina}&&{estado}`             | Turista        | Reservas realizadas por el turista.                          | |

### API Endpoints

| Endpoint                                                | Verbo HTML    | Rol            | Descripción                                          |T|
|---------------------------------------------------------|---------------|----------------|------------------------------------------------------|-|
| `categorias`                                            | `HttpPost`    | Moderador      | Registra una categoría.                              | |
| `categorias`                                            | `HttpGet`     | Público        | Lista de todas las categorías registradas.           | |
| `categorias?{id}`                                       | `HttpGet`     | Moderador      | Obtiene una categoría.                               | |
| `categorias`                                            | `HttpPut`     | Moderador      | Registra una categoría.                              | |
| `categorias`                                            | `HttpDelete`  | Moderador      | Elimina una categoría.                               | |
| `favorito?{id}`                                         | `HttpPost`    | Turista        | Guarda una publicación en favoritos.                 | |
| `favorito?{id}`                                         | `HttpDelete`  | Turista        | Elimina una publicación de favoritos.                | |
| `pqrs/mensajes`                                         | `HttpPost`    | Turista        | Registra un mensaje en un PQRS.                      | |
| `pqrs/mensajes?{id}`                                    | `HttpGet`     | Turista        | Obtiene los mensajes de un PQRS.                     | |
| `publicacion/tarjeta-imagen`                            | `HttpGet`     | Público        | Datos de la tarjeta de una publicación.              | |
| `publicacion/estado`                                    | `HttpPut`     | Aliado         | Edita el estado de la publicación (activa/pausada).  | |
| `publicacion/estado`                                    | `HttpDelete`  | Aliado         | Asigna el estado "Eliminado" a la publicación.       | |
| `publicaciones/lista`                                   | `HttpGet`     | Moderador      | Lista básica de todas las publicaciones.             | |
| `publicaciones/reportes`                                | `HttpGet`     | Administrador  | Reporte de publicaciones.                            | |
| `reseñas/lista?{id}&&{pagina}&&{resultados-mostrados}`  | `HttpGet`     | Público        | Lista las reseñas de una publicación.                | |
| `reseña/like?{id}`                                      | `HttpPost`    | Turista        | Da like a una reseña.                                | |
| `reseña/like?{id}`                                      | `HttpDelete`  | Turista        | Elimina like de una reseña.                          | |
| `reserva/alido/cancelar?{id}`                           | `HttpPut`     | Aliado         | Cancela la reserva por el aliado.                    | |
| `reserva/cancelar?{id}`                                 | `HttpPut`     | Turista        | Cancela la reserva.                                  | |                  
| `reserva/resumen?{id}`                                  | `HttpGet`     | Turista        | Detalles resumen de la reserva.                      | |
| `reservas`                                              | `HttpGet`     | Aliado         | Todas las reservas solicitadas al aliado.            | |
| `restricciones`                                         | `HttpPost`    | Moderador      | Registra una restricción.                            | |
| `restricciones`                                         | `HttpGet`     | Público        | Lista de todas las restricciones.                    | |
| `restricciones?{id}`                                    | `HttpGet`     | Moderador      | Obtiene una restricción.                             | |
| `restricciones`                                         | `HttpPut`     | Moderador      | Registra una restricción.                            | |
| `restricciones`                                         | `HttpDelete`  | Moderador      | Elimina una restricción.                             | |
| `servicios`                                             | `HttpPost`    | Moderador      | Registra un servicio.                                | |
| `servicios`                                             | `HttpGet`     | Público        | Lista de todos los servicios registrados.            | |
| `servicios?{id}`                                        | `HttpGet`     | Moderador      | Obtiene un servicio.                                 | |
| `servicios`                                             | `HttpPut`     | Moderador      | Registra un servicio.                                | |
| `servicios`                                             | `HttpDelete`  | Moderador      | Elimina un servicio.                                 | |
| `verificado`                                            | `HttpPost`    | Aliado         | Solicita verificado con cuenta autenticada.          |✔|
