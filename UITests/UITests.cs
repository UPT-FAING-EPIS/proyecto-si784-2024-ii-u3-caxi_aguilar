namespace UITests;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

[TestClass]
public class UITests
{
    private static IPlaywright? _playwright;
    private static IBrowser? _browser;
    private IBrowserContext? _context;
    private IPage? _page;

    [ClassInitialize]
    public static async Task Setup(TestContext context)
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
    }

    [TestInitialize]
    public async Task TestSetup()
    {
        
        _context = await _browser!.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = "videos/" 
        });
        Console.WriteLine("Contexto creado con grabación de video habilitada.");
        _page = await _context.NewPageAsync();
    }

    [TestMethod]
     public async Task HomePage_ShouldDisplayCorrectElements()
    {
        // Navegar a la página Home
        await _page!.GotoAsync("http://localhost:3000");

        // Verificar que el título esté presente
        var title = await _page.TextContentAsync("h1");
        Assert.AreEqual("Bienvenido al Sistema de Asistencia", title, "El título no coincide.");

        // Verificar que la fecha y la hora se muestren
        var dateTimeText = await _page.Locator(".date-time-text").TextContentAsync();
        Assert.IsNotNull(dateTimeText, "El texto de fecha y hora debería estar presente.");

        // Verificar que el botón de inicio de sesión esté presente
        var loginButton = _page.Locator("text=Iniciar Sesión");
        Assert.IsTrue(await loginButton.IsVisibleAsync(), "El botón 'Iniciar Sesión' debería estar visible.");

        // Hacer clic en el botón de inicio de sesión y verificar la navegación
        await loginButton.ClickAsync();
        await _page.WaitForURLAsync("http://localhost:3000/login");

        // Verificar que se redirigió correctamente a la página de inicio de sesión
        var loginPageTitle = await _page.TitleAsync();
        Assert.AreEqual("Sistema Asistencia", loginPageTitle, "El título de la página de inicio de sesión no coincide.");
    }

    [TestMethod]
    public async Task LoginPage_ShouldLoginSuccessfully()
    {
        await _page!.GotoAsync("http://localhost:3000/login");

        // Completar el formulario de inicio de sesión
        await _page.FillAsync("input[type='email']", "chino@gmail.com");
        await _page.FillAsync("input[type='password']", "soycabro");
        await _page.ClickAsync("button[type='submit']");
    }

    [TestMethod]
    public async Task Sidebar_ShouldContainAllMenuOptions()
    {
        await _page!.GotoAsync("http://localhost:3000/dashboard");

        // Verificar las opciones del menú lateral
        var menuOptions = await _page.Locator("aside nav button").AllTextContentsAsync();
        
    }

    [TestMethod]
    public async Task DebugMenuOptions()
    {
        await _page!.GotoAsync("http://localhost:3000/dashboard");

        var menuOptions = await _page.Locator("aside nav button").AllTextContentsAsync();
        Console.WriteLine("Opciones encontradas en el menú lateral:");
        foreach (var option in menuOptions)
        {
            Console.WriteLine(option);
        }
    }

    [TestMethod]
    public async Task LoginPage_ShouldValidateEmptyFields()
    {
        await _page!.GotoAsync("http://localhost:3000/login");

        // Hacer clic en el botón "Iniciar Sesión" sin completar los campos
        await _page.ClickAsync("button[type='submit']");

        // Verificar que aparezca el mensaje de validación para el correo electrónico
        var emailValidationMessage = await _page.Locator("input[type='email']").EvaluateAsync<string>("el => el.validationMessage");
        Assert.AreEqual("Completa este campo", emailValidationMessage, "El mensaje de validación para el correo electrónico no coincide.");

        // Verificar que aparezca el mensaje de validación para la contraseña
        var passwordValidationMessage = await _page.Locator("input[type='password']").EvaluateAsync<string>("el => el.validationMessage");
        Assert.AreEqual("Completa este campo", passwordValidationMessage, "El mensaje de validación para la contraseña no coincide.");
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        if (_page != null && _page.Video != null)
        {
            var videoPath = await _page.Video.PathAsync();
            Console.WriteLine($"Video guardado en: {videoPath}");
        }

        if (_context != null)
        {
            
            await _context.CloseAsync();
            _context = null; // Limpieza explícita
        }
    }

    [ClassCleanup]
    public static async Task Teardown()
    {
        // Verifica si existe la carpeta de videos
        var videoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "videos");
        var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "TestReport.html");

        if (Directory.Exists(videoDirectory))
        {
            Console.WriteLine("Generando reporte HTML de las pruebas...");

            // Llama al generador de reporte
            HtmlReportGenerator.GenerateReport(videoDirectory, outputFilePath);

            Console.WriteLine($"Reporte generado: {outputFilePath}");
        }
        else
        {
            Console.WriteLine("No se encontraron videos grabados. El reporte no será generado.");
        }

        // Cerrar el navegador Playwright
        if (_browser != null)
        {
            await _browser.CloseAsync();
        }

        // Liberar recursos de Playwright
        _playwright?.Dispose();
    }
}
