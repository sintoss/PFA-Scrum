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
                    r.Version = s.Libelle.Replace(" ", string.Empty);
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

                    var dbpath = Path.Combine(foldername, NewName);

                    //delete file if exist
                    if ((System.IO.File.Exists(FullPath)))
                    {
                        System.IO.File.Delete(FullPath);
                    }

                    using (var stream = new FileStream(FullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    release.dbapkpath = dbpath;

                    context.SaveChanges();

                }
            }
            return Ok(release);
        }

        [HttpGet("download/{id}")]
        public IActionResult GetBlobDownload(string id)
        {
            Release release = null;
            int val = 0;
            int.TryParse(id, out val);
            if(val != 0 ) release = context.Releases.Find( val );
            if(release != null && release.dbapkpath != null)
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData("https://localhost:44349/"+release.dbapkpath);
                var content = new System.IO.MemoryStream(data);
                var contentType = "APPLICATION/octet-stream";
                var fileName = release.Version;
                return File(content, contentType , fileName);
            }
 
            return Ok("Not found");
        }

    }
}
