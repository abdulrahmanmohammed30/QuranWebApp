namespace QuranWebApp.Models
{
    public class JuzDto
    {
        public byte Id { get; set; }
        public List<VerseMappingDto> VerseMappings { get; set; }
        public short FirstVerseId { get; set; }
        public short LastVerseId { get; set; }
        public short VersesCount { get; set; }
    }
}

