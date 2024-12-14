namespace QuranWebApp.Models
{
    public class VerseMappingDto
    {
        public byte Id { get; set; }
        public byte JuzId { get; set; }
        public byte ChapterId { get; set; }
        public short StartVerse { get; set; }
        public short EndVerse { get; set; }
        public ChapterDto Chapter { get; set; }
    }
}
