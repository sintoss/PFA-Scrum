using BackEnd.Models;
using System.Linq;

namespace BackEnd.ViewModel
{
    public class DevStoryMv
    {

        public int dayofwork { get; set; }

        public IQueryable<Story> ListStory { get; set; }

    }
}
