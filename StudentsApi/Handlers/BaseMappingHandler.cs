using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace StudentsApi.Handlers
{
    internal abstract class BaseMappingHandler<TRequestContext, TFromModel, TToModel> : IRequestHandler<TRequestContext, IEnumerable<TToModel>>
        where TRequestContext : IRequest<IEnumerable<TToModel>>
        where TFromModel : class
    {
        private readonly IMapper _mapper;

        protected BaseMappingHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<TToModel>> Handle(TRequestContext request, CancellationToken cancellationToken)
        {
            IEnumerable<TFromModel> result = await GetData(request);

            return result.Select(x => _mapper.Map<TFromModel, TToModel>(x)).ToArray();
        }

        protected abstract Task<IEnumerable<TFromModel>> GetData(TRequestContext request);
    }
}
