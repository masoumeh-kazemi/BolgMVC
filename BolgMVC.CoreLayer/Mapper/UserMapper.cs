using System.Security.AccessControl;
using BolgMVC.CoreLayer.DTOs.Users;
using BolgMVC.DataLayer.Entities;

namespace BolgMVC.CoreLayer.Mapper;

public class UserMapper
{
    public static UserDto MapToDto(User user)
    {
        return new UserDto()
        {
            FullName = user.FullName,
            Password = user.Password,
            UserName = user.UserName,
        };
    }
}