using Amazon.DynamoDBv2.DataModel;
using System;

namespace Hotel.Models
{
    [DynamoDBTable("Booking")]
    public class Booking
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBRangeKey]
        public string UserId { get; set; }

        [DynamoDBProperty]
        public string RoomId { get; set; }

        [DynamoDBProperty]
        public DateTime StartDate { get; set; }

        [DynamoDBProperty]
        public DateTime EndDate { get; set; }

        [DynamoDBProperty]
        public decimal Price { get; set; }

        [DynamoDBProperty]
        public int NumPeople { get; set; }
    }
}
