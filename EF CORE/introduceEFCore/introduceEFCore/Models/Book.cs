﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduceEFCore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }

        public List<Author> Authors{ get; set; }
        public List<Review> Reviews { get; set; }
    }
}
