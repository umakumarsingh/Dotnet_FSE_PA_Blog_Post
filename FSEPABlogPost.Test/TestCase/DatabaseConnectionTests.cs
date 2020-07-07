using FSEPABlogPost.DataLayers;
using FSEPABlogPost.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace FSEPABlogPost.Test.TestCase
{
    public class DatabaseConnectionTests
    {
        //mock for MongoDB Driver interfaces like IMongoDatabase, IMongoClient as below
        private Mock<IOptions<Mongosettings>> _mockOptions;
        private Mock<IMongoDatabase> _mockDB;
        private Mock<IMongoClient> _mockClient;
        //private TestCaseWriter _writer;
        /// <summary>
        /// define a Test initialize method which will be Constructor while using XUnit.
        /// Please note that in XUnit constructor will be invoked before each test method.
        /// </summary>
        public DatabaseConnectionTests()
        {
            _mockOptions = new Mock<IOptions<Mongosettings>>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
            //_writer = new TestCaseWriter(typeof(DatabaseConnectionTests).ToString());
        }
        /// <summary>
        /// creating static constructor for creating test output in text file 
        /// </summary>
        static DatabaseConnectionTests()
        {
            if (!File.Exists("../../../../output_database_revised.txt"))
                try
                {
                    File.Create("../../../../output_database_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_database_revised.txt");
                File.Create("../../../../output_database_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// If the constructor is invoked successfully, the object will be created successfully.
        /// </summary>
        [Fact]
        public void MongoDBContext_Constructor_Success()
        {
            //Arrange
            var res = false;
            var settings = new Mongosettings()
            {
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
                DatabaseName = "FSEPABlogPost"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);

            //Act 
            var context = new MongoDBContext(_mockOptions.Object);

            if (context != null)
            {
                res = true;
            }
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_database_revised.txt",
                "MongoDBContext_Constructor_Success="
                + res.ToString() + "\n");
            //Assert 
            Assert.NotNull(context);
        }
        /// <summary>
        /// Unit test cases for the GetCollection method
        /// A test for -ve scenario i.e when the collection name is passed as empty.
        /// </summary>
        [Fact]
        public void MongoDBContext_GetCollection_NameEmpty_Failure()
        {

            //Arrange
            var res = false;
            var settings = new Mongosettings()
            {
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
                DatabaseName = "FSEPABlogPost"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);

            //Act 
            var context = new MongoDBContext(_mockOptions.Object);
            var myCollection = context.GetCollection<BlogPost>("");
            if (context != null)
            {
                res = true;
            }
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_database_revised.txt",
                "MongoDBContext_GetCollection_NameEmpty_Failure="
                + res.ToString() + "\n");
            //Assert 
            Assert.Null(myCollection);
        }

        /// <summary>
        /// A test for +ve scenario i.e when a valid collection name is passed.
        /// Here we will verify if the GetCollection method returns proper collection.
        /// </summary>
        [Fact]
        public void MongoDBContext_GetCollection_ValidName_Success()
        {
            //Arrange
            var res = false;
            var settings = new Mongosettings()
            {
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
                DatabaseName = "FSEPABlogPost"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);

            _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDB.Object);

            //Act 
            var context = new MongoDBContext(_mockOptions.Object);
            var myCollection = context.GetCollection<BlogPost>("BlogPost");
            if (context != null)
            {
                res = true;
            }
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_database_revised.txt",
                "MongoDBContext_GetCollection_ValidName_Success="
                + res.ToString() + "\n");
            //Assert 
            Assert.NotNull(myCollection);
        }
    }
}
