using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSEPABlogPost.BusinessLayers.Services
{
    public class BlogPostServices : IBlogPostServices
    {
        /// <summary>
        /// creating a referance object of IBlogPostRepository
        /// </summary>
        private readonly IBlogPostRepository _blogPostRepository;

        /// <summary>
        /// injecting IBlogPostRepository in consructor to access all methods
        /// </summary>
        /// <param name="blogPostRepository"></param>
        public BlogPostServices(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        /// <summary>
        /// Add new Commnet in BlogPosst to MongoDb
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public async Task<Comment> Comments(string postId, Comment comments)
        {
            return await _blogPostRepository.Comments(postId, comments);
        }
        /// <summary>
        /// Add new BlogPost to MongoDb
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        public async Task<BlogPost> Create(BlogPost blogPost)
        {
            return await _blogPostRepository.Create(blogPost);
        }
        /// <summary>
        /// Get all comments from MongoDb base on blogPost Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>

        public async Task<IEnumerable<Comment>> GetAllComments(string postId)
        {
            return await _blogPostRepository.GetAllComments(postId);
        }
        /// <summary>
        /// Get all BlogPost
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BlogPost>> GetAllPost()
        {
            return await _blogPostRepository.GetAllPost();
        }
        /// <summary>
        /// Get a single BlogPost from MongoDb
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<BlogPost> GetPostById(string postId)
        {
            return await _blogPostRepository.GetPostById(postId);
        }
    }
}
