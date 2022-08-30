using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.News
{
    public class NewsDisplayModelMapper : ICustomEntityDisplayModelMapper<NewsDataModel, NewsDisplayModel>
    {
        private readonly IContentRepository _contentRepository;

        public NewsDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<NewsDisplayModel> MapDisplayModelAsync(CustomEntityRenderDetails renderDetails, NewsDataModel dataModel, PublishStatusQuery publishStatusQuery)
        {
            var photo = await _contentRepository
                .ImageAssets()
                .GetById(dataModel.PhotoId)
                .AsRenderDetails()
                .ExecuteAsync();

            var vm = new NewsDisplayModel()
            {
                MetaDescription = dataModel.Title,
                PageTitle = renderDetails.Title,
                Title = dataModel.Title,
                Details = dataModel.Details,
                ForwardLink = dataModel.ForwardLink,
                IsHighLight = dataModel.IsHighLight,
                Photo = photo
            };

            return vm;
        }
    }
}
