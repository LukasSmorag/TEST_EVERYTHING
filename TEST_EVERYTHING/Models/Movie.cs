using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_EVERYTHING.Models
{
    public class Movie
    {
        public Movie()
        {
               
        }

        public Movie(int id, string name, string description, string imageName)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public String ImagePath
        {
            get
            {
                return "~/Content/Images/" + ImageName +".jpg";
            }

        }
    }
}