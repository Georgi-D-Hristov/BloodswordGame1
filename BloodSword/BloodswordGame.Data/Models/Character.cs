using BloodswordGame.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BloodswordGame.Data.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ClassType Class { get; set; }

        public int CurrentParagraphId { get; set; }
        public Paragraph CurrentParagraph { get; set; }

        public int Health { get; set; }
    }
}
