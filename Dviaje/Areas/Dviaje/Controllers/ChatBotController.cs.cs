using Dviaje.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Chat.Controllers
{
    [Area("Chat")]
    public class ChatBotController : Controller
    {
        // Acción para mostrar la interfaz del chatbot
        public IActionResult Chat()
        {
            return View(); // Renderiza la vista Chat.cshtml
        }

        // Acción para recibir la pregunta y devolver la respuesta
        [HttpPost]
        public IActionResult ObtenerRespuesta(string pregunta)
        {
            string respuesta = BuscarRespuesta(pregunta);
            if (string.IsNullOrEmpty(respuesta))
            {
                respuesta = "Lo siento, no entiendo tu pregunta. Por favor, intenta preguntar de otra forma o contacta con soporte.";
            }
            return Json(new { respuesta });
        }

        // Método para buscar respuestas en las FAQs
        private string BuscarRespuesta(string pregunta)
        {
            foreach (var faq in FAQs.PreguntasRespuestas)
            {
                if (pregunta.ToLower().Contains(faq.Key.ToLower()))
                {
                    return faq.Value;
                }
            }
            return null;
        }
    }
}
