using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();  
        }
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream()) { 
            
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10)) //resim olusturma burada yapilir
                {
                    image.Save(memoryStream,ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
