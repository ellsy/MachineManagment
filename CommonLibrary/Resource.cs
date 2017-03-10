using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    /// <summary>
    /// 所有的数据资源中心
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// 字符串资源中心
        /// </summary>
        public class StringResouce
        {
            public static string SoftName { get; } = "设备管理系统";
            public static string SoftCopyRight { get; } = "装备中心胡少林";
        }
    }
}
