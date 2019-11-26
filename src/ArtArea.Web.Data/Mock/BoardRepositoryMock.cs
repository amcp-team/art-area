using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [Andrew] add list with board models & accessors to it based on interface
    public class BoardRepositoryMock : IBoardRepository
    {
        public async Task CreateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteBoardById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteBoardByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Board> GetBoardById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Board> GetBoardByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Board>> GetBoards()
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateBoardById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateBoardByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}