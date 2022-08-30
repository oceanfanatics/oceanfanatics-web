using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.Team
{
    public class TeamDisplayModel : ICustomEntityPageDisplayModel<TeamDataModel>
    {
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string JobTitle { get; set; }
        public ImageAssetRenderDetails Photo { get; set; }
    }
}
