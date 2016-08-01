using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using DvkService.Models;

namespace DvkService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Сообщение от: {0}</p><p>Обратный адрес: {1}</p><p>Номер телефона: {2}</p><p>Текст сообщения:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("sender@outlook.com");  // replace with valid value
                message.Subject = $"Обращение с сайта от {model.FromName}";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.PhoneNumber, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "user@outlook.com",  // replace with valid value
                        Password = "password"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent" , model.FromName);
                }
            }
            ViewBag.Message = "Your contact page.";
            return View(model);
        }

        public ActionResult Sent(string name)
        {
            ViewBag.Message = "Сообщение отправлено.";

            return View(name);
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your services page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your gallery page.";

            return View();
        }
    }
}