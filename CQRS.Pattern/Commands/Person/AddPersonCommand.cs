using System;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.BLL.Services.Person;
using MediatR;

namespace CQRS.Pattern.Commands.Person
{
    public class AddPersonCommand : IRequest<PersonDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, PersonDto>
        {
            private readonly IPersonService _personService;

            public AddPersonCommandHandler(IPersonService personService) =>
                _personService = personService ?? throw new ArgumentNullException(nameof(personService));


            public async Task<PersonDto> Handle(AddPersonCommand command, CancellationToken cancellationToken)
            {
                var person = new PersonDto
                {
                    Age = (uint) command.Age,
                    FirstName = command.FirstName,
                    LastName = command.LastName
                };

                await _personService.CreateNewPersonAsync(person);

                return person;
            }
        }
    }
}