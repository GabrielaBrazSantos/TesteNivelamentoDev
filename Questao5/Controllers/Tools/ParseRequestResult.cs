using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Responses;
using System.Net;

namespace Questao5.Controllers.Tools
{
    public class ParseRequestResult:Controller
    {
        public ActionResult ParseToActionResult(RequestResult request)
        {
            switch (request.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(request);
                case (int)HttpStatusCode.NotFound:
                    return NotFound(request);
                case (int)HttpStatusCode.BadRequest:
                    return BadRequest(request);
                default:
                    return BadRequest(request);
            }
        }
    }
}
