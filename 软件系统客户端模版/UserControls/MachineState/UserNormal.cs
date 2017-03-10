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
    public partial class UserNormal : UserControl , IUserMachine
    {
        public UserNormal()
        {
            InitializeComponent();
        }

        public MachineBase CurrentMachine { get; set; } = null;

        public void AllEnabled(bool enable)
        {
            textBox_设备名称.Enabled = enable;
            comboBox_设备状态.Enabled = enable;
            textBox_内部编号.Enabled = enable;
            comboBox_所属分厂.Enabled = enable;
            textBox_规格型号.Enabled = enable;
            textBox_设备安装地址.Enabled = enable;
            textBox_安装单位.Enabled = enable;
            textBox_设备制造单位.Enabled = enable;
            textBox_产品编号.Enabled = enable;
            textBox_始用时间.Enabled = enable;
            textBox_维修次数.Enabled = enable;
            textBox_维修经费.Enabled = enable;
            textBox_备注.Enabled = enable;
        }

        public void CreateNewMachine()
        {
            SetMachineAccount(new BillNormal());
        }

        public MachineBase GetMachineModify()
        {
            return new BillNormal()
            {
                序号 = Convert.ToInt32(textBox_序号.Text),
                设备名称 = textBox_设备名称.Text,
                设备状态 = comboBox_设备状态.SelectedItem.ToString(),
                内部编号 = textBox_内部编号.Text,
                所属分厂 = comboBox_所属分厂.SelectedItem.ToString(),
                规格型号 = textBox_规格型号.Text,
                设备安装地址 = textBox_设备安装地址.Text,
                安装单位 = textBox_安装单位.Text,
                设备制造单位 = textBox_设备制造单位.Text,
                产品编号 = textBox_产品编号.Text,
                始用时间 = textBox_始用时间.Text,
                维修次数 = Convert.ToInt32(textBox_维修次数.Text),
                维修经费 = Convert.ToDecimal(textBox_维修经费.Text),
            };
        }

        public bool IsDataInputAllRight()
        {
            try
            {
                int.Parse(textBox_维修次数.Text);
                decimal.Parse(textBox_维修经费.Text);
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
            label_产品编号.BackColor = BackColor;
            label_内部编号.BackColor = BackColor;
            label_备注.BackColor = BackColor;
            label_始用时间.BackColor = BackColor;
            label_安装单位.BackColor = BackColor;
            label_所属分厂.BackColor = BackColor;
            label_维修次数.BackColor = BackColor;
            label_维修经费.BackColor = BackColor;
            label_规格型号.BackColor = BackColor;
            label_设备制造单位.BackColor = BackColor;
            label_设备名称.BackColor = BackColor;
            label_设备安装地址.BackColor = BackColor;
            label_设备状态.BackColor = BackColor;
        }

        public void SetMachineAccount(MachineBase machine)
        {
            if(machine is BillNormal normal)
            {
                if (normal.序号 < 0)
                {
                    textBox_序号.Text = "新建";
                    textBox_维修次数.Text = "0";
                    textBox_维修经费.Text = "0";
                }
                else
                {
                    textBox_序号.Text = normal.序号.ToString();
                }
                textBox_设备名称.Text = normal.设备名称;
                comboBox_设备状态.SelectedItem = normal.设备状态;
                textBox_内部编号.Text = normal.内部编号;
                comboBox_所属分厂.SelectedItem = normal.所属分厂;
                textBox_规格型号.Text = normal.规格型号;
                textBox_设备安装地址.Text = normal.设备安装地址;
                textBox_安装单位.Text = normal.安装单位;
                textBox_设备制造单位.Text = normal.设备制造单位;
                textBox_产品编号.Text = normal.产品编号;
                textBox_始用时间.Text = normal.始用时间;

                textBox_维修次数.Text = normal.维修次数.ToString();
                textBox_维修经费.Text = normal.维修经费.ToString();
                textBox_备注.Text = normal.备注;

                //清除颜色
                RestoreAllBackcolor();

                if (normal.设备状态 == "停用" && normal.序号 > 0)
                {
                    label_设备状态.BackColor = Color.Tomato;//2
                }
                else
                {
                    label_设备状态.BackColor = BackColor;//2
                }
            }
        }
    }
}
