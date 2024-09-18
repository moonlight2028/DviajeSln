using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Diagnostics;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class AdminBackupController : Controller
    {
        private const string BackupFolder = @"C:\backups\";
        private string connectionString = "Server=localhost;Database=dviaje;User=root;Password=;AllowLoadLocalInfile=true;";

        // Acción para realizar la copia de seguridad
        public IActionResult Backup()
        {
            try
            {
                string backupFileName = Path.Combine(BackupFolder, $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                // Usar mysqldump para hacer el backup
                var startInfo = new ProcessStartInfo
                {
                    FileName = "mysqldump",
                    Arguments = $"--user=root --password= --host=localhost dviaje --result-file={backupFileName}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    string errorOutput = process.StandardError.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        ViewBag.Message = "Error al hacer la copia de seguridad: " + errorOutput;
                    }
                    else
                    {
                        ViewBag.Message = "Copia de seguridad completada exitosamente. Archivo: " + backupFileName;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al hacer la copia de seguridad: " + ex.Message;
            }

            return View();
        }

        // Acción para realizar la carga masiva de datos
        [HttpPost]
        public async Task<IActionResult> BulkInsert(IFormFile dataFile)
        {
            if (dataFile != null && dataFile.Length > 0)
            {
                try
                {
                    string filePath = Path.Combine(Path.GetTempPath(), dataFile.FileName);

                    // Guardar temporalmente el archivo
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await dataFile.CopyToAsync(stream);
                    }

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Comando para cargar los datos desde el archivo
                        string query = "LOAD DATA LOCAL INFILE '" + filePath.Replace("\\", "/") + "' INTO TABLE Usuarios FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n' IGNORE 1 LINES;";



                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        ViewBag.Message = "Carga masiva de datos completada.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error durante la carga masiva: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "No se proporcionó ningún archivo para la carga masiva.";
            }

            return View();
        }
    }
}
