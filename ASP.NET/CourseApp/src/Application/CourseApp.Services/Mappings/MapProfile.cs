using AutoMapper;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Course, CourseDisplayResponse>();
        }
    }
}
