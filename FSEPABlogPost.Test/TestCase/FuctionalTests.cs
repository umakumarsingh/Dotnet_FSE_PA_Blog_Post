using FSEPABlogPost.BusinessLayers.Services;
using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.Entities;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FSEPABlogPost.Test.TestCase
{
    public class FuctionalTests
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        public FuctionalTests()
        {
            _services = new BlogPostServices(mockservice.Object);
        }

        /// <summary>
        /// creating static constructor for creating test output in text file 
        /// </summary>
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }

        /// <summary>
        /// using this test method retriving all post as list
        /// </summary>
        /// <returns>post list and if list is present return true and write output in text file</returns>
        [Fact]
        public async Task Test_Get_GetAllPost()
        {
            // Arrange
            var res = false;
            // Act
            mockservice.Setup(blogRepo => blogRepo.GetAllPost());
            var result = await _services.GetAllPost();
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_revised.txt",
                "Test_Get_GetAllPost="
                + res.ToString() + "\n");
        }

        /// <summary>
        /// using this method create new BlogPost
        /// </summary>
        /// <returns>return true if post is created and write output in text file</returns>
        [Fact]
        public void Test_Post_CreateBlogPost()
        {
            // Arrange
            var res = false;
            var blogPost = new BlogPost()
            {
                Title = "Post-Title",
                Abstract = "Post Abstract-1",
                Description = "Post Description -1"
            };
            // Act
            mockservice.Setup(blogRepo => blogRepo.Create(blogPost));
            var result = _services.Create(blogPost);
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_revised.txt",
                "Test_Post_CreateBlogPost="
                + res.ToString() + "\n");
        }
        /// <summary>
        /// using this method get a single BlogPost
        /// </summary>
        /// <returns>return true if post is exists and write output in text file</returns>
        [Fact]
        public async Task Test_Get_GetOnePostById()
        {
            // Arrange
            var res = true;
            var blogpostId = "5ef6ee674fefa83a0cf69415";
            // Act
            mockservice.Setup(blogRepo => blogRepo.GetPostById(blogpostId));
            var result = await _services.GetPostById(blogpostId);
            if (result != null)
            {
                res = false;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_revised.txt",
                "Test_Get_GetOnePostById="
                + res.ToString() + "\n");
        }

        /// <summary>
        /// using this method create a commnet on BlogPost
        /// </summary>
        /// <returns>return true if comment inserted and write output in text file</returns>
        [Fact]
        public void Test_Post_CreateBlogPostComment()
        {
            // Arrange
            var res = false;
            var postId = "5ef312a0f05009584c12a93f";
            var comments = new Comment()
            {
                CommentMsg = "Post Title Comments -1 ",
                PostId = "5ef312a0f05009584c12a93f"
            };
            // Act
            mockservice.Setup(blogRepo => blogRepo.Comments(postId,comments));
            var result = _services.Comments(postId, comments);
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_revised.txt",
                "Test_Post_CreateBlogPostComment="
                + res.ToString() + "\n");
        }

        /// <summary>
        /// using this method get a list of comment related BlogPost
        /// </summary>
        /// <returns>return true if comment is exists and write output in text file</returns>
        [Fact]
        public async Task Test_Get_GetAllCommentById()
        {
            // Arrange
            var res = false;
            var postId = "5ef312a0f05009584c12a93f";
            // Act
            mockservice.Setup(blogRepo => blogRepo.GetAllComments(postId));
            var result = await _services.GetAllComments(postId);
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_revised.txt",
                "Test_Get_GetAllCommentById="
                + res.ToString() + "\n");
        }
    }
}
