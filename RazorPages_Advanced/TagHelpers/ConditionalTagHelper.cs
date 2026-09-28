using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorPages_Advanced.TagHelpers
{
    public class ConditionalTagHelper : TagHelper
    {
        public bool IsVisible { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!IsVisible)
            {
                output.SuppressOutput();
            }
        }
    }
}
