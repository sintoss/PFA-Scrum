using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public testController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("testc")]
        public ActionResult Index()
        {

            var p = context.Projets.FirstOrDefault();


            return Ok("All good : "+p.Backlog.Id);
        }

    }
}
