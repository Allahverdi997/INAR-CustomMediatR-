using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediatr.MediatrLibrary
{
    public static class GetScopeServiceCustom
    {
        public static T GetService<T>(IServiceScopeFactory ServiceScopeFactory)
        {
           using (var scope = ServiceScopeFactory.CreateScope())
           {
               var scopedServices = scope.ServiceProvider;
               var service = scopedServices.GetRequiredService<T>();
               return service;
           }
        }
    }
}
