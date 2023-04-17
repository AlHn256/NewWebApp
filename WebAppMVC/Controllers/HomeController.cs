using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<string> GetJson()
        {
            // Получаем адрес Json
            string JsonAdress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Json")["Adress"];

            // Делаем запрос
            Request request = new Request(JsonAdress);
            string Json = await request.GetJson();
            if(request.Exception)
            {
                return request.ExceptionText;
            }
           
            // Парсим Json
            ParsJson parsJson = new ParsJson(Json.Split('\n'));
            var json = parsJson.GetStudentInfo();

            // Сохраняем Json в БД
            string DBConnection = ConnectionSting.DBConnection;
            DB dB = new DB(DBConnection);
            await dB.SaveJson(json);

            if (dB.Exception)
            {
                return dB.ExceptionText;
            }

            return "Json Saved";
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}