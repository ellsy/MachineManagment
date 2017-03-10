using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary;

namespace 软件系统客户端模版
{
    //===============================================================================
    //    所有设备类控件的接口
    //    提供了几个统一的方法名称方便调用
    //    时间：2017-03-09 19:19:37
    //===============================================================================


    /// <summary>
    /// 设备显示控件公开接口
    /// </summary>
    public interface IUserMachine
    {
        /// <summary>
        /// 设置设备对象，用于显示设备信息
        /// </summary>
        /// <param name="machine"></param>
        void SetMachineAccount(MachineBase machine);
        /// <summary>
        /// 获取更改后的设备对象
        /// </summary>
        /// <returns></returns>
        MachineBase GetMachineModify();
        /// <summary>
        /// 启动或禁用所有的输入控件
        /// </summary>
        /// <param name="enable"></param>
        void AllEnabled(bool enable);
        /// <summary>
        /// 检测所有的输入控件数据是否正确
        /// </summary>
        /// <returns></returns>
        bool IsDataInputAllRight();
        /// <summary>
        /// 释放设备控件
        /// </summary>
        void Dispose();
        /// <summary>
        /// 创建一个新的设备数据时需要执行的方法
        /// </summary>
        void CreateNewMachine();
        /// <summary>
        /// 还原所有的标签背景
        /// </summary>
        void RestoreAllBackcolor();
        /// <summary>
        /// 当前的设备信息
        /// </summary>
        MachineBase CurrentMachine { get; set; }
    }
}
