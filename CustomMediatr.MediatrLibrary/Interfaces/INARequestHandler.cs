using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediatr.MediatrLibrary.Interfaces
{
    public interface INARequestHandler<IRequest,IResponse>
    {
        Task<IResponse> Handle(IRequest request, CancellationToken token=default);
    }
}
