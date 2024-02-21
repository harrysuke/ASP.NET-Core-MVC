using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Price { get; set; }
    }
}
