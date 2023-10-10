using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NttDataTest.CONTEXT.Context;
using NttDataTest.CORE.Core.Author.Interface;
using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Entities;
using NttDataTest.MODELS.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.CORE.Core.Author
{
    public class AuthorCore : IAuthorCore
    {
        #region Fields
        private readonly NttDataTestContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Builder
        public AuthorCore(NttDataTestContext nttDataTestContext, IMapper mapper)
        {
            _context = nttDataTestContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<AuthorDTO>> GetAll()
        {
            var data = await _context.Authors.ToListAsync();
            if (data.Count() <= 0)
            {
                return new List<AuthorDTO>();
            }
            var dataMapper = _mapper.Map<List<AuthorDTO>>(data);
            return dataMapper.Count() > 0 ? dataMapper : null;
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            var data = _context.Authors.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                var dataMapper = _mapper.Map<AuthorDTO>(data);
                return await Task.FromResult(dataMapper != null ? dataMapper : null);
            }
            return null;
        }

        public async Task<bool> AddOrUpdate(AuthorRequest model)
        {
            if (model.Id <= 0)
            {
                var map = _mapper.Map<MODELS.Entities.Author>(model);
                _context.Authors.Add(map);
                var res = await _context.SaveChangesAsync();
                return res != 0 ? true : false;
            }
            else
            {
                var map = _mapper.Map<MODELS.Entities.Author>(model);
                _context.Authors.Update(map);
                var res = await _context.SaveChangesAsync();
                return res != 0 ? true : false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var registerToDelete = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (registerToDelete != null)
            {
                _context.Authors.Remove(registerToDelete);
                var res = await _context.SaveChangesAsync();
                return res != 0 ? true : false;

            }
            return false;
        }

        #endregion

    }
}
