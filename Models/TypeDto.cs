namespace QuranWebApp.Models
{
    public class TypeDto
    {
        public byte Id { get; set; }
        public string Text { get; set; }
        public virtual List<ChapterDto> Chapters { get; set; }
    }
}

