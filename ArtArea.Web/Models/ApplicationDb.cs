using ArtArea.Web.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ApplicationDb
{
    private IMongoDatabase database;
    public IGridFSBucket Bucket;
    public ApplicationDb()
    {
        var client = new MongoClient();
        database = client.GetDatabase("artareadb");
        Bucket = new GridFSBucket(database);
    }
    public IMongoCollection<Issue> Issues => database.GetCollection<Issue>("issues");
    public IMongoCollection<File> Files => database.GetCollection<File>("files");
    public IMongoCollection<Comment> Comments => database.GetCollection<Comment>("comments");
    public IMongoCollection<Project> Projects => database.GetCollection<Project>("projects");
    public IMongoCollection<User> Users => database.GetCollection<User>("user");


}