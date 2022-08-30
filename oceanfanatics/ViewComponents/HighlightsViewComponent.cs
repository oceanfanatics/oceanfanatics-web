using Cofoundry.Core;
using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using oceanfanatics.Cofoundry.CustomEntities.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.ViewComponents
{
    public class HighlightsViewComponent : ViewComponent
    {
        private readonly IContentRepository _contentRepository;
        private readonly IVisualEditorStateService _visualEditorStateService;

        public HighlightsViewComponent(IContentRepository contentRepository, IVisualEditorStateService visualEditorStateService)
        {
            _contentRepository = contentRepository;
            _visualEditorStateService = visualEditorStateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            // We can use the current visual editor state (e.g. edit mode, live mode) to
            // determine whether to show unpublished blog posts in the list.
            var visualEditorState = await _visualEditorStateService.GetCurrentAsync();
            var ambientEntityPublishStatusQuery = visualEditorState.GetAmbientEntityPublishStatusQuery();

            var query = new SearchCustomEntityRenderSummariesQuery()
            {
                CustomEntityDefinitionCode = NewsCustomEntityDefinition.DefinitionCode,
                PageNumber = 1,
                PageSize = 30,
                PublishStatus = ambientEntityPublishStatusQuery
            };


            var entities = await _contentRepository
                .CustomEntities()
                .Search()
                .AsRenderSummaries(query)
                .ExecuteAsync();

            var viewModel = await MapHighlightsAsync(entities, ambientEntityPublishStatusQuery);

            return View(viewModel);
        }

        private async Task<PagedQueryResult<NewsDisplayModel>> MapHighlightsAsync(PagedQueryResult<CustomEntityRenderSummary> customEntityResult,
        PublishStatusQuery ambientEntityPublishStatusQuery)
        {
            var news = new List<NewsDisplayModel>(customEntityResult.Items.Count());
            var imageAssetIds = customEntityResult
                .Items
                .Select(i => (NewsDataModel)i.Model)
                .Select(m => m.PhotoId)
                .Distinct();

            var imageLookup = await _contentRepository
                .ImageAssets()
                .GetByIdRange(imageAssetIds)
                .AsRenderDetails()
                .ExecuteAsync();

            foreach (var customEntity in customEntityResult.Items)
            {

                var model = (NewsDataModel)customEntity.Model;

                if (model.IsHighLight)
                {
                    var mentor = new NewsDisplayModel()
                    {
                        Details = model.Details,
                        IsHighLight = model.IsHighLight,
                        ForwardLink = model.ForwardLink,
                        MetaDescription = model.ForwardLink,
                        PageTitle  = model.ForwardLink,
                        Photo = imageLookup.GetOrDefault(model.PhotoId),
                        Title = model.Title
                    };

                    news.Add(mentor);
                }

            }

            return customEntityResult.ChangeType(news);

        }
    }
}
