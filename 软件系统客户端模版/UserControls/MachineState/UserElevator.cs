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
    public partial class UserElevator : UserControl , IUserMachine
    {
        public UserElevator()
        {
            InitializeComponent();
        }

        public MachineBase CurrentMachine { get; set; } = null;

        public void AllEnabled(bool enable)
        {
            comboBox_是否已检.Enabled = enable;
            comboBox_设备状态.Enabled = enable;
            textBox_本次检验日期.Enabled = enable;
            textBox_下次检验日期.Enabled = enable;
            textBox_产品编号.Enabled = enable;
            textBox_内部编号.Enabled = enable;
            textBox_是否移交.Enabled = enable;
            textBox_移交日期.Enabled = enable;
            textBox_安全管理人员.Enabled = enable;
            comboBox_原.Enabled = enable;
            comboBox_检.Enabled = enable;
            comboBox_登.Enabled = enable;
            comboBox_所属分厂.Enabled = enable;
            textBox_安装地址.Enabled = enable;
            textBox_固定资产编号.Enabled = enable;
            textBox_维修次数.Enabled = enable;
            textBox_维修金额.Enabled = enable;
            textBox_设备名称.Enabled = enable;
            textBox_设备型号.Enabled = enable;
            textBox_设备制造单位.Enabled = enable;
            textBox_设备代码.Enabled = enable;
            textBox_出厂日期.Enabled = enable;
            textBox_始用日期.Enabled = enable;
        }

        public void CreateNewMachine()
        {
            SetMachineAccount(new BillElevator());
        }

        public MachineBase GetMachineModify()
        {
            return new BillElevator()
            {
                序号 = textBox_序号.Text == "新增设备" ? -1 : Convert.ToInt32(textBox_序号.Text),
                本次检验日期 = Convert.ToDateTime(textBox_本次检验日期.Text),
                下次检验日期 = Convert.ToDateTime(textBox_下次检验日期.Text),
                是否已检 = comboBox_是否已检.SelectedItem.ToString(),
                设备代码 = textBox_设备代码.Text,
                设备状态 = comboBox_设备状态.SelectedItem.ToString(),
                内部编号 = textBox_内部编号.Text,
                安全管理人员 = textBox_安全管理人员.Text,
                是否移交 = textBox_是否移交.Text,
                移交日期 = textBox_移交日期.Text,
                原 = comboBox_原.SelectedItem.ToString(),
                检 = comboBox_检.SelectedItem.ToString(),
                登 = comboBox_登.SelectedItem.ToString(),
                所属分厂 = comboBox_所属分厂.SelectedItem.ToString(),
                安装地址 = textBox_安装地址.Text,
                设备名称 = textBox_设备名称.Text,
                设备型号 = textBox_设备型号.Text,
                设备制造单位 = textBox_设备制造单位.Text,
                产品编号 = textBox_产品编号.Text,
                出厂日期 = Convert.ToDateTime(textBox_出厂日期.Text),
                始用时间 = Convert.ToDateTime(textBox_始用日期.Text),
                固定资产编号=textBox_固定资产编号.Text,
                维修次数=Convert.ToInt32(label_维修次数.Text),
                维修费用=Convert.ToInt32(textBox_维修金额.Text)
            };
        }

        public bool IsDataInputAllRight()
        {
            try
            {
                DateTime.Parse(textBox_本次检验日期.Text);
                DateTime.Parse(textBox_下次检验日期.Text);
                DateTime.Parse(textBox_出厂日期.Text);
                DateTime.Parse(textBox_始用日期.Text);
                int.Parse(textBox_维修次数.Text);
                decimal.Parse(textBox_维修金额.Text);
                if (textBox_内部编号.Text.Length > 5) throw new Exception("内部编号不能大于5");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RestoreAllBackcolor()
        {
            label_下次检验日期.BackColor = BackColor;
            label_产品编号.BackColor = BackColor;
            label_内部编号.BackColor = BackColor;
            label_出厂日期.BackColor = BackColor;
            label_原.BackColor = BackColor;
            label_固定资产编号.BackColor = BackColor;
            label_始用日期.BackColor = BackColor;
            label_安全管理人员.BackColor = BackColor;
            label_安装地址.BackColor = BackColor;
            label_所属分厂.BackColor = BackColor;
            label_是否已检.BackColor = BackColor;
            label_是否移交.BackColor = BackColor;
            label_本次检验日期.BackColor = BackColor;
            label_检.BackColor = BackColor;
            label_登.BackColor = BackColor;
            label_移交日期.BackColor = BackColor;
            label_维修次数.BackColor = BackColor;
            label_维修金额.BackColor = BackColor;
            label_设备代码.BackColor = BackColor;
            label_设备制造单位.BackColor = BackColor;
            label_设备名称.BackColor = BackColor;
            label_设备型号.BackColor = BackColor;
            label_设备状态.BackColor = BackColor;
        }

        public void SetMachineAccount(MachineBase machine)
        {
            if (machine is BillElevator elevator)
            {
                if (elevator.序号 < 0)
                {
                    textBox_序号.Text = "新增设备";
                }
                else
                {
                    textBox_序号.Text = elevator.序号.ToString();
                }
                comboBox_是否已检.SelectedItem = elevator.是否已检;
                comboBox_设备状态.SelectedItem = elevator.设备状态;
                textBox_本次检验日期.Text = elevator.本次检验日期.ToString(MachineBase.DataTimeFormate);
                textBox_下次检验日期.Text = elevator.下次检验日期.ToString(MachineBase.DataTimeFormate);
                textBox_产品编号.Text = elevator.产品编号;
                textBox_内部编号.Text = elevator.内部编号;
                textBox_是否移交.Text = elevator.是否移交;
                textBox_移交日期.Text = elevator.移交日期;
                textBox_安全管理人员.Text = elevator.安全管理人员;
                comboBox_原.SelectedItem = elevator.原;
                comboBox_检.SelectedItem = elevator.检;
                comboBox_登.SelectedItem = elevator.登;
                comboBox_所属分厂.SelectedItem = elevator.所属分厂;
                textBox_安装地址.Text = elevator.安装地址;
                textBox_固定资产编号.Text = elevator.固定资产编号;
                textBox_设备名称.Text = elevator.设备名称;
                textBox_设备型号.Text = elevator.设备型号;
                textBox_设备制造单位.Text = elevator.设备制造单位;
                textBox_设备代码.Text = elevator.设备代码;
                textBox_出厂日期.Text = elevator.出厂日期.ToString(MachineBase.DataTimeFormate);
                textBox_始用日期.Text = elevator.始用时间.ToString(MachineBase.DataTimeFormate);
                textBox_维修次数.Text = elevator.维修次数.ToString();
                textBox_维修金额.Text = elevator.维修费用.ToString();


                //颜色还原
                RestoreAllBackcolor();

                if (elevator.设备状态 == MachineStatus.停用 && elevator.序号 > 0)
                {
                    label_设备状态.BackColor = Color.Tomato;
                }
                else
                {
                    label_设备状态.BackColor = BackColor;
                }

                //全部禁用
                if (elevator.序号 > 0)
                {
                    AllEnabled(false);
                }
                else
                {
                    AllEnabled(true);
                }
            }
        }
    }
}
