using System.ComponentModel.DataAnnotations;

namespace QuranWebApp.Models
{
    public class ChapterDto
    {
        [Required]
        [Range(1, byte.MaxValue)]
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Transliteration { get; set; }
        public byte TypeId { get; set; } 
        public virtual TypeDto TypeDto { get; set; }
        public int TotalVerses { get; set; }
        public virtual List<VerseDto> Verses { get; set; }
    }
}
