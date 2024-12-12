﻿using QuranDataLayer.Entities;
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
            Verses = chapter.Verses.Select(verse => ToVerseDto(verse)).ToList(),
            TypeDto=ToTypeDto(chapter.Type)
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
    }
}