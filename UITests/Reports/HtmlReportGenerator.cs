using System.IO;
using System.Text;

public class HtmlReportGenerator
{
    public static void GenerateReport(string videoDirectory, string outputFilePath)
    {
        // Crear el encabezado del HTML
        var htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<!DOCTYPE html>");
        htmlBuilder.AppendLine("<html lang='en'>");
        htmlBuilder.AppendLine("<head>");
        htmlBuilder.AppendLine("<meta charset='UTF-8'>");
        htmlBuilder.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
        htmlBuilder.AppendLine("<title>Reporte de Pruebas</title>");
        htmlBuilder.AppendLine("<style>");
        htmlBuilder.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; }");
        htmlBuilder.AppendLine("h1 { color: #333; }");
        htmlBuilder.AppendLine(".test { margin-bottom: 20px; }");
        htmlBuilder.AppendLine("video { width: 640px; height: 360px; display: block; margin-top: 10px; }");
        htmlBuilder.AppendLine("</style>");
        htmlBuilder.AppendLine("</head>");
        htmlBuilder.AppendLine("<body>");
        htmlBuilder.AppendLine("<h1>Reporte de Pruebas con Videos</h1>");

        // Agregar cada video al reporte
        var testDirectories = Directory.GetDirectories(videoDirectory);
        foreach (var testDir in testDirectories)
        {
            var testName = Path.GetFileName(testDir);
            htmlBuilder.AppendLine($"<div class='test'>");
            htmlBuilder.AppendLine($"<h2>Prueba: {testName}</h2>");

            var videoFiles = Directory.GetFiles(testDir, "*.webm");
            foreach (var videoFile in videoFiles)
            {
                var relativePath = Path.Combine("videos", testName, Path.GetFileName(videoFile));
                htmlBuilder.AppendLine($"<video controls>");
                htmlBuilder.AppendLine($"<source src='{relativePath}' type='video/webm'>");
                htmlBuilder.AppendLine("Tu navegador no soporta la reproducción de videos.");
                htmlBuilder.AppendLine("</video>");
            }

            htmlBuilder.AppendLine("</div>");
        }

        // Cerrar el HTML
        htmlBuilder.AppendLine("</body>");
        htmlBuilder.AppendLine("</html>");

        // Escribir el archivo HTML
        File.WriteAllText(outputFilePath, htmlBuilder.ToString());
    }
}
