using Cofoundry.Core;
using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using oceanfanatics.Cofoundry.CustomEntities.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.ViewComponents
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly IContentRepository _contentRepository;
        private readonly IVisualEditorStateService _visualEditorStateService;

        public TeamViewComponent(IContentRepository contentRepository, IVisualEditorStateService visualEditorStateService)
        {
            _contentRepository = contentRepository;
            _visualEditorStateService = visualEditorStateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string destination)
        {

            // We can use the current visual editor state (e.g. edit mode, live mode) to
            // determine whether to show unpublished blog posts in the list.
            var visualEditorState = await _visualEditorStateService.GetCurrentAsync();
            var ambientEntityPublishStatusQuery = visualEditorState.GetAmbientEntityPublishStatusQuery();

            var query = new SearchCustomEntityRenderSummariesQuery()
            {
                CustomEntityDefinitionCode = TeamCustomEntityDefinition.DefinitionCode,
                PageNumber = 1,
                PageSize = 30,
                PublishStatus = ambientEntityPublishStatusQuery
            };


            var entities = await _contentRepository
                .CustomEntities()
                .Search()
                .AsRenderSummaries(query)
                .ExecuteAsync();

            var viewModel = await MapTeamsAsync(destination, entities, ambientEntityPublishStatusQuery);

            return View(viewModel);
        }

        private async Task<PagedQueryResult<TeamDisplayModel>> MapTeamsAsync(string destination, PagedQueryResult<CustomEntityRenderSummary> customEntityResult,
        PublishStatusQuery ambientEntityPublishStatusQuery)
        {
            var team = new List<TeamDisplayModel>(customEntityResult.Items.Count());
            var imageAssetIds = customEntityResult
                .Items
                .Select(i => (TeamDataModel)i.Model)
                .Select(m => m.PhotoId)
                .Distinct();

            var imageLookup = await _contentRepository
                .ImageAssets()
                .GetByIdRange(imageAssetIds)
                .AsRenderDetails()
                .ExecuteAsync();

            foreach (var customEntity in customEntityResult.Items)
            {

                var model = (TeamDataModel)customEntity.Model;

                

                if(destination == "home")
                {
                    var member = new TeamDisplayModel()
                    {
                        JobTitle = model.JobTitle,
                        Location = model.Location,
                        MetaDescription = model.Name,
                        Name = model.Name,
                        PageTitle = model.Name,
                        Photo = imageLookup.GetOrDefault(model.PhotoId),
                    };

                    team.Add(member);
                }
                else
                {
                    if (model.Location.Replace(" ", "").ToLower().Equals(destination))
                    {
                        var member = new TeamDisplayModel()
                        {
                            JobTitle = model.JobTitle,
                            Location = model.Location,
                            MetaDescription = model.Name,
                            Name = model.Name,
                            PageTitle = model.Name,
                            Photo = imageLookup.GetOrDefault(model.PhotoId),
                        };

                        team.Add(member);
                    }
                }
                    
            }

            return customEntityResult.ChangeType(team);

        }
    }
}
