using Cofoundry.Domain;
using System.Collections.Generic;

namespace oceanfanatics.Cofoundry.PageBlockTypes.Gallery
{
    public class GalleryDisplayModel : IPageBlockTypeDisplayModel
    {
        public ICollection<GallerySliderDisplayModel> Photos { get; set; }
    }

    public class GallerySliderDisplayModel
    {
        public ImageAssetRenderDetails Image { get; set; }

    }
}
