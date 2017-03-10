using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicFramework;

namespace CommonLibrary
{
    /// <summary>
    /// 一个扩展的用户账户示例，代替服务器和客户端的账户类即可
    /// </summary>
    public class UserAccountEx : UserAccount
    {
        /// <summary>
        /// 账户的分类
        /// </summary>
        public int GroupCode { get; set; } = 0;
    }
}
