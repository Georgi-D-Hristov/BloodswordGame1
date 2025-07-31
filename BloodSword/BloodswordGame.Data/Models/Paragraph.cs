using System.ComponentModel.DataAnnotations;

namespace BloodswordGame.Data.Models
{
    public class Paragraph
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
    }
}
