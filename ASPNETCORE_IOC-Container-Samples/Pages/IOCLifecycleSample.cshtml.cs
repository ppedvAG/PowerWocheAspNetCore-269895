using ASPNETCORE_IOC_Container_Samples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCORE_IOC_Container_Samples.Pages
{
    public class IOCLifecycleSampleModel : PageModel
    {
        public string Singleton1 { get; }
        public string Singleton2 { get; }

        public string Scoped1 { get; }
        public string Scoped2 { get; }

        public string Transient1 { get; }
        public string Transient2 { get; }


        public IOCLifecycleSampleModel( [FromKeyedServices("Singleton")] IGuidService singleton1,
                                        [FromKeyedServices("Singleton")] IGuidService singleton2,

                                        [FromKeyedServices("Scoped")] IGuidService scoped1,
                                        [FromKeyedServices("Scoped")] IGuidService scoped2,

                                        [FromKeyedServices("Transient")] IGuidService transient1,
                                        [FromKeyedServices("Transient")] IGuidService transient2)
        {
            Singleton1 = singleton1.GetGuidString();
            Singleton2 = singleton2.GetGuidString();

            Scoped1 = scoped1.GetGuidString();
            Scoped2 = scoped2.GetGuidString();

            Transient1 = transient1.GetGuidString();
            Transient2 = transient2.GetGuidString();
        }

        public void OnGet()
        {
        }
    }
}
