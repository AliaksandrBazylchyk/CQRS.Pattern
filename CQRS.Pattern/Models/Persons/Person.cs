using CQRS.Pattern.Infrastructure.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRS.Pattern.Models.Persons
{
    public class Person : BaseEntity
    {
        /// <summary>
        /// Person's first name
        /// </summary>
        [BsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        /// Person's second name
        /// </summary>
        [BsonRequired]
        public string LastName { get; set; }

        /// <summary>
        /// Person's age
        /// </summary>
        [BsonRequired]
        public uint Age { get; set; }
    }
}