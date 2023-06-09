﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.DataTransferObjects.Requests
{
    public class CreateNewCourseRequest
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public int? TotalHours { get; set; }
        public string ImageUrl { get; set; } = "https://loremflickr.com/cache/resized/65535_52730399535_9ebd065dbf_320_240_nofilter.jpg";
        public int? CategoryId { get; set; }
        public byte? Rating { get; set; }
    }
}
