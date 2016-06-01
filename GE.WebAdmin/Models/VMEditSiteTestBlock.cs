﻿using System.ComponentModel.DataAnnotations;

namespace GE.WebAdmin.Models
{
    public sealed class VMEditSiteTestBlock
    {
        public int Id { get; set; }

        [Required, Display(Name = "Тест")]
        public int TestId { get; set; }

        [Required, MaxLength(100), Display(Name ="Заголовок")]
        public string Title { get; set; }

        [Required, MaxLength(400), Display(Name = "Описание"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}