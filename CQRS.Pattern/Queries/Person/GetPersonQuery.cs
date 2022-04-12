using System;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.BLL.Services.Person;
using MediatR;

namespace CQRS.Pattern.Queries.Person
{
    public class GetPersonQuery : IRequest<PersonDto>
    {
        public Guid Id { get; set; }

        public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto>
        {
            private readonly IPersonService _personService;

            public GetPersonQueryHandler(
                IPersonService personService
            )
            {
                _personService = personService;
            }

            public async Task<PersonDto> Handle(GetPersonQuery query, CancellationToken cancellationToken)
            {
                var person = await _personService.GetPersonByIdAsync(query.Id);
                if (person == null)
                    throw new NullReferenceException();

                return person;
            }
        }
    }
}