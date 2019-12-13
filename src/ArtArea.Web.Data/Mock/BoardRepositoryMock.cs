using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    public class BoardRepositoryMock : IBoardRepository
    {
        #region Syncronous

        public void CreateBoard(Board board)
        {
            if (ApplicationDbMock.Boards.Any(x => x.Id == board.Id))
                throw new Exception("Can't create this board - it already exists");

            ApplicationDbMock.Boards.Add(board);
        }
        public void DeleteBoard(string id)
        {
            var boardToDelete = ApplicationDbMock.Boards
                .SingleOrDefault(x => x.Id == id);

            if (boardToDelete != null)
                ApplicationDbMock.Boards.Remove(boardToDelete);
            else throw new Exception("Can't delete board - one doesn't exist");
        }
        public Board ReadBoard(string id)
        {
            return ApplicationDbMock.Boards.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<Board> ReadBoards()
        {
            return ApplicationDbMock.Boards;
        }
        public void UpdateBoard(Board board)
        {
            var boardToUpdate = ApplicationDbMock.Boards.SingleOrDefault(x => x.Id == board.Id);
            if (boardToUpdate != null)
                boardToUpdate = board;
            else throw new Exception("Can't update board - no such board exist");
        }

        #endregion

        #region Asyncronous

        public Task CreateBoardAsync(Board board)
        {
            if (ApplicationDbMock.Boards.Any(x => x.Id == board.Id))
                throw new Exception("Can't create this board - it already exists");

            return Task.Run(() => ApplicationDbMock.Boards.Add(board));
        }
        public Task DeleteBoardAsync(string id)
        {
            var board = ApplicationDbMock.Boards
                .SingleOrDefault(b => b.Id == id);

            if (board != null)
                return Task.Run(() => ApplicationDbMock.Boards.Remove(board));
            else throw new Exception("Can't delete board - one doesn't exist");
        }
        public Task<Board> ReadBoardAsync(string id)
        {
            return Task.Run(() => ApplicationDbMock.Boards
                    .SingleOrDefault(b => b.Id == id));
        }
        public Task<IEnumerable<Board>> ReadBoardsAsync()
        {
            return Task.Run(() => ApplicationDbMock.Boards.AsEnumerable());
        }
        public Task UpdateBoardAsync(Board board)
        {
            return Task.Run(() =>
            {
                var _board = ApplicationDbMock.Boards.SingleOrDefault(p => p.Id == board.Id);

                if (_board != null)
                    _board = board;
                else throw new Exception("Can't update board - no such board exist");
            });

        }

        public IQueryable<T> Filter<T>(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Models.Board> Filter<Board>(Expression<Func<Models.Board, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}