using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace QRCodeSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeGeneratorController : ControllerBase
    {
        [HttpGet]
        public dynamic Get()
        {
            return new { success = true, message = "API Online" };
        }

        [HttpPost]
        public string Generate([FromBody] Parametro data)
        {
            var qrCodeData = new QRCodeGenerator().CreateQrCode(data.Dado, QRCodeGenerator.ECCLevel.M);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return Convert.ToBase64String(ImageToByte(qrCodeImage));
        }

        private static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
    public class Parametro
    {
        public string Dado { get; set; }
    }
}



