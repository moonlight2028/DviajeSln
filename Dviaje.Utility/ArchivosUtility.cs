namespace Dviaje.Utility
{
    /// <summary>
    /// Clase utilitaria que proporciona constantes y métodos relacionados con el manejo de archivos dentro de la aplicación.
    /// Incluye definiciones sobre tipos de archivos válidos, resoluciones de imágenes y las rutas asociadas a carpetas específicas.
    /// </summary>
    public static class ArchivosUtility
    {
        public static string[] ArchivosValidos = ["application/pdf", "image/jpeg", "image/png", "image/webp"];
        public static string[] ImagenesValidas = ["image/jpeg", "image/png", "image/webp"];
        public static List<(int ancho, int alto)> ResolucionesAvatar = [(50, 50), (200, 200)];
        public static int ResolucionAnchoBanner = 1920;
        public static int ResolucionAltoBanner = 350;
        public static string CarpetaAvatares = "avatares";
        public static string CarpetaBanners = "banners";


        /// <summary>
        /// Genera la ruta para la carpeta de PQRS (Preguntas, Quejas y Reclamos) asociada a un usuario en Cloudinary.
        /// </summary>
        /// <param name="id">ID del usuario para el cual se genera la ruta.</param>
        /// <returns>Ruta de almacenamiento en Cloudinary para los PQRS del usuario especificado.</returns>
        public static string CarpetaPQRS(int id) => $"pqrs/{id}";
    }
}
