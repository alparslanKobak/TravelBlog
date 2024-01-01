using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelBlog.Entity.Abstract
{
    public interface ILikeCrud : ICrud<Like>
    {
        void AddLike(int blogPostId, int appUserId);
        void RemoveLike(int blogPostId, int appUserId);
        bool IsLiked(int blogPostId, int appUserId);

    }
}
