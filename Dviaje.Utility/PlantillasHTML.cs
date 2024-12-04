namespace Dviaje.Utility
{
    public static class PlantillasHTML
    {
        public static string PlantillaRegistro(string url)
        {
            string htmlContent = $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    margin: 0;
                    padding: 20px;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    border-radius: 8px;
                    background-color: #ffffff;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }}
                h2 {{
                    color: #fff;
                    text-align: center;
                    margin: 0;
                    font-size: 40px;
                }}
                p {{
                    color: #f3f4f6;
                    line-height: 1.5;
                    margin: 20px 0;
                    padding: 0 20px;
                    text-align: center;
                }}
                a {{
                    text-decoration: none;
                    color: inherit;
                }}
                .button {{
                    display: inline-block;
                    color: #f97316;
                    background-color: #fff;
                    padding: 12px 24px;
                    text-decoration: none;
                    border-radius: 50px;
                    font-weight: bold;
                    font-size: 16px;
                    text-align: center;
                    margin: 20px auto;
                    display: block;
                    width: 200px;
                }}
                .button:hover {{
                    background-color: #f97316;
                    color: #fff;
                    outline: 1px solid #fff;
                }}
                .footer {{
                    color: #9ca3af;
                    font-size: 12px;
                    text-align: center;
                    padding: 20px;
                    background-color: #1c1917;
                }}
                .banner {{
                    width: 100%;
                    height: auto;
                    display: block;
                }}
                .logo {{
                    background-color: #1c1917;
                    padding: 10px 0;
                    text-align: center;
                }}
                .logo img {{
                    width: 200px;
                }}
                .container-body {{
                    background-color: #f97316;
                    padding: 20px;
                    text-align: center;
                }}
            </style>
        </head>
        <body>
            <table class='container' width='100%' cellpadding='0' cellspacing='0' border='0'>
                <tr>
                    <td class='logo' align='center'>
                        <img src='https://res.cloudinary.com/dfpdbr5mk/image/upload/v1733306782/assets/scno7qeayyl4fui13gfg.webp' alt='Logo'>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src='https://images.unsplash.com/photo-1656371559747-1ca93a271206?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D' alt='Banner' class='banner'>
                    </td>
                </tr>
                <tr>
                    <td class='container-body'>
                        <h2>¡Hola!</h2>
                        <p>Gracias por elegir nuestros servicios. Haz clic en el botón de abajo para confirmar tu correo electrónico.</p>
                        <a href='{url}' class='button'>Ir a la acción</a>
                    </td>
                </tr>
                <tr>
                    <td class='footer'>
                        &copy; 2024 Dviaje. Todos los derechos reservados.
                    </td>
                </tr>
            </table>
        </body>
        </html>";

            return htmlContent;
        }

        public static string PlantillaCambioCorreo(string url)
        {
            string htmlContent = $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    margin: 0;
                    padding: 20px;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    border-radius: 8px;
                    background-color: #ffffff;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }}
                h2 {{
                    color: #fff;
                    text-align: center;
                    margin: 0;
                    font-size: 40px;
                }}
                p {{
                    color: #f3f4f6;
                    line-height: 1.5;
                    margin: 20px 0;
                    padding: 0 20px;
                    text-align: center;
                }}
                a {{
                    text-decoration: none;
                    color: inherit;
                }}
                .button {{
                    display: inline-block;
                    color: #f97316;
                    background-color: #fff;
                    padding: 12px 24px;
                    text-decoration: none;
                    border-radius: 50px;
                    font-weight: bold;
                    font-size: 16px;
                    text-align: center;
                    margin: 20px auto;
                    display: block;
                    width: 200px;
                }}
                .button:hover {{
                    background-color: #f97316;
                    color: #fff;
                    outline: 1px solid #fff;
                }}
                .footer {{
                    color: #9ca3af;
                    font-size: 12px;
                    text-align: center;
                    padding: 20px;
                    background-color: #1c1917;
                }}
                .banner {{
                    width: 100%;
                    height: auto;
                    display: block;
                }}
                .logo {{
                    background-color: #1c1917;
                    padding: 10px 0;
                    text-align: center;
                }}
                .logo img {{
                    width: 200px;
                }}
                .container-body {{
                    background-color: #f97316;
                    padding: 20px;
                    text-align: center;
                }}
            </style>
        </head>
        <body>
            <table class='container' width='100%' cellpadding='0' cellspacing='0' border='0'>
                <tr>
                    <td class='logo' align='center'>
                        <img src='https://res.cloudinary.com/dfpdbr5mk/image/upload/v1733306782/assets/scno7qeayyl4fui13gfg.webp' alt='Logo'>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src='https://images.unsplash.com/photo-1656371559747-1ca93a271206?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D' alt='Banner' class='banner'>
                    </td>
                </tr>
                <tr>
                    <td class='container-body'>
                        <h2>¡Hola!</h2>
                        <p>Gracias por elegir nuestros servicios. Haz clic en el botón de abajo para actualizar el correo electrónico.</p>
                        <a href='{url}' class='button'>Ir a la acción</a>
                    </td>
                </tr>
                <tr>
                    <td class='footer'>
                        &copy; 2024 Dviaje. Todos los derechos reservados.
                    </td>
                </tr>
            </table>
        </body>
        </html>";

            return htmlContent;
        }
    }
}
