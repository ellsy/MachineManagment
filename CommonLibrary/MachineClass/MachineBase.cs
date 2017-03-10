using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BasicFramework;

namespace CommonLibrary
{
    //===========================================================================================
    //    时间：2017-03-07 19:41:25
    //    作用：设备类
    //    注意：只有设备类负责直接和SQL数据库交互
    //============================================================================================



    /// <summary>
    /// 用来获取设备状态的类
    /// </summary>
    public abstract class MachineStatus
    {
        public static string 在用 { get; set; } = "在用";
        public static string 闲置 { get; set; } = "闲置";
        public static string 停用 { get; set; } = "停用";
        public static string 已拆除 { get; set; } = "已拆除";
        public static string 无需检 { get; set; } = "无需检";
    }
    public abstract class MachineVerifyStatus
    {
        public static string 是 { get; set; } = "是";
        public static string 否 { get; set; } = "否";
        public static string 取证中 { get; set; } = "取证中";
    }

    public abstract class VerifyExistStatus
    {
        public static string 有 { get; set; } = "有";
        public static string 无 { get; set; } = "无";
        public static string 无需 { get; set; } = "无需";
    }



    /// <summary>
    /// 所有设备的基类，提供基础属性和共同方法
    /// </summary>
    public class MachineBase : ISqlDataType
    {
        //=========================================================================
        //静态资源
        /// <summary>
        /// 获取所有的设备资源
        /// </summary>
        public static string[] MachineStatuses
        {
            get
            {
                return new string[]
                {
                    MachineStatus.在用,
                    MachineStatus.停用,
                    MachineStatus.已拆除,
                    MachineStatus.无需检,
                    MachineStatus.闲置,
                };
            }
        }

        public static string[] MachineVerityExist
        {
            get
            {
                return new string[]
                {
                    VerifyExistStatus.有,
                    VerifyExistStatus.无,
                    VerifyExistStatus.无需,
                };
            }
        }

        /// <summary>
        /// 获取设备的检验状态
        /// </summary>
        public static string[] MachineVerityStatus
        {
            get
            {
                return new string[]
                {
                    MachineVerifyStatus.是,
                    MachineVerifyStatus.否,
                    MachineVerifyStatus.取证中
                };
            }
        }
        /// <summary>
        /// 获取所有分厂的数据列表
        /// </summary>
        public static string[] MachineFactories
        {
            get
            {
                return new string[]
                {
                    "热电分厂",            //1
                    "500工厂",            //2
                    "炼胶分厂",            //3
                    "储运部",              //4
                    "资材管理中心",         //5
                    "104工厂",            //6
                    "车胎分厂",            //7
                    "子午分厂",            //8
                    "斜交分厂",            //9
                    "机修分厂",            //10
                    "下沙综合办",           //11
                    "总经办",              //12
                    "测试中心",            //13
                    "内胎分厂",            //14
                };
            }
        }

        public static string DataTimeFormate { get; private set; } = "yyyy-MM-dd";

        public static string Split { get; private set; } = "'";
        public static string Letter { get; private set; } = ",";

        //==============================================================================
        //    基础属性
        //===============================================================================
        
        /// <summary>
        /// 设备的ID
        /// </summary>
        public int 序号 { get; set; } = -1;
        /// <summary>
        /// 设备状态
        /// </summary>
        public string 设备状态 { get; set; } = MachineStatus.在用;
        /// <summary>
        /// 是否需要年检的判断
        /// </summary>
        public bool 是否需要年检 { get; set; } = false;
        /// <summary>
        /// 用来标识设备的类别
        /// </summary>
        public int CodeId { get; protected set; } = 0;



        //=====================================================================================
        //    基础方法
        //==================================================================================
        
        protected string StringToSql(string str)
        {
            return $"'{str}',";
        }
        protected string StringToSqlEnd(string str)
        {
            return $"'{str}'";
        }
        protected string DateToSql(DateTime? date)
        {
            return date == null ? "NULL," : DateToSql(date.Value);
        }
        protected string DateToSql(DateTime date)
        {
            return $"'{ date.ToString(DataTimeFormate)}',";
        }
        protected string DateToSqlEnd(DateTime? date)
        {
            return date == null ? "NULL" : $"'{ date.Value.ToString(DataTimeFormate)}'";
        }

        /// <summary>
        /// 用来刷新本设备的数据的基础方法
        /// </summary>
        /// <param name="cmdStr">指令</param>
        protected void Refresh(string cmdStr)
        {
            using (SqlConnection conn = new SqlConnection(CommonLibrary.MachineSqlConn))
            {
                using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            LoadBySqlDataReader(sdr);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 刷新本设备的数据
        /// </summary>
        public virtual void Refresh()
        {

        }

        /// <summary>
        /// 加载数据库的信息
        /// </summary>
        /// <param name="sdr">数据库行数据</param>
        public virtual void LoadBySqlDataReader(SqlDataReader sdr)
        {
            序号 = Convert.ToInt32(sdr[nameof(序号)]);
        }
        /// <summary>
        /// 新增一台设备记录的方法
        /// </summary>
        /// <returns>返回成功与否</returns>
        public virtual bool AddMachine()
        {
            return false;
        }
        /// <summary>
        /// 更新一台设备记录的方法
        /// </summary>
        /// <returns>返回成功与否</returns>
        public virtual bool UpdateMachine()
        {
            return false;
        }
        /// <summary>
        /// 删除一台设备记录的方法
        /// </summary>
        /// <returns>返回成功与否</returns>
        public virtual bool DeleteMachine()
        {
            return false;
        }
        /// <summary>
        /// 指示该设备信息是否匹配搜索项
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns>返回成功与否</returns>
        public virtual bool IsMatchSearch(string pattern)
        {
            return false;
        }

        /// <summary>
        /// 获取剩余检验天数，默认为最大值
        /// </summary>
        /// <param name="ServerTime">服务器的实时时间</param>
        /// <returns>剩余检验天数，默认2147483647</returns>
        public virtual int GetSurplusVerifyDays(DateTime ServerTime)
        {
            return int.MaxValue;
        }

    }
}
