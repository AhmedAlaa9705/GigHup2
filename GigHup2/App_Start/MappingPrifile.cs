using AutoMapper;
using GigHup2.Dtos;
using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHup2.App_Start
{
    public class MappingPrifile:Profile
    {
        public MappingPrifile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationsDto>();
        }
    }
}