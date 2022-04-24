using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleaseController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ReleaseController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getList()
        {
            var listofendsprint = context.Sprints.Where(s =>  s.FinDeSprint && !context.Releases.Select(r => r.SprintId).Contains(s.Id)).ToList();
            if(listofendsprint != null) {
                listofendsprint.ForEach(s =>
                {
                    Release r = new Release();
                    r.Version = s.Libelle;
                    r.SprintId = s.Id;
                    r.DateRelease = DateTime.Now;
                    context.Releases.Add(r);
                });
            }

            await context.SaveChangesAsync();
            
            return Ok(context.Releases.ToList());
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult AddFile([FromQuery] string page)
        {
            var file = Request.Form.Files[0];
            var id = 0;
            int.TryParse(page, out id);
            Release release = null;
            if (id != 0) release = context.Releases.Find(id);
            if (file.Length > 0 && release != null)
            {
                 var foldername = Path.Combine("Ressources", "Release");
                 var pathtosave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                 string[] exts = { ".zip", ".rar", ".7zip" };
                 if (exts.Contains(Path.GetExtension(file.FileName)))
                 {
                    string NewName = Path.GetFileNameWithoutExtension(file.FileName);

                    NewName = release.Version;

                    NewName += Path.GetExtension(file.FileName);

                    var FullPath = Path.Combine(pathtosave, NewName);

                    //delete file if exist
                    if ((System.IO.File.Exists(FullPath)))
                    {
                        System.IO.File.Delete(FullPath);
                    }

                    using (var stream = new FileStream(FullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            return Ok(release);
        }

    }
}
