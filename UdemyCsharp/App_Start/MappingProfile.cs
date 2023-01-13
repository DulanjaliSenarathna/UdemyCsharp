using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using UdemyCsharp.Dtos;
using UdemyCsharp.Models;

namespace UdemyCsharp.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}