import { renderGraficasPublicaciones } from "./graficasChartJS.js"

renderGraficasPublicaciones();

const captureCanvasAndAddToPDF = async (pdf, canvasId, xPosition, yPosition, imgWidth) => {
    const canvas = await html2canvas(document.getElementById(canvasId), {
        scale: 2 // Aumenta la resolución del canvas, puedes ajustar este valor según sea necesario
    });

    const imgData = canvas.toDataURL('image/png');

    // Obtener las dimensiones del canvas
    const canvasWidth = canvas.width;
    const canvasHeight = canvas.height;

    // Calcular la altura proporcional
    const imgHeight = (canvasHeight * imgWidth) / canvasWidth;

    // Agregar la imagen al PDF
    pdf.addImage(imgData, 'PNG', xPosition, yPosition, imgWidth, imgHeight);
};

document.getElementById('descargar-pdf').addEventListener('click', async () => {
    const { jsPDF } = window.jspdf;
    const pdf = new jsPDF('portrait', 'mm', 'a4'); // Configura el PDF en formato vertical A4

    const pageWidth = pdf.internal.pageSize.getWidth(); // Ancho total de la página (210 mm para A4)
    const marginLeft = 20; // Margen izquierdo de 20 mm
    const marginRight = 20; // Margen derecho de 20 mm
    const maxWidth = pageWidth - marginLeft - marginRight; // Ancho disponible para el contenido

    // Añade texto al PDF
    pdf.setFontSize(10);
    pdf.text('Reporte generado por:', marginLeft, 20, { maxWidth });
    pdf.setFontSize(8);
    pdf.text('Nombre Administrador.', marginLeft, 23, { maxWidth });
    pdf.setFontSize(10);
    pdf.text('Fecha:', marginLeft, 28, { maxWidth });
    pdf.setFontSize(8);
    pdf.text('09/18/2024', marginLeft, 31, { maxWidth });

    pdf.setLineWidth(0.5); // Grosor de la línea
    pdf.line(marginLeft, 36, pageWidth - marginRight, 36); // Línea desde margen izquierdo a margen derecho

    pdf.setFontSize(24);
    pdf.text('Reporte de Publicaciones', marginLeft, 46, { maxWidth });
    pdf.setFontSize(16);

    pdf.text('Cantidad de Publicaciones', marginLeft, 56, { maxWidth });
    pdf.setFontSize(11);
    pdf.text('Este reporte presenta una comparación de la cantidad de publicaciones entre los años 2024 y 2023.', marginLeft, 61, { maxWidth });
    await captureCanvasAndAddToPDF(pdf, 'grafica-por-mes', marginLeft, 70, 170);

    pdf.addPage();

    pdf.setFontSize(16);
    pdf.text('Categorías más Usadas', marginLeft, 20, { maxWidth });
    pdf.setFontSize(11);
    pdf.text('Las 5 categorías más utilizadas en las publicaciones.', marginLeft, 25, { maxWidth });
    await captureCanvasAndAddToPDF(pdf, 'grafica-categorias', marginLeft, 30, 170);

    pdf.addPage();

    pdf.setFontSize(16);
    pdf.text('Promedio de Precios', marginLeft, 20, { maxWidth });
    pdf.setFontSize(11);
    pdf.text('Promedio de publicaciones de precios en moneda COP por mes.', marginLeft, 25, { maxWidth });
    await captureCanvasAndAddToPDF(pdf, 'grafica-precios', marginLeft, 30, 170);

    pdf.addPage();

    pdf.setFontSize(16);
    pdf.text('Publicaciones Mejor Valoradas.', marginLeft, 20, { maxWidth });
    pdf.setFontSize(11);
    pdf.text('Las 5 publicaciones mejor valoradas.', marginLeft, 25, { maxWidth });
    await captureCanvasAndAddToPDF(pdf, 'grafica-top', marginLeft, 30, 170);

    pdf.addPage();

    pdf.setFontSize(16);
    pdf.text('Publicaciones Activas vs Inactivas.', marginLeft, 20, { maxWidth });
    pdf.setFontSize(11);
    pdf.text('Cantidad de publicaciones activas en comparación con las inactivas actualmente.', marginLeft, 25, { maxWidth });
    await captureCanvasAndAddToPDF(pdf, 'grafica-activo', marginLeft, 30, 170);

    pdf.save('reporte-publicaciones.pdf');
});
















