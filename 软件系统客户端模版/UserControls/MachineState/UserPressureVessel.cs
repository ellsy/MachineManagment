using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;

namespace 软件系统客户端模版
{
    public partial class UserPressureVessel : UserControl , IUserMachine
    {
        public UserPressureVessel()
        {
            InitializeComponent();
        }

        public MachineBase CurrentMachine { get; set; } = null;

        public void AllEnabled(bool enable)
        {
            textBox_容器自编号.Enabled = enable;
            textBox_使用登记证.Enabled = enable;
            textBox_注册编号.Enabled = enable;
            textBox_容器名称.Enabled = enable;
            textBox_型号.Enabled = enable;
            textBox_设计寿命.Enabled = enable;
            textBox_类别.Enabled = enable;
            textBox_设计压力.Enabled = enable;
            textBox_工作压力.Enabled = enable;
            textBox_工作温度.Enabled = enable;
            textBox_介质.Enabled = enable;
            textBox_规格.Enabled = enable;
            textBox_容积.Enabled = enable;
            textBox_材质.Enabled = enable;
            textBox_制造单位.Enabled = enable;
            textBox_制造年月.Enabled = enable;
            textBox_出厂编号.Enabled = enable;
            textBox_使用年月.Enabled = enable;
            comboBox_合格证.Enabled = enable;
            comboBox_质量证明书.Enabled = enable;
            comboBox_竣工图.Enabled = enable;
            comboBox_所在部门.Enabled = enable;
            textBox_具体位置.Enabled = enable;
            textBox_上次检验日期.Enabled = enable;
            textBox_上次检验报告编号.Enabled = enable;
            textBox_等级.Enabled = enable;
            textBox_下次年度检查日期.Enabled = enable;
            textBox_下次检验日期.Enabled = enable;

        }

        public void CreateNewMachine()
        {
            throw new NotImplementedException();
        }

        public MachineBase GetMachineModify()
        {
            throw new NotImplementedException();
        }

        public bool IsDataInputAllRight()
        {
            throw new NotImplementedException();
        }

        public void RestoreAllBackcolor()
        {
            throw new NotImplementedException();
        }

        public void SetMachineAccount(MachineBase machine)
        {
            throw new NotImplementedException();
        }
    }
}
