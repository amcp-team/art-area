using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
namespace ArtArea.Web.Data.Interface
{
    // TODO [Andrey] CRUD interface for board entity in db
    //      - get board by id    
    //      - post board with passed object
    //      - edit board by id
    //      - delete board by id
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> GetBoards();
        Task<Board> GetBoardById(string id);
        Task<Board> GetBoardByName(string name);
        Task CreateBoard(Board board);
        Task UpdateBoardById(string id);
        Task UpdateBoardByName(string name);
        Task DeleteBoardById(string id);
        Task DeleteBoardByName(string name);
    }

}
