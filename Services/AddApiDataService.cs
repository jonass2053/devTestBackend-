using Newtonsoft;
using Newtonsoft.Json;

namespace BitmexApi.Services
{
    public class AddApiDataService
    {
       static HttpClient client = new HttpClient();
        public  static async Task<List<Models.Announcement>> GetDataApi(string url)
        {
           List<Models.Announcement> DataList = new List<Models.Announcement>();
          HttpResponseMessage response = await client.GetAsync(url);  
            if(response.IsSuccessStatusCode)
            {
                var a = await response.Content.ReadAsStringAsync();
                string b = a.ToString();
                DataList = JsonConvert.DeserializeObject<List<Models.Announcement>>(b);
            }
          

            return DataList;

        }


    }
}
