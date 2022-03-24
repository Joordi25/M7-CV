using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using System.Net.Mail;

namespace MVC.Controllers
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

        
        public IActionResult MisProyectos()
        {
            return View();
        }

        public IActionResult MiCurriculum()
        {
            return View();
        }

        public IActionResult MisConocimientos()
        {
            return View();
        }

        public IActionResult MisEstudios()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult metodoEmail(ClassEmail classEmail)
        {
            email(classEmail);
            return View("Contacto");
        }

        private void email(ClassEmail classEmail)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("ggerardab@gmail.com");
            mail.From = new MailAddress(classEmail.email);
            mail.Subject = classEmail.asunto;
            mail.Body = classEmail.mensaje;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("ggerardab@gmail.com", "2Barcelona$$");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}