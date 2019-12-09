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

        #region Synchronous
        public void CreateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBoard(string id)
        {
            throw new System.NotImplementedException();
        }

        public Board ReadBoard(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Board> ReadBoards()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Asynchronous
        public Task CreateBoardAsync(Board board)
            => _database.Boards.InsertOneAsync(board);

        public Task DeleteBoardAsync(string id)
            => _database.Boards.DeleteOneAsync(x => x.Id == id);


        public Task<Board> ReadBoardAsync(string id)
            => _database.Boards.Find(x => x.Id == id).FirstOrDefaultAsync();


        public Task<IEnumerable<Board>> ReadBoardsAsync()
            => Task.Run(()=>_database.Boards.Find(x => true).ToEnumerable());



        public Task UpdateBoardAsync(Board board)
            => _database.Boards.ReplaceOneAsync(new BsonDocument("_id", board.Id), board);
        #endregion
    }
}