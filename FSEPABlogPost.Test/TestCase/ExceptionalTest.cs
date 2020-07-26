using FSEPABlogPost.BusinessLayers.Services;
using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FSEPABlogPost.Test.TestCase
{
    public class ExceptionalTest
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        public ExceptionalTest()
        {
            _services = new BlogPostServices(mockservice.Object);
        }

        /// <summary>
        /// creating static constructor for creating test output in text file 
        /// </summary>
        static ExceptionalTest()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        [Fact]
        public async Task CreateNewPost_Null_Failure()
        {
            // Arrange
            // Arrange
            var res = false;
            var blogPost = new BlogPost()
            {
                Title = "Post-Title",
                Abstract = "Post Abstract-1",
                Description = "Post Description -1"
            };
            blogPost = null;
            //Act 
            mockservice.Setup(blogRepo => blogRepo.Create(blogPost));
            var result = await _services.Create(blogPost);
            if (result == null)
            {
                res = true;
            }
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_exception_revised.txt", "CreateNewPost_Null_Failure=" + res + "\n");

        }
    }
}
