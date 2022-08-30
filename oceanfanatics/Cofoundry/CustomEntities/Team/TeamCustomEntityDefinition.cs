using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.Team
{
    public class TeamCustomEntityDefinition : ICustomEntityDefinition<TeamDataModel>, ISortedCustomEntityDefinition
    {
        public const string DefinitionCode = "OFTEAM";
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Team";

        public string NamePlural => "Teams";

        public string Description => "Team members";

        public bool ForceUrlSlugUniqueness => true;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;

        public CustomEntityQuerySortType DefaultSortType => CustomEntityQuerySortType.PublishDate;

        public SortDirection DefaultSortDirection => SortDirection.Default;
    }
}
