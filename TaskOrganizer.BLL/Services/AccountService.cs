using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskOrganizer.BLL.Services.Inerfaces;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.Entities;
using TaskOrganizer.ViewModels;
using TaskOrganizer.ViewModels.Shared;

namespace TaskOrganizer.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseUserView> LogIn(UserView userView)
        {
            var user = await _userRepository.GetByName(userView.Username);
            var responseUserView = new ResponseUserView();

            if (user != null)
            {
                if (user.Password != userView.Password)
                {
                    responseUserView.Status = "Wrong password";
                    return responseUserView;
                }

                responseUserView.User = Mapper.Map<User, UserView>(user);
                responseUserView.Status = "Ok";
                return responseUserView;
            }
            user = new User();
            user.Username = userView.Username;
            user.Password = userView.Password;

            var newUser = await _userRepository.Add(user);
            responseUserView.User = Mapper.Map<User, UserView>(newUser);
            responseUserView.Status = "Ok";
            return responseUserView;
        }
    }
}
