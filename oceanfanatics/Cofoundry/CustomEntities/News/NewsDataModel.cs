using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.News
{
    public class NewsDataModel : ICustomEntityDataModel
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Forward Link")]
        public string ForwardLink { get; set; }
        [Display(Name = "Highlight to home page")]
        public bool IsHighLight { get; set; }
        [Image]
        [Display(Description = "Photo of the news", Name = "Photo")]
        public int PhotoId { get; set; }
    }
}
