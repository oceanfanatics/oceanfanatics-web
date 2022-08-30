using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.News
{
    public class NewsCustomEntityDefinition : ICustomEntityDefinition<NewsDataModel>, ISortedCustomEntityDefinition
    {
        public const string DefinitionCode = "NEWSHG";
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "News";

        public string NamePlural => "News";

        public string Description => "Events and highlights and news";

        public bool ForceUrlSlugUniqueness => true;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;

        public CustomEntityQuerySortType DefaultSortType => CustomEntityQuerySortType.PublishDate;

        public SortDirection DefaultSortDirection => SortDirection.Default;
    }
}
