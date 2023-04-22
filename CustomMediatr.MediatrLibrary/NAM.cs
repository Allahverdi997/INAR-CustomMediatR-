using CustomMediatr.MediatrLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediatr.MediatrLibrary
{
    public class NAM : INAM
    {
        public Task<TResponse> Send<TResponse>(INARequest request, CancellationToken token)
        {
            if (request.GetType().GetInterfaces().Contains(typeof(INARequest)))
            {
                var genericType = typeof(INARequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

                var handler = CustomServiceProvider.ServiceProvider.GetService(genericType);

                object[] obj = new object[2] { request,token == CancellationToken.None ? default : token };
                return (Task<TResponse>)genericType.GetMethod("Handle").Invoke(handler, obj);
            }
            return null;
        }
    }
}
