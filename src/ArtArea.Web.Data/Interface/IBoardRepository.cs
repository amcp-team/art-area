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
        Task<IEnumerable<Board>> ReadBoards();
        Task<Board> ReadBoard(string id);
        Task CreateBoard(Board board);
        Task UpdateBoard(Board name);
        Task DeleteBoard(string id);
    }

}
