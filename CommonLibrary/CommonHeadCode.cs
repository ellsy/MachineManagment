using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class CommonLibrary
    {
        #region 加密解密块
        public static string MD5Decrypt(string decrypt)
        {
            return BasicFramework.MD5Code.MD5Decrypt(decrypt, "asdfghjk");
        }
        public static string MD5Encrypt(string encrypt)
        {
            return BasicFramework.MD5Code.MD5Encrypt(encrypt, "asdfghjk");
        }


        #endregion



        #region 公用端口设计块

        public static string MachineSqlConn { get; } = "Data Source=10.1.63.37;Initial Catalog=SQL1006;User ID=sa;Password=" +
            MD5Decrypt("A4002672CE70AEAFFB27CB3D0431B10B");//10.1.63.37




        //======================================================================================
        //    此处的所有的网络端口应该重新指定，防止其他人的项目连接到你的程序上
        //    假设你们的多个项目服务器假设在一台电脑的情况，就绝对要替换下面的端口号

        /// <summary>
        /// 主网络端口，此处随机定义了一个数据
        /// </summary>
        public static int Port_Main_Net { get; } = 18567;
        /// <summary>
        /// 同步网络访问的端口，此处随机定义了一个数据
        /// </summary>
        public static int Port_Second_Net { get; } = 19546;
        /// <summary>
        /// 用于软件系统更新的端口，此处随机定义了一个数据
        /// </summary>
        public static int Port_Update_Net { get; } = 13141;
        /// <summary>
        /// 用于软件远程更新的端口，此处随机定义了一个数据
        /// </summary>
        public static int Port_Update_Remote { get; } = 23532;
        
        #endregion

        
    }


    
}
