using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.TextWithIcon
{
    public class TextWithIconDataModel : IPageBlockTypeDataModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Image]
        public int ImageId { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }
    }
}
