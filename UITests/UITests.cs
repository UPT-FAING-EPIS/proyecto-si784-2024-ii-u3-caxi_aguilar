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
            Headless = true // Cambia a false si deseas ver la interacción en el navegador
        });
    }

    [TestInitialize]
    public async Task TestSetup()
    {
        _context = await _browser!.NewContextAsync();
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
        Assert.AreEqual("Login - Sistema de Asistencia", loginPageTitle, "El título de la página de inicio de sesión no coincide.");
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        if (_context != null)
        {
            await _context.CloseAsync();
            _context = null; // Limpieza explícita
        }
    }

    [ClassCleanup]
    public static async Task Teardown()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
            _browser = null; // Limpieza explícita
        }

        _playwright?.Dispose();
    }
}

