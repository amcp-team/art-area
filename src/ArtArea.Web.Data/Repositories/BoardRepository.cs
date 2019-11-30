using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ArtArea.Web.Data.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private ApplicationDb _database;
        BoardRepository(ApplicationDb database) => _database = database;

        public void CreateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateBoardAsync(Board board)
            => await _database.Boards.InsertOneAsync(board);

        public void DeleteBoard(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteBoardAsync(string id)
            => await _database.Boards.DeleteOneAsync(x => x.Id == id);

        public Board ReadBoard(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Board> ReadBoardAsync(string id)
            => await _database.Boards.Find(x => x.Id == id).FirstOrDefaultAsync();

        public IEnumerable<Board> ReadBoards()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Board>> ReadBoardsAsync()
            => await _database.Boards.Find(x => true).ToListAsync();

        public void UpdateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateBoardAsync(Board board)
            => await _database.Boards.ReplaceOneAsync(new BsonDocument("_id", board.Id), board);
    }
}