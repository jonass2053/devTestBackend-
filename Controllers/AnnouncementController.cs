using BitmexApi.Models;
using BitmexApi.Services;
using BitmexApi.Services.Announcement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BitmexApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService; 
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;

        }

        [HttpGet]
        public async Task<ActionResult<List<Announcement>>> Get()
        {
            return Ok(await _announcementService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> GetById(int id)
        {
            return Ok(await _announcementService.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<Announcement>>> AddNew(Announcement Announcement)
        {
            return Ok(_announcementService.Insert(Announcement));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Announcement>>> Delete(int id)
        {
            return Ok(await _announcementService.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<Announcement>> Update(Announcement Announcement)
        {
            return Ok(await _announcementService.Update(Announcement));
        }


        [HttpGet]
        [Route("CargaDataApi")]
        public async Task<ActionResult<Announcement>> CargaDataApi()
        {
            
            string url = "https://www.bitmex.com/api/v1/announcement";
            List<Models.Announcement> DataList = await AddApiDataService.GetDataApi(url);
            var response = await _announcementService.AddAll(DataList);
            return Ok(response);


        }

    }
}
