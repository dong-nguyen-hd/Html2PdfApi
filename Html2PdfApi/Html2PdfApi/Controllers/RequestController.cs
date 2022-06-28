using Html2PdfApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Html2PdfApi.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class RequestController : ControllerBase
    {
        [HttpPost]
        public FileStreamResult Converter([FromBody] ConvertRequest convertRequest)
        {
            // Debug html content
            string templateHTML = @"<html> <head> <style> .center_div { border: 1px solid gray; margin-left: auto; margin-right: auto; width: 90%; background-color: #d0f0f6; text-align: left; padding: 8px; } </style> <link href='style.css' rel='stylesheet'> </head> <body> <div class='center_div'> <h1>Hello Dong!</h1> <img src='Java_logo.png'> <div class='myclass'> <p>Dong Nguyen.</p> </div> </div> </body></html>";
            string contentHTML = string.Empty;
            for (int i = 0; i < 50; i++)
            {
                contentHTML += templateHTML;
            }

            convertRequest.Content = contentHTML;

            PdfHtmlHeaderAndFooter pdf = new PdfHtmlHeaderAndFooter(convertRequest);
            return new FileStreamResult(pdf.ManipulatePdf(), "application/pdf");
        }
    }
}
