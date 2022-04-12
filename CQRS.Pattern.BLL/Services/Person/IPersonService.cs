using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.Pattern.BLL.Models;

namespace CQRS.Pattern.BLL.Services.Person
{
    public interface IPersonService
    {
        public Task<PersonDto> GetPersonByIdAsync(Guid id);
        public Task<IEnumerable<PersonDto>> GetAllPersonsAsync();
        public Task<PersonDto> CreateNewPersonAsync(PersonDto person);
    }
}