using Microsoft.Extensions.Options;
using MinimalGlick.Models;
using MongoDB.Driver;

namespace MinimalGlick.Services
{
    public class GlycemiaServices
    {
        private readonly IMongoCollection<Glycemia> _glycemiaCollection;

        public GlycemiaServices(IOptions<GlycemiaDatabaseSettings> glycemiaDatabaseSettings) 
        {
            var mongoClient = new MongoClient(glycemiaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(glycemiaDatabaseSettings.Value.DatabaseName);

            _glycemiaCollection = mongoDatabase.GetCollection<Glycemia>(glycemiaDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Glycemia>> GetGlycemiasAsync ()=> 
            await _glycemiaCollection.Find(_ => true).ToListAsync();
        
        public async Task CreateGlycemiasAsync (Glycemia glycemia) =>
            await _glycemiaCollection.InsertOneAsync(glycemia);

    }
}
