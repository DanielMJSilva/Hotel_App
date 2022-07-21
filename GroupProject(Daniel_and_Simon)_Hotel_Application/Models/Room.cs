using Amazon.DynamoDBv2.DataModel;

namespace Hotel.Models
{
    [DynamoDBTable("Room")]
    public class Room
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBRangeKey]
        public string Location { get; set; }

        [DynamoDBProperty]
        public decimal Price { get; set; }

        [DynamoDBProperty]
        public string RoomName { get; set; }

        [DynamoDBProperty]
        public string Image { get; set; }
    }
}
