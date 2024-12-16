using System.ComponentModel.DataAnnotations;

namespace QuranWebApp.Models
{
    public class ChapterDto
    {
        [Required]
        [Range(1, 114)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Transliteration { get; set; }
        public byte TypeId { get; set; } 
        public virtual TypeDto Type { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int TotalVerses { get; set; }
        public virtual List<VerseDto> Verses { get; set; }
    }
}

