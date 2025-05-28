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
    [ValidateAntiForgeryToken]
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
    [HttpGet]
    public IActionResult Profil()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Profil(IFormFile dosya)
    {
        // dosya tipi jpg veya png olanları kabul et
        if (dosya != null && (dosya.ContentType == "image/jpeg" || dosya.ContentType == "image/png"))
        {
            //dosya boyutu en fazla 5 MB olmalı
            if (dosya.Length > 5 * 1024 * 1024)
            {
                ViewBag.Message = "Dosya boyutu en fazla 5 MB olmalıdır.";
                return View();
            }
            //dosyayı kaydet
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", dosya.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                dosya.CopyTo(stream);
            }
            ViewBag.Message = "Dosya başarıyla yüklendi.";
        }
        else
        {
            ViewBag.Message = "Lütfen geçerli bir resim dosyası yükleyin (jpg veya png).";
        }
        return View();
    }
}
