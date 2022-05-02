using OohelpWebApps.Presentations.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OohelpWebApps.Presentations.Domain.Repositories.Mock
{
    public class BoardRepository : Interfaces.IBoardRepository
    {
        public Task<bool> CreateAsync(BoardDto board)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BoardDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BoardDto?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BoardDto board)
        {
            throw new NotImplementedException();
        }        
    }
}
