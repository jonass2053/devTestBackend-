
namespace BitmexApi.Services.Announcement
{
    public interface IAnnouncementService
    {

        Task <ServiceResponse<List<Models.Announcement>>> GetAll();
        Task<ServiceResponse<Models.Announcement>> GetById( int id);
        ServiceResponse<List<Models.Announcement>> Insert(Models.Announcement announcement);
        Task<ServiceResponse<List<Models.Announcement>>>Update(Models.Announcement announcement);   
        Task<ServiceResponse <List<Models.Announcement>>> Delete(int id);
        Task<ServiceResponse<List<Models.Announcement>>>AddAll(List<Models.Announcement> announcement);

    }
}
