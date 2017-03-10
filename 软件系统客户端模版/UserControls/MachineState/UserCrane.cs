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
    public partial class UserCrane : UserControl , IUserMachine
    {
        public UserCrane()
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
            textBox_资料移交.Enabled = enable;
            textBox_移交日期.Enabled = enable;
            textBox_安装单位.Enabled = enable;
            comboBox_原.Enabled = enable;
            comboBox_检.Enabled = enable;
            comboBox_登.Enabled = enable;
            comboBox_所属分厂.Enabled = enable;
            textBox_设备使用地点.Enabled = enable;
            textBox_备注.Enabled = enable;
            textBox_维修次数.Enabled = enable;
            textBox_维修金额.Enabled = enable;
            textBox_设备名称.Enabled = enable;
            textBox_设备型号.Enabled = enable;
            textBox_设备制造单位.Enabled = enable;
            textBox_注册代码.Enabled = enable;
            textBox_出厂日期.Enabled = enable;
            textBox_始用日期.Enabled = enable;
        }
        
        public void CreateNewMachine()
        {
            SetMachineAccount(new BillCrane());
        }

        public MachineBase GetMachineModify()
        {
            return new BillCrane()
            {
                序号 = textBox_序号.Text == "新增设备" ? -1 : Convert.ToInt32(textBox_序号.Text),
                本次检验日期 = Convert.ToDateTime(textBox_本次检验日期.Text),
                下次检验日期 = Convert.ToDateTime(textBox_下次检验日期.Text),
                是否已检 = comboBox_是否已检.SelectedItem.ToString(),
                资料移交 = textBox_资料移交.Text,
                移交日期 = textBox_移交日期.Text,
                注册代码 = textBox_注册代码.Text,
                设备状态 = comboBox_设备状态.SelectedItem.ToString(),
                内部编号 = textBox_内部编号.Text,
                原 = comboBox_原.SelectedItem.ToString(),
                检 = comboBox_检.SelectedItem.ToString(),
                登 = comboBox_登.SelectedItem.ToString(),
                所属分厂 = comboBox_所属分厂.SelectedItem.ToString(),
                设备使用地点 = textBox_设备使用地点.Text,
                安装单位 = textBox_安装单位.Text,
                设备名称 = textBox_设备名称.Text,
                设备型号 = textBox_设备型号.Text,
                设备制造单位 = label_设备制造单位.Text,
                产品编号 = textBox_产品编号.Text,
                出厂日期 = Convert.ToDateTime(textBox_出厂日期.Text),
                始用时间 = Convert.ToDateTime(textBox_始用日期.Text),
                备注 = textBox_备注.Text
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
            label_备注.BackColor = BackColor;
            label_始用日期.BackColor = BackColor;
            label_安装单位.BackColor = BackColor;
            label_所属分厂.BackColor = BackColor;
            label_是否已检.BackColor = BackColor;
            label_本次检验日期.BackColor = BackColor;
            label_检.BackColor = BackColor;
            label_注册代码.BackColor = BackColor;
            label_登.BackColor = BackColor;
            label_移交日期.BackColor = BackColor;
            label_维修次数.BackColor = BackColor;
            label_维修金额.BackColor = BackColor;
            label_设备使用地点.BackColor = BackColor;
            label_设备制造单位.BackColor = BackColor;
            label_设备名称.BackColor = BackColor;
            label_设备型号.BackColor = BackColor;
            label_设备状态.BackColor = BackColor;
            label_资料移交.BackColor = BackColor;
        }

        public void SetMachineAccount(MachineBase machine)
        {
            if (machine is BillCrane crane)
            {
                //赋值
                CurrentMachine = crane;

                //显示
                if (crane.序号 < 0)
                {
                    textBox_序号.Text = "新增设备";
                }
                else
                {
                    textBox_序号.Text = crane.序号.ToString();
                }

                comboBox_是否已检.SelectedItem = crane.是否已检;
                comboBox_设备状态.SelectedItem = crane.设备状态;
                textBox_本次检验日期.Text = crane.本次检验日期.ToString(MachineBase.DataTimeFormate);
                textBox_下次检验日期.Text = crane.下次检验日期.ToString(MachineBase.DataTimeFormate);
                textBox_产品编号.Text = crane.产品编号;
                textBox_内部编号.Text = crane.内部编号;
                textBox_资料移交.Text = crane.资料移交;
                textBox_移交日期.Text = crane.移交日期;
                textBox_安装单位.Text = crane.安装单位;
                comboBox_原.SelectedItem = crane.原;
                comboBox_检.SelectedItem = crane.检;
                comboBox_登.SelectedItem = crane.登;
                comboBox_所属分厂.SelectedItem = crane.所属分厂;
                textBox_设备使用地点.Text = crane.设备使用地点;
                textBox_备注.Text = crane.备注;
                textBox_设备名称.Text = crane.设备名称;
                textBox_设备型号.Text = crane.设备型号;
                textBox_设备制造单位.Text = crane.设备制造单位;
                textBox_注册代码.Text = crane.注册代码;
                textBox_出厂日期.Text = crane.出厂日期.ToString(MachineBase.DataTimeFormate);
                textBox_始用日期.Text = crane.始用时间.ToString(MachineBase.DataTimeFormate);
                textBox_维修次数.Text = crane.维修次数.ToString();
                textBox_维修金额.Text = crane.维修费用.ToString();


                //还原颜色
                RestoreAllBackcolor();

                if (crane.设备状态 == MachineStatus.停用 && crane.序号 > 0)
                {
                    label_设备状态.BackColor = Color.Tomato;
                }
                else
                {
                    label_设备状态.BackColor = BackColor;
                }

                //全部禁用
                if (crane.序号 > 0)
                {
                    AllEnabled(false);
                }
                else
                {
                    AllEnabled(true);
                }
            }
        }

        private void UserCrane_Load(object sender, EventArgs e)
        {
            comboBox_所属分厂.DataSource = MachineBase.MachineFactories;
            comboBox_原.DataSource = MachineBase.MachineVerityExist ;
            comboBox_是否已检.DataSource = MachineBase.MachineVerityStatus;
            comboBox_检.DataSource = MachineBase.MachineVerityExist;
            comboBox_登.DataSource = MachineBase.MachineVerityExist;
            comboBox_设备状态.DataSource = MachineBase.MachineStatuses;
        }
    }
}
