using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.Carousel
{
    public class CarouselDataModel : IPageBlockTypeDataModel
    {
        [NestedDataModelCollection(IsOrderable = true, MinItems = 1, MaxItems = 6)]
        public ICollection<CarouselSliderDataModel> Slides { get; set; }

    }

    public class CarouselSliderDataModel : INestedDataModel
    {
        [Display(Description = "Image to display as the background to the slide.")]
        [Required]
        [Image]
        public int ImageId { get; set; }

        [Display(Description = "Title to display in the slide.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Description = "Formatted text to display in the slide.")]
        public string Text { get; set; }

        //[Display(Description = "Formatted subtext to display in the slide.")]
        //public string SubText { get; set; }
        [Display(Description = "Formatted link for the slide.")]
        public string Link { get; set; }
    }
}
