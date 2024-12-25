using MongoDB.Bson;
using MongoDB.Driver;
using OpenHolidaysApi.Models;

namespace OpenHolidaysApi.Repositories
{
    public class MongoDbHolidaysRepository : IHolidaysRepository
    {
        private const string _databaseName = "event";
        private const string _collectionName = "holidays";
        private readonly IMongoCollection<Holiday> _holidayCollection;
        private readonly FilterDefinitionBuilder<Holiday> _filterDefinitionBuilder = Builders<Holiday>.Filter;

        public MongoDbHolidaysRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(_databaseName);
            _holidayCollection = database.GetCollection<Holiday>(_collectionName);
        }

        public async Task AddHolidayAsync(Holiday holiday)
        {
            await _holidayCollection.InsertOneAsync(holiday);
        }

        public async Task DeleteHolidayAsync(Guid id)
        {
            var filterDefinition = _filterDefinitionBuilder.Eq(holiday => holiday.Id, id);
            await _holidayCollection.DeleteOneAsync(filterDefinition);
        }

        public async Task<Holiday> GetHolidayAsync(Guid id)
        {
            var filterDefinition = _filterDefinitionBuilder.Eq(holiday => holiday.Id, id);
            return await _holidayCollection.Find(filterDefinition).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            return await _holidayCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync(string country)
        {
            var filterDefinition = _filterDefinitionBuilder.Eq(holiday => holiday.Country, country);
            return await _holidayCollection.Find(filterDefinition).ToListAsync();
        }

        public async Task UpdateHolidayAsync(Holiday holiday)
        {
            var filterDefinition = _filterDefinitionBuilder.Eq(h => h.Id, holiday.Id);
            await _holidayCollection.ReplaceOneAsync(filterDefinition, holiday);
        }
    }
}
