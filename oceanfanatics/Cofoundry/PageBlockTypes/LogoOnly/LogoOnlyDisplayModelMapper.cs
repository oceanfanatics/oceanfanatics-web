using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.LogoOnly
{
    public class LogoOnlyDisplayModelMapper : IPageBlockTypeDisplayModelMapper<LogoOnlyDataModel>
    {
        private readonly IContentRepository _contentRepository;

        public LogoOnlyDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<LogoOnlyDataModel> context, PageBlockTypeDisplayModelMapperResult<LogoOnlyDataModel> result)
        {

            foreach (var input in context.Items)
            {
                var image = await _contentRepository
                .ImageAssets()
                .GetById(input.DataModel.ImageId)
                .AsRenderDetails()
                .ExecuteAsync();
                var output = new LogoOnlyDisplayModel()
                {
                    ImageId = image,
                };
                result.Add(input, output);
            }
        }
    }
}
