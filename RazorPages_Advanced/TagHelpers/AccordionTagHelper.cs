namespace RazorPages_Advanced.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement("accordion")]
    public class AccordionTagHelper : TagHelper
    {
        public string Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "accordion");
            output.Attributes.SetAttribute("id", Id);

            var childContent = await output.GetChildContentAsync();
            output.Content.SetHtmlContent(childContent.GetContent());
        }
    }

    [HtmlTargetElement("accordion-item", ParentTag = "accordion")]
    public class AccordionItemTagHelper : TagHelper
    {
        public string Header { get; set; }
        public string ParentId { get; set; }
        public string ItemId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "accordion-item");

            var childContent = await output.GetChildContentAsync();
            var content = $@"
                <h2 class='accordion-header' id='heading{ItemId}'>
                    <button class='accordion-button' type='button' data-bs-toggle='collapse' data-bs-target='#collapse{ItemId}' aria-expanded='true' aria-controls='collapse{ItemId}'>
                        {Header}
                    </button>
                </h2>
                <div id='collapse{ItemId}' class='accordion-collapse collapse' aria-labelledby='heading{ItemId}' data-bs-parent='#{ParentId}'>
                    <div class='accordion-body'>
                        {childContent.GetContent()}
                    </div>
                </div>
            ";

            output.Content.SetHtmlContent(content);
        }
    }
}
