using BlazorTry.Models;
using BlazorTry.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTry {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var nameList = new ObservableCollection<string> { "‰Jƒ–èÎ“ø", "‹ãð—ÑŒç", "”’”TƒNƒƒ~", "Œ‹–Úƒ†ƒC", "Šª”T‚à‚È‚©" };
            builder.Services.AddScoped(sp => new Lottery(nameList));
            builder.Services.AddTransient<LotteryPageViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
