using BasicFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CommonLibrary
{

    //==============================================================================
    //    锅炉台账
    //==============================================================================

    /// <summary>
    /// 锅炉台账
    /// </summary>
    public class BillBoiler : MachineBase
    {
        //==================================================================================
        //    静态资源
        //==================================================================================
        public static string SqlSelectedHead
        {
            get
            {
                return
                    "SELECT [序号],[设备编号],[设备名称],[设备注册编号],[使用等级证编号],[发证日期]"+
                    ",[型号],[制造单位],[安装单位],[额定蒸发量],[额定蒸汽压力],[额定蒸汽温度],[燃烧方式]"+
                    ",[产品编号],[出厂日期],[投用日期],[累计运行时间],[内部检验报告编号]"+
                    ",[内部年检日期],[内部检验结论],[下次内部年检日期],[外部检验报告编号]"+
                    ",[外部检验日期],[外部检验结论],[下次外部检验日期] FROM DBO." +
                    CategoryCode.锅炉.TableName + " WHERE 序号 > 0 ";//后面接其他条件
            }
        }

        //===================================================================================
        //    基础属性
        //===================================================================================
        public BillBoiler()
        {
            CodeId = CategoryCode.锅炉.CodeId;
        }


        public string 设备编号 { get; set; } = "";
        public string 设备名称 { get; set; } = "";
        public string 设备注册编号 { get; set; } = "";
        public string 使用等级证编号 { get; set; } = "";
        public DateTime? 发证日期 { get; set; } = null;
        public string 型号 { get; set; } = "";
        public string 制造单位 { get; set; } = "";
        public string 安装单位 { get; set; } = "";
        public string 额定蒸发量 { get; set; } = "";
        public string 额定蒸汽压力 { get; set; } = "";
        public string 额定蒸汽温度 { get; set; } = "";
        public string 燃烧方式 { get; set; } = "";
        public string 产品编号 { get; set; } = "";
        public DateTime? 出厂日期 { get; set; } = null;
        public DateTime? 投用日期 { get; set; } = null;
        public string 累计运行时间 { get; set; } = "";
        public string 内部检验报告编号 { get; set; } = "";
        public DateTime? 内部年检日期 { get; set; } = null;
        public string 内部检验结论 { get; set; } = "";
        public DateTime? 下次内部年检日期 { get; set; } = null;
        public string 外部检验报告编号 { get; set; } = "";
        public DateTime? 外部检验日期 { get; set; } = null;
        public string 外部检验结论 { get; set; } = "";
        public DateTime? 下次外部检验日期 { get; set; } = null;


        //================================================================================
        //    重载了方法
        //================================================================================
        public override void LoadBySqlDataReader(SqlDataReader sdr)
        {
            base.LoadBySqlDataReader(sdr);
            设备编号 = sdr[nameof(设备编号)].ToString();
            设备名称 = sdr[nameof(设备名称)].ToString();
            设备注册编号 = sdr[nameof(设备注册编号)].ToString();
            使用等级证编号 = sdr[nameof(使用等级证编号)].ToString();
            发证日期 = sdr[nameof(发证日期)] as DateTime?;
            型号 = sdr[nameof(型号)].ToString();
            制造单位 = sdr[nameof(制造单位)].ToString();
            安装单位 = sdr[nameof(安装单位)].ToString();
            额定蒸发量 = sdr[nameof(额定蒸发量)].ToString();
            额定蒸汽压力 = sdr[nameof(额定蒸汽压力)].ToString();
            额定蒸汽温度 = sdr[nameof(额定蒸汽温度)].ToString();
            燃烧方式 = sdr[nameof(燃烧方式)].ToString();
            产品编号 = sdr[nameof(产品编号)].ToString();
            出厂日期 = sdr[nameof(出厂日期)] as DateTime?;
            投用日期 = sdr[nameof(投用日期)] as DateTime?;
            累计运行时间 = sdr[nameof(累计运行时间)].ToString();
            内部检验报告编号 = sdr[nameof(内部检验报告编号)].ToString();
            内部年检日期 = sdr[nameof(内部年检日期)] as DateTime?;
            内部检验结论 = sdr[nameof(内部检验结论)].ToString();
            下次内部年检日期 = sdr[nameof(下次内部年检日期)] as DateTime?;
            外部检验报告编号 = sdr[nameof(外部检验报告编号)].ToString();
            外部检验日期 = sdr[nameof(外部检验日期)] as DateTime?;
            外部检验结论 = sdr[nameof(外部检验结论)].ToString();
            下次外部检验日期 = sdr[nameof(下次外部检验日期)] as DateTime?;
        }
        /// <summary>
        /// 新增一台设备记录
        /// </summary>
        /// <returns></returns>
        public override bool AddMachine()
        {
            if (序号 > 0) return false;
            string cmdStr = $"INSERT INTO DBO.{CategoryCode.锅炉.TableName} ([设备编号],[设备名称],[设备注册编号],[使用等级证编号],[发证日期]" +
                    ",[型号],[制造单位],[安装单位],[额定蒸发量],[额定蒸汽压力],[额定蒸汽温度],[燃烧方式]" +
                    ",[产品编号],[出厂日期],[投用日期],[累计运行时间],[内部检验报告编号]" +
                    ",[内部年检日期],[内部检验结论],[下次内部年检日期],[外部检验报告编号]" +
                    ",[外部检验日期],[外部检验结论],[下次外部检验日期]) VALUES(" +
                    StringToSql(设备编号) +
                    StringToSql(设备名称) +
                    StringToSql(设备注册编号) +
                    StringToSql(使用等级证编号) +
                    DateToSql(发证日期) +
                    StringToSql(型号) +
                    StringToSql(制造单位) +
                    StringToSql(安装单位) +
                    StringToSql(额定蒸发量) +
                    StringToSql(额定蒸汽压力) +
                    StringToSql(额定蒸汽温度) +
                    StringToSql(燃烧方式) +
                    StringToSql(产品编号) +
                    DateToSql(投用日期) +
                    StringToSql(累计运行时间) +
                    StringToSql(内部检验报告编号) +
                    DateToSql(内部年检日期) +
                    StringToSql(内部检验结论) +
                    DateToSql(下次内部年检日期) +
                    StringToSql(外部检验报告编号) +
                    DateToSql(外部检验日期) +
                    StringToSql(外部检验结论) +
                    DateToSqlEnd(下次外部检验日期) + ")";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 更新设备资料
        /// </summary>
        /// <returns></returns>
        public override bool UpdateMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr=$"UPDATE DBO.{CategoryCode.锅炉.TableName} SET "+
                "设备编号=" + StringToSql(设备编号) +
                "设备名称=" + StringToSql(设备名称) +
                "设备注册编号=" + StringToSql(设备注册编号) +
                "使用等级证编号=" + StringToSql(使用等级证编号) +
                "发证日期=" + DateToSql(发证日期) +
                "型号=" + StringToSql(型号) +
                "制造单位=" + StringToSql(制造单位) +
                "安装单位=" + StringToSql(安装单位) +
                "额定蒸发量=" + StringToSql(额定蒸发量) +
                "额定蒸汽压力=" + StringToSql(额定蒸汽压力) +
                "额定蒸汽温度=" + StringToSql(额定蒸汽温度) +
                "燃烧方式=" + StringToSql(燃烧方式) +
                "产品编号=" + StringToSql(产品编号) +
                "投用日期=" + DateToSql(投用日期) +
                "累计运行时间=" + StringToSql(累计运行时间) +
                "内部检验报告编号=" + StringToSql(内部检验报告编号) +
                "内部年检日期=" + DateToSql(内部年检日期) +
                "内部检验结论=" + StringToSql(内部检验结论) +
                "下次内部年检日期=" + DateToSql(下次内部年检日期) +
                "外部检验报告编号=" + StringToSql(外部检验报告编号) +
                "外部检验日期=" + DateToSql(外部检验日期) +
                "外部检验结论=" + StringToSql(外部检验结论) +
                "下次外部检验日期=" + DateToSqlEnd(下次外部检验日期) +
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
            string cmdStr = $"DELETE DBO.{CategoryCode.锅炉.TableName} WHERE 序号=" + 序号;
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
        /// 检测是否匹配搜索条件
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public override bool IsMatchSearch(string pattern)
        {
            if (
                设备编号.Contains(pattern) ||
                设备名称.Contains(pattern) ||
                设备注册编号.Contains(pattern) ||
                使用等级证编号.Contains(pattern) ||
                型号.Contains(pattern) ||
                制造单位.Contains(pattern) ||
                安装单位.Contains(pattern) ||
                产品编号.Contains(pattern) ||
                内部检验报告编号.Contains(pattern) ||
                外部检验报告编号.Contains(pattern)
                )
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
