using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands
{
    public interface IGetUserCommand : ICommand<int, UserDTO>
    {

    }
}
