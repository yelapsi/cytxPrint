using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.BLL.serviceinterface;

namespace Maticsoft.Controller
{
    public class LoginController
    {
        private readonly ILoginService loginService = new LoginServiceImpl();
        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public int LoginRequest(string userName, string password)
        {
            try
            {
                return loginService.LoginRequest(userName, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
