using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    public class BoardRepositoryMock : IBoardRepository
    {
        public async Task CreateBoard(Board board)
        {
            await Task.Run(() =>
            {
                if(ApplicationDbMock.Boards.Any(x => x.Id == board.Id))
                    throw new Exception("Can't create this board - it already exists");

                ApplicationDbMock.Boards.Add(board);
            });
        }

        public async Task DeleteBoard(string id)
        {
            await Task.Run(() =>
            {
                var board = ApplicationDbMock.Boards
                    .SingleOrDefault(b => b.Id == id);

                if (board != null)
                    ApplicationDbMock.Boards.Remove(board);
                else throw new Exception("Can't delete board - one doesn't exist");
            });
        }

        public async Task<Board> ReadBoard(string id)
        {
            return await Task.Run(() =>
            {
                return ApplicationDbMock.Boards
                    .SingleOrDefault(b => b.Id == id);

            });
        }

        public async Task<IEnumerable<Board>> ReadBoards()
        {
            return await Task.Run(() => ApplicationDbMock.Boards);
        }

        public async Task UpdateBoard(Board board)
        {
            await Task.Run(() =>
            {
                var _board = ApplicationDbMock.Boards.SingleOrDefault(p => p.Id == board.Id);

                if (_board != null)
                    _board = board;
                else throw new Exception("Can't update board - no such board exist");
            });

        }
    }
}