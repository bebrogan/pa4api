using System.Data.Common;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Dynamic;
using System.Collections.Generic;
using api.Interfaces;
using api.Model;

namespace api.Data
{
    public class PostDataHandler : IPostDataHandler
    {
        private Database db;
        public PostDataHandler()
        {
            db = new Database();
        }
        public void Delete(Post post)
        {
            string sql = "UPDATE post SET deleted= 'Y' WHERE id=@Id";
            var values = GetValues(post);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Post post)
        {
            string sql = "INSERT INTO post (Id, Text, Date)";
            sql += "VALUES (@ID, @Text, @Date)";

            var values = GetValues(post);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Post> Select()
        {
            List<Post> myPost = new List<Post>();

            db.Open();
            string sql = "SELECT * from post";
            
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Post temp = new Post(){ID = item.id, Text = item.text};
                myPost.Add(temp);


            }
            

            // db.Close();

            return myPost;
        }

        public void Update(Post post)
        {
            string sql = "UPDATE post SET id=@ID, text=@Text, date=@Date WHERE id=@ID";

            var values = GetValues(post);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public Dictionary<string,object> GetValues(Post post)
        {
            var values = new Dictionary<string,object>(){
                {"@id", post.ID},
                {"@text", post.Text},
                {"@date", post.Date},
                
            };
            
                return values;
        }
    }
}