using FSEPABlogPost.DataLayers;
using FSEPABlogPost.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSEPABlogPost.BusinessLayers.Services.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        //Creating field or object or dbcontext and all collection
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<BlogPost> _dbCollection;
        private IMongoCollection<Comment> _dbCommentsCollection;

        //Injecting mongoContext in constructor
        public BlogPostRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<BlogPost>(typeof(BlogPost).Name);
            _dbCommentsCollection = _mongoContext.GetCollection<Comment>(typeof(Comment).Name);
        }

        /// <summary>
        /// Add new Commnet BlogPosst in MongoDb
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comments"></param>
        /// <returns>Comment object if create Comments is ok(200)</returns>
        public Task<Comment> Comments(string postId, Comment comments)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create new BlogPost in MongoDb
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns> BlogPost object if create method is ok(200)</returns>
        public async Task<BlogPost> Create(BlogPost blogPost)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// get All comments for specific post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllComments(string postId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get list of all Blogpost
        /// </summary>
        /// <returns>All BlogPost</returns>
        public async Task<IEnumerable<BlogPost>> GetAllPost()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get one BlogPost by id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns> single post</returns>
        public async Task<BlogPost> GetPostById(string postId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
