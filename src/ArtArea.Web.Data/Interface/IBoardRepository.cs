using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace ArtArea.Web.Data.Interface
{
    public interface IBoardRepository
    {
        //Asynchronous methods
        Task<IEnumerable<Board>> ReadBoardsAsync();
        Task<Board> ReadBoardAsync(string id);
        Task CreateBoardAsync(Board board);
        Task UpdateBoardAsync(Board board);
        Task DeleteBoardAsync(string id);

        //Synchronous methods
        IEnumerable<Board> ReadBoards();
        Board ReadBoard(string id);
        void CreateBoard(Board board);
        void UpdateBoard(Board board);
        void DeleteBoard(string id);
        IQueryable<Models.Board> Filter<Board>(Expression<Func<Models.Board, bool>> predicate);
    }

}
