﻿namespace GE.WebUI.Models
{
    public sealed class VMSiteTestQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public int BlockId { get; set; }
        public VMSiteTestBlock Block { get; set; }
    }
}