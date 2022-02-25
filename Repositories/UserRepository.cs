using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

using Service.Queries;

namespace Service.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly MongoClient Client;
        private readonly IMongoDatabase Db;
        private readonly IMongoCollection<User> Collection;
        
        public UserRepository()
        {
            string urlMongo = Environment.GetEnvironmentVariable("MONGO_DB");
            urlMongo = urlMongo ?? "mongodb://127.0.0.1:27017";
            
            this.Client = new MongoClient(urlMongo);
            this.Db = Client.GetDatabase("ms-users");
            this.Collection = this.Db.GetCollection<User>("users");

        }

        public async Task<List<User>> Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return await this.Collection.FindAsync(
                    new BsonDocument {{"_id", new ObjectId(id)}}
                ).Result.ToListAsync();

            }
            else
            {
                return await this.Collection.FindAsync(_ => true).Result.ToListAsync();
            }

        }
        

        public async Task<User> Save(User persistUser)
        {
            User user = null;

            if (!String.IsNullOrEmpty(persistUser.Id))
            {
                // Update
                var filter = Builders<User>
                    .Filter
                    .Eq(s => s.Id, persistUser.Id);

                await this.Collection.ReplaceOneAsync(filter, persistUser);
            }
            else
            {
                // Insert
                await this.Collection.InsertOneAsync(persistUser);
            }


            return persistUser;
            
        }
        
        public async Task Delete(string id)
        {
            var filter = Builders<User>
                .Filter
                .Eq(s => s.Id, id);

            await this.Collection.DeleteOneAsync(filter);
        }

        

    }

}
