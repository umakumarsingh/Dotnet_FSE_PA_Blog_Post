using System;
using System.Collections.Generic;
using System.Text;

namespace FSEPABlogPost.Test.Exceptions
{
    public class BlogPostNullException : Exception
    {
        public string Message;

        public BlogPostNullException()
        {
            Message = "BlogPost is Null";
        }
        public BlogPostNullException(string message)
        {
            Message = message;
        }
    }
}
