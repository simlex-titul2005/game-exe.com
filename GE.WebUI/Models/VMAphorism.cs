﻿namespace GE.WebUI.Models
{
    public sealed class VMAphorism
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Html { get; set; }
        public string TitleUrl { get; set; }
        public VMMaterialCategory Category { get; set; }
        public string CategoryId { get; set; }
        public VMAuthorAphorism Author { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Флаг, указывающий на принадлежность к автору - 1, категории - 2 или выбранному афоризму - 0
        /// </summary>
        public int Flag { get; set; }

        public enum AphorismFlag : byte
        {
            ForThis=0,
            ForAuthor=1,
            ForCategory=2
        }
    }
}