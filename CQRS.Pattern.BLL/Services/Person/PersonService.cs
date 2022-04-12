using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Pattern.BLL.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly INpgPersonRepository _npgPersonRepository;
        private readonly IMongoPersonRepository _mongoPersonRepository;

        private readonly IMapper _mapper;

        public PersonService(
            INpgPersonRepository npgPersonRepository,
            IMapper mapper,
            IMongoPersonRepository mongoPersonRepository
        )
        {
            _npgPersonRepository = npgPersonRepository;
            _mapper = mapper;
            _mongoPersonRepository = mongoPersonRepository;
        }

        public async Task<PersonDto> GetPersonByIdAsync(Guid id)
        {
            var entity = await _mongoPersonRepository.FindByIdAsync(id);
            var result = _mapper.Map<DAL.Entities.Person, PersonDto>(entity);

            return result;
        }

        public Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
        {
            var entities = _mongoPersonRepository.GetAll();

            return Task.FromResult(entities
                .Select(person => _mapper.Map<DAL.Entities.Person, PersonDto>(person)).AsEnumerable());
        }

        public async Task<PersonDto> CreateNewPersonAsync(PersonDto person)
        {
            var personForCreating = _mapper.Map<PersonDto, DAL.Entities.Person>(person);

            // TODO Transaction?
            var entity = await _npgPersonRepository.AddAsync(personForCreating);
            await _mongoPersonRepository.InsertOneAsync(entity);

            var mappedPerson = _mapper.Map<DAL.Entities.Person, PersonDto>(entity);

            return mappedPerson;
        }
    }
}