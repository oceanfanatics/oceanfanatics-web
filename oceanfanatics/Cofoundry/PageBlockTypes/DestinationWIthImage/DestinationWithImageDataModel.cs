using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.DestinationWIthImage
{
    public class DestinationWithImageDataModel : IPageBlockTypeDataModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }
        [Image]
        public int ImageId { get; set; }
        [Display(Name = "Link")]
        public string Link { get; set; }
        [Display(Name = "Is Event")]
        public bool IsEvent { get; set; }
        [Display(Name = "All Images")]
        [NestedDataModelCollection(IsOrderable = true, MinItems = 1, MaxItems = 6)]
        public ICollection<DestinationImagesDataModel> Images { get; set; }
    }

    public class DestinationImagesDataModel : INestedDataModel
    {
        [Required]
        [Image]
        public int ImageId { get; set; }

        [Display(Description = "Title to display in the slide.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Description = "Formatted text to display in the slide.")]
        public string Text { get; set; }

    }
}
