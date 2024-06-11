
using ETicaretAPI.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConnectionController : ControllerBase
    {
        private readonly IMailService _mailservice;

        public TestConnectionController(IMailService mailservice) {
            _mailservice = mailservice;
        }

        [HttpGet]
        public async Task<bool> TestConnection()
        {
            await _mailservice.SendCompletedOrderMailAsync("ataberkcekic@yahoo.com", "5", DateTime.Now, "asd");
            return true;
        }

    }
}
