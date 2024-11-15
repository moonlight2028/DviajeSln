using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Diagnostics;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class AdminBackupController : Controller
    {
        private const string BackupFolder = @"C:\backups\";
        private readonly string _connectionString;

        public AdminBackupController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Realiza una copia de seguridad de la base de datos y guarda el archivo en el directorio especificado.
        /// </summary>
        public IActionResult Backup()
        {
            try
            {
                string backupFileName = Path.Combine(BackupFolder, $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                // Configuración para ejecutar el proceso de mysqldump
                var startInfo = new ProcessStartInfo
                {
                    FileName = "mysqldump",
                    Arguments = $"--user=root --password= --host=localhost dviaje --result-file=\"{backupFileName}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Ejecuta el proceso de backup
                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // Captura y maneja errores de salida estándar
                    string errorOutput = process.StandardError.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        ViewBag.Message = "Error al hacer la copia de seguridad: " + errorOutput;
                    }
                    else
                    {
                        ViewBag.Message = $"Copia de seguridad completada exitosamente. Archivo: {backupFileName}";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al hacer la copia de seguridad: " + ex.Message;
            }

            return View();
        }

        /// <summary>
        /// Realiza una carga masiva de datos desde un archivo especificado y carga los datos en la base de datos.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> BulkInsert(IFormFile dataFile)
        {
            if (dataFile == null || dataFile.Length == 0)
            {
                ViewBag.Message = "No se proporcionó ningún archivo para la carga masiva.";
                return View();
            }

            try
            {
                // Guardar temporalmente el archivo de carga masiva
                string filePath = Path.Combine(Path.GetTempPath(), dataFile.FileName);
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dataFile.CopyToAsync(stream);
                }

                // Conexión a la base de datos
                await using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                // Usa parámetros para prevenir inyección SQL
                string query = $"LOAD DATA LOCAL INFILE '{filePath.Replace("\\", "/")}' INTO TABLE Usuarios " +
                               "FIELDS TERMINATED BY ',' ENCLOSED BY '\"' " +
                               "LINES TERMINATED BY '\\n' IGNORE 1 LINES";

                await using var cmd = new MySqlCommand(query, connection);
                await cmd.ExecuteNonQueryAsync();

                ViewBag.Message = "Carga masiva de datos completada exitosamente.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error durante la carga masiva: " + ex.Message;
            }

            return View();
        }
    }
}
