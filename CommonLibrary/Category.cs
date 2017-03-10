using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    /// <summary>
    /// 账户的类别，维护不同的设备大类
    /// </summary>
    public class AccountGroup
    {
        /// <summary>
        /// 账号大类的ID
        /// </summary>
        public int GroupId { get; set; } = 0;
        /// <summary>
        /// 账号大类描述
        /// </summary>
        public string Description { get; set; } = "";



        public static AccountGroup 特种设备类 { get;private set; } =
            new AccountGroup() { GroupId = 0, Description = "特种设备类" };
        public static AccountGroup 压力容器类 { get;private set; } =
            new AccountGroup() { GroupId = 1, Description = "力容器类" };
        public static AccountGroup 叉车类 { get; private set; } =
            new AccountGroup() { GroupId = 2, Description = "叉车类" };
        public static AccountGroup 特殊类 { get; private set; } =
            new AccountGroup() { GroupId = 10000, Description = "特殊类" };

        public static string[] GetAccountGroups()
        {
            return new string[]
            {
                特殊类.Description,
                叉车类.Description,
                特种设备类.Description,
                压力容器类.Description,
            };
        }

        public static string GetAccountDescription(int groupId)
        {
            return GetAccountGroups()[groupId];
        }
    }



    /// <summary>
    /// 设备小类，用来区分不同的设备类
    /// </summary>
    public class CategoryCode
    {
       
        //=======================================================================================


        //======================================================================================
        
        
        public static CategoryCode 起重设备 { get;private set; } =
            new CategoryCode(0, AccountGroup.特种设备类.GroupId, "起重设备台账", "起重设备台帐");
        public static CategoryCode 电梯 { get;private set; } =
            new CategoryCode(1, AccountGroup.特种设备类.GroupId, "电梯台账", "电梯台帐");
        public static CategoryCode 一般设备台账 { get;private set; } =
            new CategoryCode(2, AccountGroup.特种设备类.GroupId, "一般设备台账", "一般设备台账");


        //======================================================================================
        public static CategoryCode 压力容器 { get;private set; } =
            new CategoryCode(100, AccountGroup.压力容器类.GroupId, "压力容器台账", "下沙新厂压力容器台账");
        public static CategoryCode 管道 { get;private set; } =
            new CategoryCode(101, AccountGroup.压力容器类.GroupId, "管道台账", "压力管道台帐");
        public static CategoryCode 锅炉 { get;private set; } =
            new CategoryCode(102, AccountGroup.压力容器类.GroupId, "锅炉台账", "锅炉台账");
        /// <summary>
        /// 根据设备编号，获取设备小类
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        public static CategoryCode GetCategoryFromId(int codeId)
        {
            switch(codeId)
            {
                case 0:return 起重设备;
                case 1:return 电梯;
                case 2:return 一般设备台账;
                case 100:return 压力容器;
                case 101:return 管道;
                case 102:return 锅炉;
                default:return null;
            }
        }


        /// <summary>
        /// 实例化一个新的对象，初始化都是0的数据
        /// </summary>
        public CategoryCode()
        {

        }
        /// <summary>
        /// 根据实际的数据进行初始化对象
        /// </summary>
        /// <param name="codeId">台账类的ID代号</param>
        /// <param name="groupId">台账所属类别的代号</param>
        /// <param name="accountName">台账的名称，用于实际显示的名称</param>
        /// <param name="tableName">数据库中表的真实名称</param>
        public CategoryCode(int codeId, int groupId, string accountName, string tableName)
        {
            CodeId = codeId;
            GroupId = groupId;
            AccountName = accountName;
            TableName = tableName;
        }
        /// <summary>
        /// 台账类的ID代号
        /// </summary>
        public int CodeId { get; set; } = 0;
        /// <summary>
        /// 台账所属类别的代号
        /// </summary>
        public int GroupId { get; set; } = 0;
        /// <summary>
        /// 台账的名称，用于实际显示的名称
        /// </summary>
        public string AccountName { get; set; } = "";
        /// <summary>
        /// 数据库中表的真实名称
        /// </summary>
        public string TableName { get; set; } = "";
    }

}
