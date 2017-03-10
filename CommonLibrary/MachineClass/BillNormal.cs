using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BasicFramework;

namespace CommonLibrary
{
    //=============================================================================
    //    一般设备台账
    //=============================================================================
    /// <summary>
    /// 一般设备台账
    /// </summary>
    public class BillNormal : MachineBase
    {
        //===================================================================================
        //    静态资源
        //==================================================================================
        public static string SqlSelectedHead
        {
            get
            {
                return
                    "SELECT [序号],[设备名称],[设备状态],[内部编号]" +
                    ",[所属分厂],[规格型号],[设备安装地址],[安装单位],[设备制造单位]," +
                    "[产品编号],[始用时间],[维修次数],[维修经费],[备注] FROM DBO."+
                    CategoryCode.一般设备台账.TableName + " WHERE 设备状态 != '删除' ";//后面接其他条件
            }
        }


        //===================================================================================
        //    属性
        //===================================================================================

        public BillNormal()
        {
            CodeId = CategoryCode.一般设备台账.CodeId;
        }
        public string 设备名称 { get; set; } = "";
        public string 内部编号 { get; set; } = "";
        public string 所属分厂 { get; set; } = MachineFactories[0];
        public string 规格型号 { get; set; } = "";
        public string 设备安装地址 { get; set; } = "";
        public string 安装单位 { get; set; } = "";
        public string 设备制造单位 { get; set; } = "";
        public string 产品编号 { get; set; } = "";
        public string 始用时间 { get; set; } = "";
        public int 维修次数 { get; set; } = 0;
        public decimal 维修经费 { get; set; } = 0;
        public string 备注 { get; set; } = "";



        //==================================================================================
        //    重载的方法
        //==================================================================================
        /// <summary>
        /// 从数据库加载数据
        /// </summary>
        /// <param name="sdr"></param>
        public override void LoadBySqlDataReader(SqlDataReader sdr)
        {
            base.LoadBySqlDataReader(sdr);
            设备名称 = sdr[nameof(设备名称)].ToString();
            设备状态 = sdr[nameof(设备状态)].ToString();
            内部编号 = sdr[nameof(内部编号)].ToString();
            所属分厂 = sdr[nameof(所属分厂)].ToString();
            规格型号 = sdr[nameof(规格型号)].ToString();
            设备安装地址 = sdr[nameof(设备安装地址)].ToString();
            安装单位 = sdr[nameof(安装单位)].ToString();
            设备制造单位 = sdr[nameof(设备制造单位)].ToString();
            产品编号 = sdr[nameof(产品编号)].ToString();
            始用时间 = sdr[nameof(始用时间)].ToString();
            维修次数 = Convert.ToInt32(sdr[nameof(维修次数)]);
            维修经费 = Convert.ToDecimal(sdr[nameof(维修经费)]);
            备注 = sdr[nameof(备注)].ToString();

            //无需提醒检
            是否需要年检 = false;
        }
        /// <summary>
        /// 新增一台设备
        /// </summary>
        /// <returns></returns>
        public override bool AddMachine()
        {
            if (序号 > 0) return false;
            string cmdStr = $"INSERT INTO DBO.{CategoryCode.一般设备台账.TableName} (设备名称,设备状态,内部编号,所属分厂," +
                    "规格型号,设备安装地址,安装单位,设备制造单位,产品编号,始用时间,维修次数,维修经费,备注) VALUES('" +
                    设备名称 + "','" +
                    设备状态.ToString() + "','" +
                    内部编号 + "','" +
                    所属分厂 + "','" +
                    规格型号 + "','" +
                    设备安装地址 + "','" +
                    安装单位 + "','" +
                    设备制造单位 + "','" +
                    产品编号 + "','" +
                    始用时间 + "','" +
                    维修次数 + "','" +
                    维修经费 + "','" +
                    备注 + "')";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <returns></returns>
        public override bool UpdateMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"UPDATE DBO.{CategoryCode.一般设备台账.TableName} SET " +
                    "设备名称='" + 设备名称 + "'," +
                    "设备状态='" + 设备状态 + "'," +
                    "内部编号='" + 内部编号 + "'," +
                    "所属分厂='" + 所属分厂 + "'," +
                    "规格型号='" + 规格型号 + "'," +
                    "设备安装地址='" + 设备安装地址 + "'," +
                    "安装单位='" + 安装单位 + "'," +
                    "设备制造单位='" + 设备制造单位 + "'," +
                    "产品编号='" + 产品编号 + "'," +
                    "始用时间='" + 始用时间 + "'," +
                    "维修次数='" + 维修次数 + "'," +
                    "维修经费='" + 维修经费 + "'," +
                    "备注='" + 备注 + "' " +
                    "WHERE 序号=" + 序号 + "";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 删除设备信息
        /// </summary>
        /// <returns></returns>
        public override bool DeleteMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"UPDATE DBO.{CategoryCode.一般设备台账.TableName} SET 设备状态='删除' WHERE 序号={序号}";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 获取剩余检验天数
        /// </summary>
        /// <param name="ServerTime"></param>
        /// <returns></returns>
        public override int GetSurplusVerifyDays(DateTime ServerTime)
        {
            return base.GetSurplusVerifyDays(ServerTime);
        }
        /// <summary>
        /// 是否和检索条件匹配
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public override bool IsMatchSearch(string pattern)
        {
            if (备注.Contains(pattern) ||
                设备状态.Contains(pattern) ||
                内部编号.Contains(pattern) ||
                安装单位.Contains(pattern) ||
                所属分厂.Contains(pattern) ||
                设备安装地址.Contains(pattern) ||
                设备名称.Contains(pattern) ||
                规格型号.Contains(pattern) ||
                产品编号.Contains(pattern) ||
                设备制造单位.Contains(pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 刷新本设备
        /// </summary>
        public override void Refresh()
        {
            Refresh(SqlSelectedHead + "AND 序号=" + 序号);
        }
    }
}
