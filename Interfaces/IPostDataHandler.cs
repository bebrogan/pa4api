using System.Collections.Generic;
using api.Model;

namespace api.Interfaces
{
    public interface IPostDataHandler
    {
         public List<Post> Select();
         public void Delete(Post post);

         public void Insert(Post post);

         public void Update(Post post);
    }
}