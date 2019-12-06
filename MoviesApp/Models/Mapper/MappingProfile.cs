using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Login Mapping
            CreateMap<LoginRequestModel, Registration>().ReverseMap();


            //Register Mapping
            CreateMap<RegisterRequestModel, Registration>().ReverseMap();


            //Employee Mapping
            CreateMap<EmployeeRequestModel, Employee>().ReverseMap();


            //Update Employee Model
            CreateMap<Employee, EditEmpRequestModel>().ReverseMap();


            CreateMap<Employee,GetEmpDetailsResponseModelResult>().ReverseMap();
           
            CreateMap<EditEmpRequestModel, GetEmpDetailsResponseModelResult>().ReverseMap();


            






        }
    }
}
