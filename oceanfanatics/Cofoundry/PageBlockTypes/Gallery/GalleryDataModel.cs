using Cofoundry.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oceanfanatics.Cofoundry.PageBlockTypes.Gallery
{
    public class GalleryDataModel : IPageBlockTypeDataModel
    {
        [NestedDataModelCollection(IsOrderable = true, MinItems = 1, MaxItems = 6)]
        public ICollection<GallerySliderDataModel> Photos { get; set; }

    }

    public class GallerySliderDataModel : INestedDataModel
    {
        [Display(Description = "Image to display")]
        [Required]
        [Image]
        public int ImageId { get; set; }
    }
}
