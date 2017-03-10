using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BasicFramework;

namespace CommonLibrary
{
    /// <summary>
    /// 起重设备类
    /// </summary>
    public class BillCrane : MachineBase
    {
        //===================================================================================
        //    静态资源
        //==================================================================================
        public static string SqlSelectedHead
        {
            get
            {
                return
                    "SELECT [序号],[本次检验日期],[下次检验日期],[是否已检],[资料移交]," +
                    "[移交日期],[注册代码],[设备状态],[内部编号],[原],[检],[登],[所属分厂]," +
                    "[设备使用地点],[安装单位],[设备名称],[规格型号],[设备制造单位]," +
                    "[产品编号],[出厂日期],[始用时间],[备注] FROM DBO." + 
                    CategoryCode.起重设备.TableName + " WHERE 设备状态 != '删除' ";//后面接其他条件
            }
        }

        public BillCrane()
        {
            CodeId = CategoryCode.起重设备.CodeId;
        }


        public DateTime 本次检验日期 { get; set; } = DateTime.Now;
        public DateTime 下次检验日期 { get; set; } = DateTime.Now;
        public string 是否已检 { get; set; } = MachineVerifyStatus.是;
        public string 资料移交 { get; set; } = "";
        public string 移交日期 { get; set; } = "";
        public string 注册代码 { get; set; } = "";
        public string 内部编号 { get; set; } = "";
        public string 原 { get; set; } = VerifyExistStatus.有;
        public string 检 { get; set; } = VerifyExistStatus.有;
        public string 登 { get; set; } = VerifyExistStatus.有;
        public string 所属分厂 { get; set; } = MachineFactories[0];
        public string 设备使用地点 { get; set; } = "";
        public string 安装单位 { get; set; } = "";
        public string 设备名称 { get; set; } = "";
        public string 设备型号 { get; set; } = "";
        public string 设备制造单位 { get; set; } = "";
        public string 产品编号 { get; set; } = "";
        public DateTime 出厂日期 { get; set; } = DateTime.Now;
        public DateTime 始用时间 { get; set; } = DateTime.Now;
        public string 备注 { get; set; } = "";

        //暂时的备用
        public int 维修次数 { get; set; } = 0;
        public decimal 维修费用 { get; set; } = 0;


        //=========================================================================
        //    重写方法
        //=========================================================================

        /// <summary>
        /// 从数据库加载数据
        /// </summary>
        /// <param name="sdr"></param>
        public override void LoadBySqlDataReader(SqlDataReader sdr)
        {
            base.LoadBySqlDataReader(sdr);
            本次检验日期 = Convert.ToDateTime(sdr[nameof(本次检验日期)]);
            下次检验日期 = Convert.ToDateTime(sdr[nameof(下次检验日期)]);
            是否已检 = sdr[nameof(是否已检)].ToString();
            注册代码 = sdr[nameof(注册代码)].ToString();
            设备状态 = sdr[nameof(设备状态)].ToString();
            内部编号 = sdr[nameof(内部编号)].ToString();
            安装单位 = sdr[nameof(安装单位)].ToString();
            资料移交 = sdr[nameof(资料移交)].ToString();
            移交日期 = sdr[nameof(移交日期)].ToString();
            原 = sdr[nameof(原)].ToString();
            检 = sdr[nameof(检)].ToString();
            登 = sdr[nameof(登)].ToString();
            所属分厂 = sdr[nameof(所属分厂)].ToString();
            设备使用地点 = sdr[nameof(设备使用地点)].ToString();
            设备名称 = sdr[nameof(设备名称)].ToString();
            设备型号 = sdr["规格型号"].ToString();
            设备制造单位 = sdr[nameof(设备制造单位)].ToString();
            产品编号 = sdr[nameof(产品编号)].ToString();
            出厂日期 = Convert.ToDateTime(sdr[nameof(出厂日期)]);
            始用时间 = Convert.ToDateTime(sdr[nameof(始用时间)]);
            备注 = sdr[nameof(备注)].ToString();

            //判断是否需要检验
            if (设备状态 == MachineStatus.在用)
            {
                是否需要年检 = true;
            }
        }

