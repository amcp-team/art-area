using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data;
using ArtArea.Web.Data.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

public class BoardRepository : IBoardRepository
{
    public ApplicationDb db;
    BoardRepository(ApplicationDb database) => db = database;
    public async Task CreateBoard(Board board)
        => await db.Boards.InsertOneAsync(board);
    public async Task DeleteBoard(string id)
        => await db.Boards.DeleteOneAsync(x => x.Id == id);

    public async Task<Board> ReadBoard(string id)
        => await db.Boards.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Board>> ReadBoards()
        => await db.Boards.Find(x => true).ToListAsync();

    public async Task UpdateBoard(Board board)
        => await db.Boards.ReplaceOneAsync(new BsonDocument("id", board.Id), board);
}