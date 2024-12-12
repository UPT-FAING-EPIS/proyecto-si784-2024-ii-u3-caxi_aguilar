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
            Headless = true // Ver la interacción en el navegador
        });
    }

    [TestInitialize]
    public async Task TestSetup()
    {
        _context = await _browser!.NewContextAsync();
        _page = await _context.NewPageAsync();
        _page.SetDefaultTimeout(60000);
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
    public async Task LoginPage_ShouldValidateEmptyFields()
    {
        await _page!.GotoAsync("http://localhost:3000/login");

        // Intentar enviar el formulario sin completar campos
        await _page.ClickAsync("button[type='submit']");

        // Verificar mensajes de error
        var emailError = await _page.TextContentAsync("#email-error");
        var passwordError = await _page.TextContentAsync("#password-error");

        Assert.AreEqual("El correo electrónico es obligatorio.", emailError, "El mensaje de error para el correo no coincide.");
        Assert.AreEqual("La contraseña es obligatoria.", passwordError, "El mensaje de error para la contraseña no coincide.");
    }

    [TestMethod]
    public async Task LoginPage_ShouldLoginSuccessfully()
    {
        await _page!.GotoAsync("http://localhost:3000/login");

        // Completar el formulario de inicio de sesión
        await _page.FillAsync("#username", "chino@gmail.com");
        await _page.FillAsync("#password", "soycabro");
        await _page.ClickAsync("button[type='submit']");

        // Verificar redirección al dashboard
        await _page.WaitForURLAsync("http://localhost:3000/dashboard");
        var dashboardTitle = await _page.TextContentAsync("h1");
        Assert.AreEqual("Panel de Control", dashboardTitle, "El título del dashboard no coincide.");
    }

    [TestMethod]
    public async Task Sidebar_ShouldNavigateToAttendance()
    {
        await _page!.GotoAsync("http://localhost:3000/dashboard");

        // Hacer clic en el enlace de Asistencias
        await _page.ClickAsync("button:has-text('Asistencias')");
        await _page.WaitForURLAsync("http://localhost:3000/attendance");

        // Verificar que la página de asistencias se haya cargado
        var attendanceTitle = await _page.TextContentAsync("h1");
        Assert.AreEqual("Asistencias", attendanceTitle, "El título de la página de asistencias no coincide.");
    }

    [TestMethod]
    public async Task Dashboard_ShouldDisplayWelcomeMessage()
    {
        await _page!.GotoAsync("http://localhost:3000/dashboard");

        // Verificar que el mensaje de bienvenida se muestre
        var welcomeMessage = await _page.TextContentAsync(".welcome-message");
        Assert.AreEqual("¡Bienvenido, testuser!", welcomeMessage, "El mensaje de bienvenida no coincide.");
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
