using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.Carousel
{
    public class CarouselDisplayModel : IPageBlockTypeDisplayModel
    {
        public ICollection<CarouselSliderDisplayModel> Slides { get; set; }
    }

    public class CarouselSliderDisplayModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        //public string SubText { get; set; }
        public ImageAssetRenderDetails Image { get; set; }
        public int Id { get; set; }
        public string Link { get; set; }
    }
}
