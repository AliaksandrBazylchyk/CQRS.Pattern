using System;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.BLL.Services.Person;
using CQRS.Pattern.Models;
using MediatR;

namespace CQRS.Pattern.Queries.Person
{
    public class FilterPersonQuery : IRequest<DataWithTotal<PersonDto>>
    {
        public int Guid { get; set; }

        public class FilterPersonQueryHandler : IRequestHandler<FilterPersonQuery, DataWithTotal<PersonDto>>
        {
            private readonly IPersonService _personService;

            public FilterPersonQueryHandler(
                IPersonService personService
            )
            {
                _personService = personService;
            }

            public async Task<DataWithTotal<PersonDto>> Handle(
                FilterPersonQuery query,
                CancellationToken cancellationToken
            )
            {
                return null;
            }
        }
    }
}