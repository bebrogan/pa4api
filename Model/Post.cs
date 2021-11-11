using System;
using api.Data;
using api.Interfaces;
using System.Collections.Generic;

namespace api.Model
{
    public class Post
    {
        public int ID {get; set;}
        public string Text {get; set;}
        public DateTime Date {get; set;}
        public IPostDataHandler dataHandler {get; set;}

        public Post()
        {
            dataHandler = new PostDataHandler();
        }
    }
}