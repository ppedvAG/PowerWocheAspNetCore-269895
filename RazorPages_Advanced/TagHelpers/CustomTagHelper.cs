using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorPages_Advanced.TagHelpers
{
    public class CustomTagHelper : TagHelper
    {
        //Arbeiten mit Parameter
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetContent($"Hello, {Name}!");
        }
    }
}
