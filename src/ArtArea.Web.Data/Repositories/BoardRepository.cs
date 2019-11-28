using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ArtArea.Web.Data.Repositories
{
    public class BoardRepository : IUserRepository
    {
        private ApplicationDb _database;
        BoardRepository(ApplicationDb database) => _database = database;
        public async Task CreateBoard(Board board)
            => await _database.Boards.InsertOneAsync(board);
        public async Task DeleteBoard(string id)
            => await _database.Boards.DeleteOneAsync(x => x.Id == id);

        public async Task<Board> ReadBoard(string id)
            => await _database.Boards.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Board>> ReadBoards()
            => await _database.Boards.Find(x => true).ToListAsync();

        public async Task UpdateBoard(Board board)
            => await _database.Boards.ReplaceOneAsync(new BsonDocument("_id", board.Id), board);
    }
}