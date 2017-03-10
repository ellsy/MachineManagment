using BasicFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    //================================================================================
    //    管道台账
    //================================================================================


    /// <summary>
    /// 管道台账系统
    /// </summary>
    public class BillPipe : MachineBase
    {
        //==================================================================================
        //    静态资源
        //==================================================================================
        public static string SqlSelectedHead
        {
            get
            {
                return
                    "SELECT [序号],[项目名称],[管道名称],[管道编号],[管道起止点],[设计单位],[安装单位]" +
                    ",[安装年月],[投用年月],[公称直径mm],[公称壁厚mm],[累计长度km],[压力Mpa],[温度]" +
                    ",[介质],[允许最高工作压力Mpa],[管道材质],[焊口数量],[管道级别],[安全等级]" +
                    ",[检验评定单位],[注册代码],[下次检验日期],[报告编号],[备注] FROM DBO." +
                    CategoryCode.管道.TableName + " WHERE 序号 > 0 ";//后面接其他条件
            }
        }

        //===================================================================================
        //    基础属性
        //===================================================================================

        public BillPipe()
        {
            CodeId = CategoryCode.管道.CodeId;
        }

        public string 项目名称 { get; set; } = "";
        public string 管道名称 { get; set; } = "";
        public string 管道编号 { get; set; } = "";
        public string 管道起止点 { get; set; } = "";
        public string 设计单位 { get; set; } = "";
        public string 安装单位 { get; set; } = "";
        public DateTime? 安装年月 { get; set; } = null;
        public DateTime? 投用年月 { get; set; } = null;
        public string 公称直径mm { get; set; } = "";
        public string 公称壁厚mm { get; set; } = "";
        public string 累计长度km { get; set; } = "";
        public string 压力Mpa { get; set; } = "";
        public string 温度 { get; set; } = "";
        public string 介质 { get; set; } = "";
        public string 允许最高工作压力Mpa { get; set; } = "";
        public string 管道材质 { get; set; } = "";
        public string 焊口数量 { get; set; } = "";
        public string 管道级别 { get; set; } = "";
        public string 安全等级 { get; set; } = "";
        public string 检验评定单位 { get; set; } = "";
        public string 注册代码 { get; set; } = "";
        public DateTime? 下次检验日期 { get; set; } = null;
        public string 报告编号 { get; set; } = "";
        public string 备注 { get; set; } = "";


        //================================================================================
        //    重载了方法
        //================================================================================
        /// <summary>
        /// 数据库加载数据
        /// </summary>
        /// <param name="sdr"></param>
        public override void LoadBySqlDataReader(SqlDataReader sdr)
        {
            base.LoadBySqlDataReader(sdr);
            项目名称 = sdr[nameof(项目名称)].ToString();
            管道名称 = sdr[nameof(管道名称)].ToString();
            管道编号 = sdr[nameof(管道编号)].ToString();
            管道起止点 = sdr[nameof(管道起止点)].ToString();
            设计单位 = sdr[nameof(设计单位)].ToString();
            安装单位 = sdr[nameof(安装单位)].ToString();
            安装年月 = sdr[nameof(安装年月)] as DateTime?;
            投用年月 = sdr[nameof(投用年月)] as DateTime?;
            公称直径mm = sdr[nameof(公称直径mm)].ToString();
            公称壁厚mm = sdr[nameof(公称壁厚mm)].ToString();
            累计长度km = sdr[nameof(累计长度km)].ToString();
            压力Mpa = sdr[nameof(压力Mpa)].ToString();
            温度 = sdr[nameof(温度)].ToString();
            介质 = sdr[nameof(介质)].ToString();
            允许最高工作压力Mpa = sdr[nameof(允许最高工作压力Mpa)].ToString();
            管道材质 = sdr[nameof(管道材质)].ToString();
            焊口数量 = sdr[nameof(焊口数量)].ToString();
            管道级别 = sdr[nameof(管道级别)].ToString();
            安全等级 = sdr[nameof(安全等级)].ToString();
            检验评定单位 = sdr[nameof(检验评定单位)].ToString();
            注册代码 = sdr[nameof(注册代码)].ToString();
            下次检验日期 = sdr[nameof(下次检验日期)] as DateTime?;
            报告编号 = sdr[nameof(报告编号)].ToString();
            备注 = sdr[nameof(备注)].ToString();
        }
        /// <summary>
        /// 新增一台设备
        /// </summary>
        /// <returns></returns>
        public override bool AddMachine()
        {
            if (序号 > 0) return false;
            string cmdStr = $"INSERT INTO DBO.{CategoryCode.管道.TableName} ([项目名称],[管道名称],[管道编号],[管道起止点],[设计单位],[安装单位]" +
                    ",[安装年月],[投用年月],[公称直径mm],[公称壁厚mm],[累计长度km],[压力Mpa],[温度]" +
                    ",[介质],[允许最高工作压力Mpa],[管道材质],[焊口数量],[管道级别],[安全等级]" +
                    ",[检验评定单位],[注册代码],[下次检验日期],[报告编号],[备注]) VALUES(" +
                    StringToSql(项目名称) +
                    StringToSql(管道名称) +
                    StringToSql(管道编号) +
                    StringToSql(管道起止点) +
                    StringToSql(设计单位) +
                    StringToSql(安装单位) +
                    DateToSql(安装年月) +
                    DateToSql(投用年月) +
                    StringToSql(公称直径mm) +
                    StringToSql(公称壁厚mm) +
                    StringToSql(累计长度km) +
                    StringToSql(压力Mpa) +
                    StringToSql(温度) +
                    StringToSql(介质) +
                    StringToSql(允许最高工作压力Mpa) +
                    StringToSql(管道材质) +
                    StringToSql(焊口数量) +
                    StringToSql(管道级别) +
                    StringToSql(安全等级) +
                    StringToSql(检验评定单位) +
                    StringToSql(注册代码) +
                    DateToSql(下次检验日期) +
                    StringToSql(报告编号) +
                    StringToSqlEnd(备注) + ")";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <returns></returns>
        public override bool UpdateMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"UPDATE DBO.{CategoryCode.管道.TableName} SET " +
                "项目名称=" + StringToSql(项目名称) +
                "管道名称=" + StringToSql(管道名称) +
                "管道编号=" + StringToSql(管道编号) +
                "管道起止点=" + StringToSql(管道起止点) +
                "设计单位=" + StringToSql(设计单位) +
                "安装单位=" + StringToSql(安装单位) +
                "安装年月=" + DateToSql(安装年月) +
                "投用年月=" + DateToSql(投用年月) +
                "公称直径mm=" + StringToSql(公称直径mm) +
                "公称壁厚mm=" + StringToSql(公称壁厚mm) +
                "累计长度km=" + StringToSql(累计长度km) +
                "压力Mpa=" + StringToSql(压力Mpa) +
                "温度=" + StringToSql(温度) +
                "介质=" + StringToSql(介质) +
                "允许最高工作压力Mpa=" + StringToSql(允许最高工作压力Mpa) +
                "管道材质=" + StringToSql(管道材质) +
                "焊口数量=" + StringToSql(焊口数量) +
                "管道级别=" + StringToSql(管道级别) +
                "安全等级=" + StringToSql(安全等级) +
                "检验评定单位=" + StringToSql(检验评定单位) +
                "注册代码=" + StringToSql(注册代码) +
                "下次检验日期=" + DateToSql(下次检验日期) +
                "报告编号=" + StringToSql(报告编号) +
                "备注=" + StringToSql(备注) +
                "WHERE 序号=" + 序号 + "";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 删除设备记录
        /// </summary>
        /// <returns></returns>
        public override bool DeleteMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"DELETE DBO.{CategoryCode.管道.TableName} WHERE 序号=" + 序号;
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        /// <summary>
        /// 获取剩余的检验天数
        /// </summary>
        /// <param name="ServerTime"></param>
        /// <returns></returns>
        public override int GetSurplusVerifyDays(DateTime ServerTime)
        {
            return base.GetSurplusVerifyDays(ServerTime);
        }
        /// <summary>
        /// 检测是否匹配
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public override bool IsMatchSearch(string pattern)
        {
            if (
                项目名称.Contains(pattern) ||
                管道名称.Contains(pattern) ||
                管道编号.Contains(pattern) ||
                管道起止点.Contains(pattern) ||
                设计单位.Contains(pattern) ||
                安装单位.Contains(pattern) ||
                介质.Contains(pattern) ||
                管道材质.Contains(pattern) ||
                注册代码.Contains(pattern) ||
                报告编号.Contains(pattern)
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
