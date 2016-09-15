﻿using SX.WebCore.ViewModels;

namespace GE.WebUI.ViewModels
{
    public sealed class VMAphorism : SxVMMaterial
    {
        public VMAuthorAphorism Author { get; set; }

        /// <summary>
        /// Флаг, указывающий на принадлежность к автору - 1, категории - 2 или выбранному афоризму - 0
        /// </summary>
        public AphorismFlag Flag { get; set; }

        public enum AphorismFlag : byte
        {
            ForThis = 0,
            ForAuthor = 1,
            ForCategory = 2
        }
    }
}