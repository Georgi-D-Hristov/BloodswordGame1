using System.ComponentModel.DataAnnotations;

namespace BloodswordGame.Data.Models
{
    public class Choice
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        // From whetre come
        public int FromParagraphId { get; set; }
        public Paragraph FromParagraph { get; set; }

        // Where goes
        public int ToParagraphNumber { get; set; } 

        public string? Description { get; set; }
    }
}
