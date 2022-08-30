using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.CustomEntities.Team
{
    public class TeamDisplayModelMapper : ICustomEntityDisplayModelMapper<TeamDataModel, TeamDisplayModel>
    {
        private readonly IContentRepository _contentRepository;

        public TeamDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<TeamDisplayModel> MapDisplayModelAsync(CustomEntityRenderDetails renderDetails, TeamDataModel dataModel, PublishStatusQuery publishStatusQuery)
        {
            var photo = await _contentRepository
                .ImageAssets()
                .GetById(dataModel.PhotoId)
                .AsRenderDetails()
                .ExecuteAsync();

            var vm = new TeamDisplayModel()
            {
                MetaDescription = dataModel.Name,
                PageTitle = renderDetails.Title,
                Photo = photo,
                JobTitle = dataModel.JobTitle,
                Location = dataModel.Location,
                Name = dataModel.Name
            };
            return vm;
        }
    }
}
