﻿using QuranWebApp.CustomAttributes;

namespace QuranWebApp.Models
{
    public class VerseDto
    {
        [ValidVerseId] // 6348 
        public short Id { get; set; }
        public short VerseId { get; set; }
        public string Text { get; set; }
        public byte ChapterId { get; set; }
        public virtual ChapterDto Chapter { get; set; }
    }
}
