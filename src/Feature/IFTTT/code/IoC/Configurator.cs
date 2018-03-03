using Community.Feature.IFTTT.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Community.Feature.IFTTT.IoC
{
    public class Configurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IThresholdService), typeof(ThresholdService));
            serviceCollection.AddTransient(typeof(IIftttService), typeof(IftttService));
            serviceCollection.AddTransient(typeof(IRulesService), typeof(RulesService));
        }
    }
}