using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.News
{
    public class NewsDisplayModel : ICustomEntityPageDisplayModel<NewsDataModel>
    {
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string ForwardLink { get; set; }
        public bool IsHighLight { get; set; }
        public ImageAssetRenderDetails Photo { get; set; }
    }
}
