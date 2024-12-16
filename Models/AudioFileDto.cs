namespace QuranWebApp.Models
{
    public class AudioFileDto
    {
        public byte Id { get; set; }
        public int FileSize { get; set; }
        public string AudioUrl { get; set; }
        public ChapterDto Chapter { get; set; }
    }
}
