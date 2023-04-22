using AutoMapper;
using CustomMediatr.MediatrLibrary;
using CustomMediatr.MediatrLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediatr.Queries
{
    public class GetAllDepartmentQuery:INARequest
    {
    }

    public class GetAllDepartmentQueryHandler : INARequestHandler<GetAllDepartmentQuery, string>
    {
        public IServiceScopeFactory ServiceScopeFactory { get; set; }
        public GetAllDepartmentQueryHandler(IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
        }

        public Task<string> Handle(GetAllDepartmentQuery request, CancellationToken token = default)
        {
                IUnitOfWork UnitOfWork = GetScopeServiceCustom.GetService<IUnitOfWork>(ServiceScopeFactory);
                var m = UnitOfWork.A;
                return Task.FromResult(m.ToString());
        }
    }
}
