using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonVO>> FindAllPerson()
        {
            List<Person> persons =  await _context.Persons.ToListAsync();
            return _mapper.Map<List<PersonVO>>(persons);
        }

        public async Task<PersonVO> FindById(long id)
        {
            Person person = await _context.Persons.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return _mapper.Map<PersonVO>(person);
        }
        
        public async Task<PersonVO> Create(PersonVO vo)
        {
            Person person = _mapper.Map<Person>(vo);
            _context.Add(person);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonVO>(person);
        }

        public async Task<PersonVO> Update(PersonVO vo)
        {
            Person person = _mapper.Map<Person>(vo);
            _context.Update(person);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonVO>(person); ;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Person person = await _context.Persons.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (person == null) return false;

                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
