using BackEnd.ViewModel;

namespace BackEnd.Services
{
    public interface IDevStory
    {
        public DevStoryMv getData(int bckid , string devId);
    }
}
