using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oceanfanatics.Cofoundry.PageBlockTypes.HeroWithText
{
    public class HeroWithTextDisplayModelMapper : IPageBlockTypeDisplayModelMapper<HeroWithTextDataModel>
    {
        private readonly IContentRepository _contentRepository;

        public HeroWithTextDisplayModelMapper(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task MapAsync(PageBlockTypeDisplayModelMapperContext<HeroWithTextDataModel> context, PageBlockTypeDisplayModelMapperResult<HeroWithTextDataModel> result)
        {
            
            foreach (var input in context.Items)
            {
                var image = await _contentRepository
                    .ImageAssets()
                    .GetById(input.DataModel.ImageId)
                    .AsRenderDetails()
                    .ExecuteAsync();
                var output = new HeroWithTextDisplayModel()
                {

                    Title = new HtmlString(input.DataModel.Title),
                    SubTitle = new HtmlString(input.DataModel.SubTitle),
                    Link = new HtmlString(input.DataModel.Link),
                    Image = image,
                    Hero = input.DataModel.Hero
                };
                result.Add(input, output);
            }
        }
    }
}
