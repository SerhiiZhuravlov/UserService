using API.Models.User.Requests;
using API.Models.User.Responses;
using AutoMapper;
using Domain.Models;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
