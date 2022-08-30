using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.HeroWithText
{
    public class HeroWithTextDataModel : IPageBlockTypeDataModel
    {
        [Required]
        [Display(Description = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Description = "Sub Title")]
        public string SubTitle { get; set; }
        [Image]
        public int ImageId { get; set; }
        [Display(Description = "Link")]
        public string Link { get; set; }
        [Required]
        [Display(Description = "Hero")]
        public bool Hero { get; set; }
    }
}
