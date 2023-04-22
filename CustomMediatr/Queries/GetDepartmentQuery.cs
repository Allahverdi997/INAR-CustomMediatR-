using CustomMediatr.MediatrLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomMediatr.Queries
{
    public class GetDepartmentQuery : INARequest
    {
        public int Id { get; set; }
        public GetDepartmentQuery(int id)
        {
            Id = id;
        }
    }

    public class GetDepartmentQueryHandler : INARequestHandler<GetDepartmentQuery, string>
    {
        public async Task<string> Handle(GetDepartmentQuery request, CancellationToken token = default)
        {
            return request.Id.ToString();
        }
    }
}
