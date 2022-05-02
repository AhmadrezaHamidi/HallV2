using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tama.Data;
using tama.ViewModels;

namespace tama
{
    public static class DependeciConrtainer
    {
        public static void setServeses(IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<KaveNegarModel>(configuration.GetSection("KaveNegar:Api"));///baraye dastreci be maqadire apppseting.json az Configurstion estefade mikonim 
            services.Configure<PassarGadModel>(configuration.GetSection("PassarGad:SeryalNumber"));
            services.AddScoped<IuserReposetory,userReposetory>();    
        }
    }
}  