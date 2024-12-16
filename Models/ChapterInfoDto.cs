namespace QuranWebApp.Models
{
    public class ChapterInfoDto
    {
        public byte Id { get; set; }
        public string LanguageName { get; set; }
        public string ShortText { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }
        public ChapterDto Chapter { get; set; }
    }
}
