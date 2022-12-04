using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BookRepository.IBookRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.BookRepository
{
    public class BookRepository:IBookRepository.IBookRepository
    {
        public readonly BookDbContext _bookDbContext;
        public BookRepository(BookDbContext bookDbContext) 
        {
          _bookDbContext=bookDbContext;
        }

        public async Task<ModelsOfBook> AddBookAsync(ModelsOfBook Book)
        {
            var BookData = await _bookDbContext.Booktbl.AddAsync(Book);
            _bookDbContext.SaveChanges();
            return Book;
        }

        public async Task <ModelsOfBook> DeleteBookAsync(int id)
        {
            var BookData = await _bookDbContext.Booktbl.FirstOrDefaultAsync(x=>x.Id==id);
            _bookDbContext.Remove(BookData);
            await _bookDbContext.SaveChangesAsync();
            return BookData;
        }

        public async Task<IEnumerable<ModelsOfBook>> GetAllAsync()
        {
            var BookData = await _bookDbContext.Booktbl.ToListAsync();
            return BookData;
        }
        public async Task<ModelsOfBook> GetByIdAsync(int id) 
        {
            var BookData = await _bookDbContext.Booktbl.FirstOrDefaultAsync(x => x.Id == id);
            return BookData;
        }

        public async Task<ModelsOfBook> UpdateBookAsync(int id, ModelsOfBook Book)
        {
            var BookData = await _bookDbContext.Booktbl.FirstOrDefaultAsync(x => x.Id == id);
            if (id == null) { return null; }
            
BookData.BookName=Book.BookName;
            BookData.BookType=Book.BookType;
            BookData.Price = Book.Price;

            await _bookDbContext.SaveChangesAsync();
            return BookData;
        }

    }
}
