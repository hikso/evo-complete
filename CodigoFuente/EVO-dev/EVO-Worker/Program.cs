using EVO_Worker.Workers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EVO_Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
            
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<WOrdenCompraSAPEVO>();
                services.AddHostedService<WArticuloBodegaSAPEVO>();
            }).UseWindowsService();
    }
}
