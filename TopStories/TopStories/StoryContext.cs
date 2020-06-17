using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopStories
{
       class APIConsumerContext : DbContext
    {
        public DbSet<StoryContext> Stories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=C:\\Users\\User\\Desktop\\top-stories.db");

    }
    class StoryContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string key { get; set; }
        public string section { get; set; }
        public string title { get; set; }
        public DateTime published_date { get; set; }
        public string byline { get; set; }

    }
   
        public class Rootobject
        {
            public string status { get; set; }
            public string copyright { get; set; }
            public string section { get; set; }
            public DateTime last_updated { get; set; }
            public int num_results { get; set; }
            public Result[] results { get; set; }
        }

        public class Result
        {
            public string section { get; set; }
            public string subsection { get; set; }
            public string title { get; set; }

            public string _abstact { get; set; }
            public string url { get; set; }
            public string uri { get; set; }
            public string byline { get; set; }
            public string item_type { get; set; }
            public DateTime updated_date { get; set; }
            public DateTime created_date { get; set; }
            public DateTime published_date { get; set; }
            public string material_type_facet { get; set; }
            public string kicker { get; set; }
            public string[] des_facet { get; set; }
            public string[] org_facet { get; set; }
            public string[] per_facet { get; set; }
            public string[] geo_facet { get; set; }
            public Multimedia[] multimedia { get; set; }
            public string short_url { get; set; }
        }

        public class Multimedia
        {
            public string url { get; set; }
            public string format { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string type { get; set; }
            public string subtype { get; set; }
            public string caption { get; set; }
            public string copyright { get; set; }
        }

    
}
