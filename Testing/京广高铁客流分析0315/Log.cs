using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PublicClassLib
{
    public class Log
    {
        private static String m_OutputDir = ".\\";

        /// <summary>
        /// 各类输出所用的目录，带最后的"\"，默认为当前目录下的Output目录
        /// </summary>
        public static String OutputDir
        {
            get
            {

                return m_OutputDir;
            }
        }
        /// <summary>
        /// 删除指定的文件夹
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>
        /// 0：正常删除；-1：文件夹不存在。
        /// </returns>
        public static int DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    try
                    {
                        if (File.Exists(d))
                            File.Delete(d); //直接删除其中的文件
                        else
                        {
                            int n = DeleteFolder(d);
                            if (n != 0) //递归删除子文件夹
                                return n;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                try
                {
                    Directory.Delete(dir); //删除已空文件夹
                }
                catch (Exception)
                {

                    return -1;
                }
            }
            else
                return -1;


            return 0;
        }

        public static void ClearFiles(String DirName)
        {
            try
            {
                if (Directory.Exists(DirName))
                {
                    String[] filenames = Directory.GetFiles(DirName);

                    for (int i = 0; i < filenames.Length; i++)
                        File.Delete(filenames[i]);
                }

            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 打开文件，不成功则返回null
        /// 如果未给出扩展名，则自动增加扩展名：csv
        /// 如果未给目录名，则默认为系统定义的输出目录，若未配置，则为当前目录下的Output
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static StreamWriter OpenFile(String FileName)
        {
            return OpenFile(FileName, Encoding.UTF32);
        }

        /// <summary>
        /// 打开文件，不成功则返回null
        /// 如果未给出扩展名，则自动增加扩展名：csv
        /// 如果未给目录名，则默认为系统定义的输出目录，若未配置，则为当前目录下的Output
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static StreamWriter OpenFile(String FileName, Encoding codeType)
        {

            //如果未指定输出目录，则默认输出到output目录中
            if (FileName.IndexOf("\\") == -1)
                FileName = OutputDir + FileName;

            //如果未写扩展名，则增加默认扩展名csv
            int nIndex = FileName.LastIndexOf(".");
            if (nIndex == -1 || FileName.IndexOf('\\', nIndex) >= 0)
                FileName += ".csv";

            StreamWriter sw = null;
            bool bRetry = false;
            do
            {
                bRetry = false;
                try
                {
                    sw = new StreamWriter(FileName, false, codeType);
                }
                catch (Exception e)
                {
                    if (MessageBox.Show("文件操作出错， 原因为：" + e.Message + "\n\n是否重试？", "文件操作错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry)
                        bRetry = true;
                    else
                    {
                        bRetry = false;
                        sw = null;
                    }
                }
            } while (bRetry);

            return sw;
        }

        public static StreamReader OpenReadOnlyFile(String FileName)
        {
            return OpenReadOnlyFile(FileName, Encoding.ASCII);
        }
        public static StreamReader OpenReadOnlyFile(String FileName, Encoding codeType)
        {
            StreamReader sr = null;
            bool bRetry = false;
            do
            {
                bRetry = false;
                try
                {
                    sr = new StreamReader(FileName, codeType);
                }
                catch (Exception e)
                {
                    if (MessageBox.Show("文件操作出错， 原因为：" + e.Message + "\n\n是否重试？", "文件操作错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry)
                        bRetry = true;
                    else
                    {
                        bRetry = false;
                        sr = null;
                    }
                }
            } while (bRetry);

            return sr;
        }

        //private static String GetDir(String FullPath)
        //{
        //    String strDir = "";

        //    int n = FullPath.LastIndexOf("\\");
        //    if(n > 0)
        //}

        public static bool ClearLog(String LogFileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(LogFileName, false);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        public static bool ClearLog()
        {
            return ClearLog("sys.log");
        }

        public static bool WriteLog(String Msg, String LogFileName)
        {
            try
            {
                StreamWriter sw = new StreamWriter(LogFileName, true);
                sw.WriteLine(Msg);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;

        }

        public static bool WriteLog(String Msg)
        {
            return WriteLog(Msg, "sys.log");
        }
    }
}