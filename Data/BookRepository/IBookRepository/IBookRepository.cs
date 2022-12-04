using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BookRepository.IBookRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<ModelsOfBook>> GetAllAsync();
        Task<ModelsOfBook> GetByIdAsync(int id);
        
        Task<ModelsOfBook> AddBookAsync(ModelsOfBook Book);
        Task<ModelsOfBook>UpdateBookAsync(int id,ModelsOfBook Book);
        Task <ModelsOfBook> DeleteBookAsync(int id);
    }
}
