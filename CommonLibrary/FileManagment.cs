using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CommonLibrary
{
    /// <summary>
    /// 用于文件上传下载管理的文件类
    /// </summary>
    public class HuFile
    {
        /// <summary>
        /// 文件的名称
        /// </summary>
        public string file_name { get; set; } = "";
        /// <summary>
        /// 文件的扩展名
        /// </summary>
        public string file_exc { get; set; } = "";
        /// <summary>
        /// 文件的实际大小
        /// </summary>
        public int size { get; set; } = 0;
        /// <summary>
        /// 文件的内容描述
        /// </summary>
        public string description { get; set; } = "";
        /// <summary>
        /// 文件的上传日期
        /// </summary>
        public string upload_data { get; set; } = "2016-09-01";
        /// <summary>
        /// 文件的上传人名称
        /// </summary>
        public string upload_name { get; set; } = "";
        /// <summary>
        /// 文件被下载的次数
        /// </summary>
        public int downloadCount { get; set; } = 0;

        /// <summary>
        /// 获取大小
        /// </summary>
        /// <returns></returns>
        public string getTextSize()
        {
            if (size <= 1000)
            {
                return size + " B";
            }
            else if (size < 1000 * 1000)
            {
                float data = (float)size / 1024;
                return data.ToString("F2") + " Kb";
            }
            else if (size < 1000 * 1000 * 1000)
            {
                float data = (float)size / 1024 / 1024;
                return data.ToString("F2") + " Mb";
            }
            else
            {
                float data = (float)size / 1024 / 1024 / 1024;
                return data.ToString("F2") + " Gb";
            }
        }
    }
    
    public class FileManagment
    {
        private List<HuFile> files = new List<HuFile>();
        private object lock_files = new object();
        /// <summary>
        /// 临时文件存储的路径
        /// </summary>
        public string FileSavePath { get; set; } = "D:\\files.txt";


        public int File_Count()
        {
            return files.Count;
        }
        public void AddNew(HuFile hf)
        {
            lock (lock_files)
            {
                HuFile old = GetHuFileFromFileName(hf.file_name);
                if (old != null) files.Remove(old);
                files.Add(hf);
                SaveLocalFile();
            }
        }

        public void DeleteOne(string filename)
        {
            lock (lock_files)
            {
                HuFile old = GetHuFileFromFileName(filename);
                if (old != null) files.Remove(old);
                SaveLocalFile();
            }
        }

        private bool IsFileExsist(string filename)
        {
            foreach (HuFile file in files)
            {
                if (file.file_name == filename) return true;
            }
            return false;
        }
        private HuFile GetHuFileFromFileName(string filename)
        {
            foreach (HuFile file in files)
            {
                if (file.file_name == filename) return file;
            }
            return null;
        }

        public string ToJsonString()
        {
            JArray array = JArray.FromObject(files);
            return array.ToString();
        }
        public void SaveLocalFile()
        {
            try
            {
                string str = ToJsonString();
                FileStream fs = File.Create(FileSavePath);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(str);
                sw.Dispose();
                fs.Dispose();
            }
            catch
            {
            }
        }
        public void ReadFromFile()
        {
            if (File.Exists(FileSavePath))
            {
                byte[] temp = File.ReadAllBytes(FileSavePath);
                string str = Encoding.Default.GetString(temp);
                LoadFromJsonString(str);
            }
        }

        private void LoadFromJsonString(string JsonStr)
        {
            JArray array = JArray.Parse(JsonStr);
            lock (lock_files)
            {
                files = array.ToObject<List<HuFile>>();
            }
        }
    }
}
