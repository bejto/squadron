using System;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using Squadron;


namespace NUnit_Mongo.Tests
{
    public class Tests : SquadronSetup<MongoReplicaSetResource>
    {
        [Test]
        public void Test1()
        {
            //Act
            Action action = () =>
            {
                using (IClientSessionHandle session = Resource.Client.StartSession())
                {
                    IMongoCollection<BsonDocument> collection = Resource.CreateCollection<BsonDocument>("bar");
                    session.StartTransaction();
                    collection.InsertOne(session, new BsonDocument("name", "test"));
                    session.CommitTransaction();
                }
            };

            //Assert
            action.Should().NotThrow();
        }
    }
}
