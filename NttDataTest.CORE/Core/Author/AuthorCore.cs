using AutoMapper;
using NttDataTest.CONTEXT.Context;
using NttDataTest.CORE.Core.Author.Interface;
using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Entities;
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
        public AuthorCore( NttDataTestContext nttDataTestContext, IMapper mapper)
        {
            _context = nttDataTestContext;
            _mapper = mapper; 
        }
        #endregion

        #region Methods
        public async Task<List<AuthorDTO>> GetAll()
        {
            var data = _context.Authors.ToList();
            if (data.Count() <= 0)
            {
                return null;
            }
            var dataMapper = _mapper.Map< List<AuthorDTO>>(data);
            return await Task.FromResult(dataMapper.Count() > 0 ? dataMapper : null);
        }

        #endregion

    }
}
