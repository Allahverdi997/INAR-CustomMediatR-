using CustomMediatr.MediatrLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediatr.MediatrLibrary
{
    public static class NAServices
    {
        public static IServiceCollection AddCustomMediatRServices(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(x => !x.IsInterface && !x.IsAbstract).ToList();

            foreach (var handler in types)
            {
                if (IsHandler(handler))
                {
                    var requestType = handler.GetInterfaces()[0].GetGenericArguments()[0];
                    var responseType = handler.GetInterfaces()[0].GetGenericArguments()[1];

                    var genericType = typeof(INARequestHandler<,>).MakeGenericType(requestType, responseType);

                    services.AddTransient(genericType, handler);
                }
            }
            services.AddSingleton<INAM, NAM>();
            return services;
        }

        private static bool IsHandler(Type type)
        {
            var genericInterface = type.GetInterfaces();

            if (!genericInterface.Any())
                return false;
            if (genericInterface[0].GetGenericArguments().Length < 2)
                return false;

            var t = genericInterface[0].GetGenericArguments()[0];
            if (!t.GetInterfaces().Contains(typeof(INARequest)))
                return false;

            return true;

            //if (genericInterface.Any())
            //{
            //    if (genericInterface[0].GetGenericArguments().Length == 2)
            //    {
            //        var t = genericInterface[0].GetGenericArguments()[0];
            //        if (t.GetInterfaces().Contains(typeof(INARequest)))
            //        {
            //            return true;
            //        }
            //        return false;
            //    }
            //    return false;
            //}
            //return false;
        }
    }
}
