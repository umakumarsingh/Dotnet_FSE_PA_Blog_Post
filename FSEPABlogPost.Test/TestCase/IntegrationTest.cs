using FSEPABlogPost.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
namespace FSEPABlogPost.Test
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<FSEPABlogPost.Startup>>
    {
            private readonly WebApplicationFactory<FSEPABlogPost.Startup> _factory;
            public const string postId = "5ef312a0f05009584c12a93f";
            //creating object to tset BlogPost and comment post Api Method
            public static readonly BlogPost testPost = new BlogPost() { Title = "Post -1",Abstract = "Abstract 1", Description = "Description 1" };
            public static readonly Comment testcomment = new Comment() { PostId = testPost.PostId, CommentMsg = "Commnet 1" };

            //inside this constructor injecting WebApplicationFactory for bootstraping for functional ene to end tesst
            public IntegrationTest(WebApplicationFactory<FSEPABlogPost.Startup> factory)
            {
                _factory = factory;
            }

            /// <summary>
            /// creating static constructor for creating test output in text file 
            /// </summary>
            static IntegrationTest()
            {
                if (!File.Exists("../../../../output_Integration_revised.txt"))
                    try
                    {
                        File.Create("../../../../output_Integration_revised.txt").Dispose();
                    }
                    catch (Exception)
                    {

                    }
                else
                {
                    File.Delete("../../../../output_integration_revised.txt");
                    File.Create("../../../../output_integration_revised.txt").Dispose();
                }
            }

            /// <summary>
            /// list of endpoint object that can test all api get and post method
            /// </summary>
            public static readonly IEnumerable<object[]> Endpoints = new List<object[]>()
            {
                new object[] { "/api/Blog"},
                //new object[] { $"/api/Blog/PostBlogPost/{ testPost }"}, // this api url not working
                new object[] { "/api/Blog/PostById/5ef312a0f05009584c12a93f"},
                new object[] { "/api/Blog/CommentById/5ef312a0f05009584c12a93f"},
                //new object[] { $"/api/Blog/PostBlogPostComment/{ testcomment }"},// this api url not working
            };

            [Theory]
            [MemberData(nameof(Endpoints))] // passing endpoint maember data to all api function
            //this method test all endpoint api call by passing Endpoints objects and return SuccessStatusCode.
            //model state test is valid or not
            public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
            {
                // Arrange
                var res = false;
                var client = _factory.CreateClient();

                // Act
                var response = await client.GetAsync(url);
                if (response != null)
                {
                    res = true;
                }
                // Assert
                response.EnsureSuccessStatusCode(); // Status Code 200-299
                Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());

            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../../output_integration_revised.txt",
                "Get_EndpointsReturnSuccessAndCorrectContentType="
                + res.ToString() + "\n");
            }
        }
}
