using System.Collections.Generic;
using System.Linq;
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
            await Task.Run(() => ApplicationDbMock.Boards.Add(board));
        }

        public async Task DeleteBoardById(string id)
        {
            await Task.Run(() =>
            {
                var board = ApplicationDbMock.Boards
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

                if(board != null)
                    ApplicationDbMock.Boards.Remove(board);
            });
        }

        public async Task DeleteBoardByName(string name)
        {
            await Task.Run(() =>
            {
                var board = ApplicationDbMock.Boards
                    .Where(b => b.Name == name)
                    .FirstOrDefault();

                if(board != null)
                    ApplicationDbMock.Boards.Remove(board);
            });
        }

        public async Task<Board> ReadBoardById(string id)
        {
            return await Task.Run(() => 
            {
                return ApplicationDbMock.Boards
                    .Where(b => b.Id == id)
                    .FirstOrDefault();
            });
        }

        public async Task<Board> ReadBoardByName(string name)
        {
            return await Task.Run(() => 
            {
                return ApplicationDbMock.Boards
                    .Where(b => b.Name == name)
                    .FirstOrDefault();
            });
        }

        public async Task<IEnumerable<Board>> ReadBoards()
        {
            return await Task.Run(() => ApplicationDbMock.Boards);
        }

        public async Task UpdateBoard(Board board)
        {
            await Task.Run(() => 
                ApplicationDbMock.Boards[ApplicationDbMock.Boards.FindIndex(b => b.Id == board.Id)] = board);
        }
    }
}