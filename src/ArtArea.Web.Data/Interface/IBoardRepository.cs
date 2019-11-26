using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
namespace ArtArea.Web.Data.Interface
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> ReadBoards();
        Task<Board> ReadBoard(string id);
        Task CreateBoard(Board board);
        Task UpdateBoard(Board name);
        Task DeleteBoard(string id);
    }

}
