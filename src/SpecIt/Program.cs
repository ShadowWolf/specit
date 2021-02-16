using System;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plk.Blazor.DragDrop;
using Syncfusion.Blazor;

namespace SpecIt
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("license.key");
            if (stream == null)
            {
                throw new InvalidOperationException(
                    $"You must create a file in the root of this project called 'license.key' that should contain your syncfusion key");
            }
            
            using var reader = new StreamReader(stream);
            var licenseKey = await reader.ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(licenseKey))
            {
                throw new InvalidOperationException("License key file was found but seemed to contain no key");
            }
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey.Trim());
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            
            
            builder.Configuration.Bind("Syncfusion");
            
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddSyncfusionBlazor()
                .AddBlazorDragDrop()
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
