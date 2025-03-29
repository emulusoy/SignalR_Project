
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage=new MimeMessage();
            MailboxAddress mailboxAdressFrom = new MailboxAddress("Ulusoy Restoraunt", "emucryptoo@gmail.com");
            mimeMessage.From.Add(mailboxAdressFrom);
            MailboxAddress mailboxAdressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo); 
            var bodybuilder=new BodyBuilder();
            bodybuilder.TextBody=createMailDto.Body;
            mimeMessage.Body=bodybuilder.ToMessageBody();
            mimeMessage.Subject=createMailDto.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("emucryptoo@gmail.com", "moxc ewym gpzp puvw");

            client.Send(mimeMessage);
            client.Disconnect(true);
            return RedirectToAction("Index","Category");
        }
    }
}
