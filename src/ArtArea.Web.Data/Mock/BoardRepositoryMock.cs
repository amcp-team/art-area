using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [A] rename asyncronous methods (thhat return task) with Async postfix
    //      create syncronous methods that correspond existsing async
    public class BoardRepositoryMock : IBoardRepository
    {
        public Task CreateBoardAsync(Board board)
        {
            return Task.Run(() =>
            {
                if(ApplicationDbMock.Boards.Any(x => x.Id == board.Id))
                    throw new Exception("Can't create this board - it already exists");

                ApplicationDbMock.Boards.Add(board);
            });
        }

        public void CreateBoard(Board board)
        {
            // same as CreateBoardAsync without task run
        }

        public Task DeleteBoard(string id)
        {
            return Task.Run(() =>
            {
                var board = ApplicationDbMock.Boards
                    .SingleOrDefault(b => b.Id == id);

                if (board != null)
                    ApplicationDbMock.Boards.Remove(board);
                else throw new Exception("Can't delete board - one doesn't exist");
            });
        }

        public Task<Board> ReadBoard(string id)
        {
            return Task.Run(() =>
            {
                return ApplicationDbMock.Boards
                    .SingleOrDefault(b => b.Id == id);

            });
        }

        public Task<IEnumerable<Board>> ReadBoards()
        {
            return Task.Run(() => ApplicationDbMock.Boards.AsEnumerable());
        }

        public Task UpdateBoard(Board board)
        {
            return Task.Run(() =>
            {
                var _board = ApplicationDbMock.Boards.SingleOrDefault(p => p.Id == board.Id);

                if (_board != null)
                    _board = board;
                else throw new Exception("Can't update board - no such board exist");
            });

        }
    }
}