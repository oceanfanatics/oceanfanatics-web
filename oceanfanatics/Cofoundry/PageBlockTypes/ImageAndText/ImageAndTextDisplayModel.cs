using Cofoundry.Domain;
using System.Collections.Generic;

namespace oceanfanatics.Cofoundry.PageBlockTypes.ImageAndText
{
    public class ImageAndTextDisplayModel : IPageBlockTypeDisplayModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<LinkDisplayModel> Link { get; set; }
        public ImageAssetRenderDetails Image { get; set; }
        public bool Event { get; set; }
    }

    public class LinkDisplayModel
    {
        public string Link { get; set; }
        public string LinkName { get; set; }

    }
}
