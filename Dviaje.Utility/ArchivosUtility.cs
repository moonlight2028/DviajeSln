namespace Dviaje.Utility
{
    public static class ArchivosUtility
    {
        public static string[] ArchivosValidos = new[] { "application/pdf", "image/jpeg", "image/png", "image/webp" };
        public static string[] ImagenesValidas = new[] { "image/jpeg", "image/png", "image/webp" };

        public static string CarpetaPQRS(int id) => $"pqrs/{id}";
    }
}
