using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NttDataTest.CONTEXT.Context;
using NttDataTest.CORE.Core.Book.Interface;
using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataTest.CORE.Core.Book
{
    public class BookCore : IBookCore
    {
        #region Fields
        private readonly NttDataTestContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Builder
        public BookCore(NttDataTestContext nttDataTestContext, IMapper mapper)
        {
            _context = nttDataTestContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<BookDTO>> GetAll()
        {
            var booksWithAuthors = await _context.Books
                .Include(b => b.IdNavigation) 
                .ToListAsync();

            if (booksWithAuthors.Count() <= 0)
            {
                return new List<BookDTO>();
            }
            var dataMapper = _mapper.Map<List<BookDTO>>(booksWithAuthors);
            return dataMapper.Count() > 0 ? dataMapper : null;
        }

        public async Task<BookDTO> GetById(int id)
        {
            var data = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                var dataMapper = _mapper.Map<BookDTO>(data);
                return await Task.FromResult(dataMapper != null ? dataMapper : null);
            }
            return null;
        }

        public async Task<bool> AddOrUpdate(BookRequest model)
        {
            if (model.Id <= 0)
            {
                var map = _mapper.Map<MODELS.Entities.Book>(model);
                _context.Books.Add(map);
                var res = await _context.SaveChangesAsync();
                return res != 0 ? true : false;
            }
            else
            {
                var map = _mapper.Map<MODELS.Entities.Book>(model);
                _context.Books.Update(map);
                var res = await _context.SaveChangesAsync();
                return res != 0 ? true : false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var registerToDelete = _context.Books.FirstOrDefault(x => x.Id == id);
            if (registerToDelete != null)
            {
                _context.Books.Remove(registerToDelete);
                var res = await _context.SaveChangesAsync();
                return res != 0 ? true : false;

            }
            return false;
        }

        #endregion
    }
}
