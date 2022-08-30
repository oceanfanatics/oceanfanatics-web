using Cofoundry.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oceanfanatics.Cofoundry.PageBlockTypes.ImageAndText
{
    public class ImageAndTextDataModel : IPageBlockTypeDataModel
    {
        [Required]
        [Display(Description = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Description = "Description")]
        public string Description { get; set; }
        [Image]
        public int ImageId { get; set; }
        [Display(Description = "Link")]
        [NestedDataModelCollection(IsOrderable = true, MinItems = 1, MaxItems = 6)]
        public ICollection<LinkDataModel> Link { get; set; }
        [Required]
        [Display(Description = "Event")]
        public bool Event { get; set; }
    }

    public class LinkDataModel : INestedDataModel
    {

        [Display(Description = "Link.")]
        public string Link { get; set; }
        [Display(Description = "Link Name")]
        public string LinkName { get; set; }

    }
}
