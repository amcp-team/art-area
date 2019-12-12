using System;
using System.Collections.Generic;
using Linq = System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;
using System.Linq;

namespace ArtArea.Web.Data.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private ApplicationDb _database;
        public BoardRepository(ApplicationDb database) => _database = database;

        #region Synchronous
        public void CreateBoard(Board board)
            => _database.Boards.InsertOne(board);
        public void DeleteBoard(string id)
            => _database.Boards.DeleteOne(x => x.Id == id);

        public Board ReadBoard(string id)
            => _database.Boards.Find(x => x.Id == id).FirstOrDefault();

        public IEnumerable<Board> ReadBoards()
            => _database.Boards.Find(x => true).ToList();

        public void UpdateBoard(Board board)
            => _database.Boards.ReplaceOne(new BsonDocument("_id", board.Id), board);

        public IQueryable<Board> Filter<Board>(Func<Board,bool> predicate)
        {
            throw new System.NotImplementedException();
            //var query = _database.Boards.AsQueryable().Where(predicate);
            //return query;
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