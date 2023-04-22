using CustomMediatr.MediatrLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediatr.Commands
{
    public class CreateCommand : INARequest
    {
        //public IDTO DTO { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class CreateCommandHandler : INARequestHandler<CreateCommand, string>
    {
        public async Task<string> Handle(CreateCommand request, CancellationToken token = default)
        {
            return "A";
        }
    }
}