        /// <summary>
        /// 增加一台设备
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SqlException">数据库操作异常</exception>
        public override bool AddMachine()
        {
            if (序号 > 0) return false;
            string cmdStr = $"INSERT INTO DBO.{CategoryCode.起重设备.TableName} (本次检验日期,下次检验日期,是否已检," +
                    "注册代码,设备状态,内部编号,安装单位,资料移交,移交日期,原,检,登,所属分厂,设备使用地点," +
                    "设备名称,规格型号,设备制造单位,产品编号,出厂日期,始用时间,备注) VALUES('" +
                    本次检验日期.ToString(DataTimeFormate) + "','" +
                    下次检验日期.ToString(DataTimeFormate) + "','" +
                     是否已检 + "','" +
                     注册代码 + "','" +
                     设备状态 + "','" +
                     内部编号 + "','" +
                     安装单位 + "','" +
                     资料移交 + "','" +
                     移交日期 + "','" +
                     原 + "','" +
                     检 + "','" +
                     登 + "','" +
                     所属分厂 + "','" +
                     设备使用地点 + "','" +
                     设备名称 + "','" +
                     设备型号 + "','" +
                     设备制造单位 + "','" +
                     产品编号 + "','" +
                     出厂日期.ToString(DataTimeFormate) + "','" +
                     始用时间.ToString(DataTimeFormate) + "','" +
                     备注 + "')";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 删除一台设备的信息
        /// </summary>
        /// <returns></returns>
        public override bool DeleteMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"UPDATE DBO.{CategoryCode.起重设备.TableName} SET 设备状态='删除' WHERE 序号={序号}";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 更新一台设备的信息
        /// </summary>
        /// <returns></returns>
        public override bool UpdateMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"UPDATE DBO.{CategoryCode.起重设备.TableName} SET " +
               "本次检验日期='" + 本次检验日期.ToString(DataTimeFormate) + "'," +
               "下次检验日期='" + 下次检验日期.ToString(DataTimeFormate) + "'," +
               "是否已检='" + 是否已检 + "'," +
               "注册代码='" + 注册代码 + "'," +
               "设备状态='" + 设备状态 + "'," +
               "内部编号='" + 内部编号 + "'," +
               "安装单位='" + 安装单位 + "'," +
               "资料移交='" + 资料移交 + "'," +
               "移交日期='" + 移交日期 + "'," +
               "原='" + 原 + "'," +
               "检='" + 检 + "'," +
               "登='" + 登 + "'," +
               "所属分厂='" + 所属分厂 + "'," +
               "设备使用地点='" + 设备使用地点 + "'," +
               "设备名称='" + 设备名称 + "'," +
               "规格型号='" + 设备型号 + "'," +
               "设备制造单位='" + 设备制造单位 + "'," +
               "产品编号='" + 产品编号 + "'," +
               "出厂日期='" + 出厂日期.ToString(DataTimeFormate) + "'," +
               "始用时间='" + 始用时间.ToString(DataTimeFormate) + "'," +
               "备注='" + 备注 + "' " +
               "WHERE 序号=" + 序号 + "";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 获取剩余检验的天数
        /// </summary>
        /// <param name="ServerTime">当前时间，必须为服务器的时间</param>
        /// <returns></returns>
        public override int GetSurplusVerifyDays(DateTime ServerTime)
        {
            if (序号 <= 0) return int.MaxValue;
            if (!是否需要年检) return int.MaxValue;
            return (下次检验日期 - ServerTime.Date).Days;
        }
        /// <summary>
        /// 根据文本信息，检测本设备是否满足检索条件
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public override bool IsMatchSearch(string pattern)
        {
            if (注册代码.Contains(pattern) ||
                设备状态.Contains(pattern) ||
                内部编号.Contains(pattern) ||
                安装单位.Contains(pattern) ||
                所属分厂.Contains(pattern) ||
                设备使用地点.Contains(pattern) ||
                设备名称.Contains(pattern) ||
                设备型号.Contains(pattern) ||
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
