using Microsoft.AspNetCore.Mvc;

namespace MVCLibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //Anasayfa View action'ı
        {
            return View();
        }

        public IActionResult About() //Hakkında View action'ı
        {
            return View();
        }
    }
}
