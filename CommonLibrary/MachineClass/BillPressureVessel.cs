using BasicFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    //==============================================================================
    //    压力容器
    //==============================================================================


    public class BillPressureVessel : MachineBase
    {
        //==================================================================================
        //    静态资源
        //==================================================================================
        public static string SqlSelectedHead
        {
            get
            {
                return
                    "SELECT [序号],[容器自编号],[使用登记证],[注册编号],[容器名称],[型号],[设计寿命]"+
                    ",[类别],[设计压力],[工作压力],[工作温度],[介质],[规格],[容积],[材质],[制造单位]"+
                    ",[制造年月],[出厂编号],[使用年月],[合格证],[质量证明书],[竣工图],[所在部门]"+
                    ",[具体位置],[上次检验日期],[上次检验报告编号],[等级],[下次年度检查日期],[下次检验日期]"+
                    ",[备注1],[注册或迁移日期],[停用日期],[备注2] FROM DBO."+
                    CategoryCode.压力容器.TableName + " WHERE 序号 > 0 ";//后面接其他条件
            }
        }

        public BillPressureVessel()
        {
            CodeId = CategoryCode.压力容器.CodeId;
        }

        public string 容器自编号 { get; set; } = "";
        public string 使用登记证 { get; set; } = "";
        public string 注册编号 { get; set; } = "";
        public string 容器名称 { get; set; } = "";
        public string 型号 { get; set; } = "";
        public string 设计寿命 { get; set; } = "";
        public string 类别 { get; set; } = "";
        public string 设计压力 { get; set; } = "";
        public string 工作压力 { get; set; } = "";
        public string 工作温度 { get; set; } = "";
        public string 介质 { get; set; } = "";
        public string 规格 { get; set; } = "";
        public string 容积 { get; set; } = "";
        public string 材质 { get; set; } = "";
        public string 制造单位 { get; set; } = "";
        public string 制造年月 { get; set; } = "";
        public string 出厂编号 { get; set; } = "";
        public string 使用年月 { get; set; } = "";
        public string 合格证 { get; set; } = VerifyExistStatus.有;
        public string 质量证明书 { get; set; } = VerifyExistStatus.有;
        public string 竣工图 { get; set; } = VerifyExistStatus.有;
        public string 所在部门 { get; set; } = "";
        public string 具体位置 { get; set; } = "";
        public DateTime? 上次检验日期 { get; set; } = null;
        public string 上次检验报告编号 { get; set; } = "";
        public string 等级 { get; set; } = "";
        public DateTime? 下次年度检查日期 { get; set; } = null;
        public DateTime? 下次检验日期 { get; set; } = null;
        public string 备注1 { get; set; } = "";
        public DateTime? 注册或迁移日期 { get; set; } = null;
        public DateTime? 停用日期 { get; set; } = null;
        public string 备注2 { get; set; } = "";


        //================================================================================
        //    重载了方法
        //================================================================================

        public override void LoadBySqlDataReader(SqlDataReader sdr)
        {
            base.LoadBySqlDataReader(sdr);
            容器自编号 = sdr[nameof(容器自编号)].ToString();
            使用登记证 = sdr[nameof(使用登记证)].ToString();
            注册编号 = sdr[nameof(注册编号)].ToString();
            容器名称 = sdr[nameof(容器名称)].ToString();
            型号 = sdr[nameof(型号)].ToString();
            设计寿命 = sdr[nameof(设计寿命)].ToString();
            类别 = sdr[nameof(类别)].ToString();
            设计压力 = sdr[nameof(设计压力)].ToString();
            工作压力 = sdr[nameof(工作压力)].ToString();
            工作温度 = sdr[nameof(工作温度)].ToString();
            介质 = sdr[nameof(介质)].ToString();
            规格 = sdr[nameof(规格)].ToString();
            容积 = sdr[nameof(容积)].ToString();
            材质 = sdr[nameof(材质)].ToString();
            制造单位 = sdr[nameof(制造单位)].ToString();
            制造年月 = sdr[nameof(制造年月)].ToString();
            出厂编号 = sdr[nameof(出厂编号)].ToString();
            使用年月 = sdr[nameof(使用年月)].ToString();
            合格证 = sdr[nameof(合格证)].ToString();
            质量证明书 = sdr[nameof(质量证明书)].ToString();
            竣工图 = sdr[nameof(竣工图)].ToString();
            所在部门 = sdr[nameof(所在部门)].ToString();
            具体位置 = sdr[nameof(具体位置)].ToString();
            上次检验日期 = sdr[nameof(上次检验日期)] as DateTime?;
            上次检验报告编号 = sdr[nameof(上次检验报告编号)].ToString();
            等级 = sdr[nameof(等级)].ToString();
            下次年度检查日期 = sdr[nameof(下次年度检查日期)] as DateTime?;
            下次检验日期 = sdr[nameof(下次检验日期)] as DateTime?;
            备注1 = sdr[nameof(备注1)].ToString();
            注册或迁移日期 = sdr[nameof(注册或迁移日期)] as DateTime?;
            停用日期 = sdr[nameof(停用日期)] as DateTime?;
            备注2 = sdr[nameof(备注2)].ToString();
        }

        public override bool AddMachine()
        {
            if (序号 > 0) return false;
            string cmdStr = $"INSERT INTO DBO.{CategoryCode.压力容器.TableName} ([容器自编号],[使用登记证],[注册编号],[容器名称],[型号],[设计寿命]" +
                    ",[类别],[设计压力],[工作压力],[工作温度],[介质],[规格],[容积],[材质],[制造单位]" +
                    ",[制造年月],[出厂编号],[使用年月],[合格证],[质量证明书],[竣工图],[所在部门]" +
                    ",[具体位置],[上次检验日期],[上次检验报告编号],[等级],[下次年度检查日期],[下次检验日期]" +
                    ",[备注1],[注册或迁移日期],[停用日期],[备注2]) VALUES(" +
                    StringToSql(容器自编号) +
                    StringToSql(使用登记证) +
                    StringToSql(注册编号) +
                    StringToSql(容器名称) +
                    StringToSql(型号) +
                    StringToSql(设计寿命) +
                    StringToSql(类别) +
                    StringToSql(设计压力) +
                    StringToSql(工作压力) +
                    StringToSql(工作温度) +
                    StringToSql(介质) +
                    StringToSql(规格) +
                    StringToSql(容积) +
                    StringToSql(材质) +
                    StringToSql(制造单位) +
                    StringToSql(制造年月) +
                    StringToSql(出厂编号) +
                    StringToSql(使用年月) +
                    StringToSql(合格证) +
                    StringToSql(质量证明书) +
                    StringToSql(竣工图) +
                    StringToSql(所在部门) +
                    StringToSql(具体位置) +
                    DateToSql(上次检验日期) +
                    StringToSql(上次检验报告编号) +
                    StringToSql(等级) +
                    DateToSql(下次年度检查日期) +
                    DateToSql(下次检验日期) +
                    StringToSql(备注1) +
                    DateToSql(注册或迁移日期) +
                    DateToSql(停用日期) +
                    StringToSqlEnd(备注2) + ")";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }
        public override bool UpdateMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"UPDATE DBO.{CategoryCode.压力容器.TableName} SET " +
                    "容器自编号=" + StringToSql(容器自编号) +
                    "使用登记证=" + StringToSql(使用登记证) +
                    "注册编号=" + StringToSql(注册编号) +
                    "容器名称=" + StringToSql(容器名称) +
                    "型号=" + StringToSql(型号) +
                    "设计寿命=" + StringToSql(设计寿命) +
                    "类别=" + StringToSql(类别) +
                    "设计压力=" + StringToSql(设计压力) +
                    "工作压力=" + StringToSql(工作压力) +
                    "工作温度=" + StringToSql(工作温度) +
                    "介质=" + StringToSql(介质) +
                    "规格=" + StringToSql(规格) +
                    "容积=" + StringToSql(容积) +
                    "材质=" + StringToSql(材质) +
                    "制造单位=" + StringToSql(制造单位) +
                    "制造年月=" + StringToSql(制造年月) +
                    "出厂编号=" + StringToSql(出厂编号) +
                    "使用年月=" + StringToSql(使用年月) +
                    "合格证=" + StringToSql(合格证) +
                    "质量证明书=" + StringToSql(质量证明书) +
                    "竣工图=" + StringToSql(竣工图) +
                    "所在部门=" + StringToSql(所在部门) +
                    "具体位置=" + StringToSql(具体位置) +
                    "上次检验日期=" + DateToSql(上次检验日期) +
                    "上次检验报告编号=" + StringToSql(上次检验报告编号) +
                    "等级=" + StringToSql(等级) +
                    "下次年度检查日期=" + DateToSql(下次年度检查日期) +
                    "下次检验日期=" + DateToSql(下次检验日期) +
                    "备注1=" + StringToSql(备注1) +
                    "注册或迁移日期=" + DateToSql(注册或迁移日期) +
                    "停用日期=" + DateToSql(停用日期) +
                    "备注2=" + StringToSqlEnd(备注2) +
                    "WHERE 序号=" + 序号 + "";
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }

        public override bool DeleteMachine()
        {
            if (序号 <= 0) return false;
            string cmdStr = $"DELETE DBO.{CategoryCode.压力容器.TableName} WHERE 序号=" + 序号;
            return SoftSqlOperate.ExecuteSql(CommonLibrary.MachineSqlConn, cmdStr) == 1;
        }

        public override int GetSurplusVerifyDays(DateTime ServerTime)
        {
            return base.GetSurplusVerifyDays(ServerTime);
        }
        public override bool IsMatchSearch(string pattern)
        {
            if (
                容器自编号.Contains(pattern) ||
                使用登记证.Contains(pattern) ||
                注册编号.Contains(pattern) ||
                容器名称.Contains(pattern) ||
                型号.Contains(pattern) ||
                类别.Contains(pattern) ||
                介质.Contains(pattern) ||
                规格.Contains(pattern) ||
                材质.Contains(pattern) ||
                制造单位.Contains(pattern) ||
                出厂编号.Contains(pattern) ||
                所在部门.Contains(pattern) ||
                具体位置.Contains(pattern) ||
                备注1.Contains(pattern)
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
