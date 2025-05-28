using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using validationApp.Models;

namespace validationApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
[HttpPost]
    public IActionResult Index(UserModel m)
    {
        if (ModelState.IsValid)
        {
            // Model geçerli ise, burada işlemler yapılabilir.
            // Örneğin, veritabanına kaydetme işlemi.
            ViewBag.Message = "Kullanıcı başarıyla kaydedildi.";
            return View();
        }
        else
        {
            // Model geçerli değilse, hata mesajlarını göster.
            ViewBag.Message = "Lütfen hataları düzeltin.";
        }
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
