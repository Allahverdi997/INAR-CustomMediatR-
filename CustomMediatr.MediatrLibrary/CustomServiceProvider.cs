using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediatr.MediatrLibrary
{
    public static class CustomServiceProvider
    {
        public static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider => _serviceProvider;
        public static void SetInstance(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static IServiceProvider UseCustomServiceProvider(this IServiceProvider serviceProvider)
        {
            SetInstance(serviceProvider);
            return serviceProvider;
        }
    }
}
