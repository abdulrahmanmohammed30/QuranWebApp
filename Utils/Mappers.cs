using QuranDataLayer.Entities;
using QuranWebApp.Models;

namespace QuranWebApp.Utils
{
    public static class Mappers
    {
        public static ChapterDto ToChapterDto(Chapter chapter) => new ChapterDto()
        {
            Id = chapter.Id,
            Name = chapter.Name,
            TotalVerses = chapter.TotalVerses,
            Transliteration = chapter.Transliteration,
            TypeId = chapter.TypeId,
            Verses = chapter.Verses?.Select(verse => ToVerseDto(verse)).ToList(),
            Type= chapter.Type != null ?  ToTypeDto(chapter.Type): null
        };

        public static VerseDto ToVerseDto(Verse verse) => new VerseDto()
        {
            Id = verse.Id,
            VerseId = verse.VerseId,
            Text = verse.Text,
            ChapterId = verse.ChapterId,
        };

        public static TypeDto ToTypeDto(QuranDataLayer.Entities.Type type) => new TypeDto()
        {
            Id = type.Id,
            Text = type.Text,
        };

        public static JuzDto ToJuzDto(Juz juz) => new JuzDto()
        {
            Id = juz.Id,
            FirstVerseId = juz.FirstVerseId,
            LastVerseId = juz.LastVerseId,
            VersesCount = juz.VersesCount,
            VerseMappings = juz.VerseMappings?.Select(ToVerseMappingDto).ToList()
        };

        public static VerseMappingDto ToVerseMappingDto(VerseMapping verseMapping) => new VerseMappingDto()
        {
            Id = verseMapping.Id,
            JuzId = verseMapping.JuzId,
            ChapterId = verseMapping.ChapterId,
            StartVerse = verseMapping.StartVerse,
            EndVerse = verseMapping.EndVerse,
            Chapter= verseMapping.Chapter == null?null: ToChapterDto(verseMapping.Chapter) 
        };
    }
}
