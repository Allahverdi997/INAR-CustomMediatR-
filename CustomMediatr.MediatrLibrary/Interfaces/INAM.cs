using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediatr.MediatrLibrary.Interfaces
{
    public interface INAM
    {
        Task<TResponse> Send<TResponse>(INARequest request,CancellationToken token=default);
    }
}
