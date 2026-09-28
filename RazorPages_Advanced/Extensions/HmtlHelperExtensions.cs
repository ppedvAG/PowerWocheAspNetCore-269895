using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPages_Advanced.Extensions
{
    public static class HmtlHelperExtensions
    {
        public static IHtmlContent CustomButton(this IHtmlHelper htmlHelper, string text, string cssClass)
        {
            string button = $"<button class='{cssClass}'>{text}</button>";
            return new HtmlString(button);
        }

        public static IHtmlContent CustomDropDownList(this IHtmlHelper htmlHelper, string name, List<string> options)
        {
            var dropdown = $"<select name='{name}' class='form-control'>";
            foreach (var option in options)
            {
                dropdown += $"<option value='{option}'>{option}</option>";
            }
            dropdown += "</select>";
            return new HtmlString(dropdown);
        }

        public static IHtmlContent BootstrapNavbar(this IHtmlHelper htmlHelper, string brand, List<(string Text, string Url)> links)
        {
            var navbar = $@"
                <nav class='navbar navbar-expand-lg navbar-light bg-light'>
                    <a class='navbar-brand' href='#'>{brand}</a>
                    <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarNav' aria-controls='navbarNav' aria-expanded='false' aria-label='Toggle navigation'>
                        <span class='navbar-toggler-icon'></span>
                    </button>
                    <div class='collapse navbar-collapse' id='navbarNav'>
                        <ul class='navbar-nav'>";
            foreach (var link in links)
            {
                navbar += $"<li class='nav-item'><a class='nav-link' href='{link.Url}'>{link.Text}</a></li>";
            }
            navbar += @"
                        </ul>
                    </div>
                </nav>";
            return new HtmlString(navbar);
        }


        public static IHtmlContent BootstrapForm(this IHtmlHelper htmlHelper, string action, string method, List<(string Label, string Name, string Type)> fields)
        {
            var form = $@"
                <form action='{action}' method='{method}'>";
            foreach (var field in fields)
            {
                form += $@"
                    <div class='form-group'>
                        <label for='{field.Name}'>{field.Label}</label>
                        <input type='{field.Type}' class='form-control' id='{field.Name}' name='{field.Name}' />
                    </div>";
            }
            form += @"
                    <button type='submit' class='btn btn-primary'>Submit</button>
                </form>";
            return new HtmlString(form);
        }

        public static IHtmlContent BootstrapTable(this IHtmlHelper htmlHelper, List<string> headers, List<List<string>> rows)
        {
            var table = $@"
                <table class='table'>
                    <thead>
                        <tr>";
            foreach (var header in headers)
            {
                table += $"<th scope='col'>{header}</th>";
            }
            table += @"
                        </tr>
                    </thead>
                    <tbody>";
            foreach (var row in rows)
            {
                table += "<tr>";
                foreach (var cell in row)
                {
                    table += $"<td>{cell}</td>";
                }
                table += "</tr>";
            }
            table += @"
                    </tbody>
                </table>";
            return new HtmlString(table);
        }

        public static IHtmlContent MyHMTLContentWithIOC(this IHtmlHelper content, IServiceProvider serviceProvider)
        {
            // Beispiel: Verwende den IOC-Container, um das Logging zu erhalten (ANTI Pattern) 
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("MyHtmlContentExtension");

            // Hier wird eine Erweiterung implementiert, die z.B. den Inhalt des HtmlContent verändert und loggt
            var htmlString = content.ToString();
            logger.LogInformation($"Original HTML Content: {htmlString}");

            // Beispielmodifikation des HTML-Inhalts
            htmlString = $"<div class=\"my-custom-class\">{htmlString}</div>";

            return new HtmlString(htmlString);
        }
    }
}
