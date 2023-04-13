using System.ComponentModel.DataAnnotations;

namespace BitmexApi.Models
{
    public class Announcement
    {
        
        [Key]
        public int Cod { get; set; }
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Date { get; set; }
    }
}
