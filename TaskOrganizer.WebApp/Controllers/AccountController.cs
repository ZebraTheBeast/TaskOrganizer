using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOrganizer.BLL.Services.Inerfaces;
using TaskOrganizer.ViewModels;
using TaskOrganizer.ViewModels.Shared;

namespace TaskOrganizer.WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ActionName("LogIn")]
        public async Task<ResponseUserView> LogIn([FromBody]UserView userView)
        {
            var md5 = MD5.Create();
            var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(userView.Password));
            userView.Password = Convert.ToBase64String(hashPassword);
            var view = await _accountService.LogIn(userView);
            return view;
        }

    }
}