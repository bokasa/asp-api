using Application.DTO;
using Application.Interfaces;
using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands
{
    public interface IGetUsersCommand : ICommand<UserQuery, IEnumerable<UserDTO>>
    {

    }
}
