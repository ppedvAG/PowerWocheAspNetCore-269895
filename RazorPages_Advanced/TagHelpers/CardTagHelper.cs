using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorPages_Advanced.TagHelpers
{
    [HtmlTargetElement("card-area")]
    public class CardTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card");
        }
    }

    [HtmlTargetElement("card-header", ParentTag = "card-area")]
    public class CardHeaderTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card-header");
        }
    }

    [HtmlTargetElement("card-body", ParentTag = "card-area")]
    public class CardBodyTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card-body");
        }
    }
}
