using BitmexApi.Data;
using BitmexApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BitmexApi.Services.Announcement
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly Data.DataContext _context;
        public AnnouncementService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Models.Announcement>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<Models.Announcement>>();
            try
            {
                Models.Announcement item = await _context.Announcement.FirstAsync(c => c.Id == id);
                _context.Remove(item);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Announcement.ToListAsync();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }

            return serviceResponse;


        }

        public async Task<ServiceResponse<List<Models.Announcement>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<Models.Announcement>>();
            try
            {

                serviceResponse.Data = await _context.Announcement.ToListAsync();
                return serviceResponse;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Models.Announcement>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<Models.Announcement>();
            try
            {
                Models.Announcement item = await _context.Announcement.FirstOrDefaultAsync(c => c.Id == id);
                serviceResponse.Data = item;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }

            return serviceResponse;
        }

        public  ServiceResponse<List<Models.Announcement>> Insert(Models.Announcement announcement)
        {
            var serviceResponse = new ServiceResponse<List<Models.Announcement>>();
            try
            {
                _context.Announcement.Add(announcement);
                _context.SaveChanges();
                serviceResponse.Data = _context.Announcement.ToList();

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Models.Announcement>>> Update(Models.Announcement announcement)
        {
            var serviceResponse = new ServiceResponse<List<Models.Announcement>>();
            try
            {


                Models.Announcement announcementUpdate = await _context.Announcement.FirstAsync(c => c.Id == announcement.Id);
                announcementUpdate.Link = announcement.Link;
                announcementUpdate.Title = announcement.Title;
                announcementUpdate.Content = announcement.Content;
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Announcement.ToListAsync();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;


        }
        public  async Task<ServiceResponse<List<Models.Announcement>>> AddAll(List<Models.Announcement> announcement)
        {
            var response = new ServiceResponse<List<Models.Announcement>>();
            var existencia = _context.Announcement.FirstOrDefault(c => c.Id == announcement[0].Id);
                if(existencia == null)
                {
                    foreach (var item in announcement)
                    {
                        Insert(item);
                    }
                }
            response = await GetAll();
            return response;
            

        }



        public async void CarryDataApi(string url)
        {
            HttpClient cliente = new HttpClient();
            var response = cliente.GetAsync(url);


        }

       
    }
}
