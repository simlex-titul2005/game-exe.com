﻿using SX.WebCore.ViewModels;
using System;

namespace GE.WebUI.Models
{
    public sealed class VMLGNBGame
    {
        public VMLGNBGame()
        {
            News = new VMLGBNews[0];
            Tags = new SxVMMaterialTag[0];
        }

        public int Id { get; set; }
        public string TitleUrl { get; set; }
        public string Title { get; set; }
        public VMLGBNews[] News { get; set; }
        public SxVMMaterialTag[] Tags { get; set; }
        public Guid? FrontPictureId { get; set; }
    }
}