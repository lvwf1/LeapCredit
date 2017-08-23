using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace SlarkInc.FileHelper
{
    /// <summary>
    /// 该类继承了ActionResult，通过重写ExecuteResult方法，进行文件的下载
    /// </summary>
    public class FileResult : ActionResult
    {
        private readonly string _filePath;//文件路径
        private readonly string _fileName;//文件名称
        public FileResult(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            string fileName = _fileName;
            HttpResponseBase response = context.HttpContext.Response;
            if (File.Exists(_filePath))
            {
                FileStream fs = null;
                byte[] fileBuffer = new byte[10240000];//每次读取10240000字节大小的数据,10240000字节(b)=9.765625兆字节(mb)
                try
                {
                    using (fs = File.OpenRead(_filePath))
                    {
                        long totalLength = fs.Length;
                        response.ContentType = "application/octet-stream";
                        response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
                        while (totalLength > 0 && response.IsClientConnected)//持续传输文件
                        {
                            int length = fs.Read(fileBuffer, 0, fileBuffer.Length);//每次读取10240000个字节长度的内容
                            fs.Flush();
                            response.OutputStream.Write(fileBuffer, 0, length);//写入到响应的输出流
                            response.Flush();//刷新响应
                            totalLength = totalLength - length;
                        }
                        response.Close();//文件传输完毕，关闭相应流
                    }
                }
                catch (Exception ex)
                {
                    response.Write(ex.Message);
                }
                finally
                {
                    if (fs != null)
                        fs.Close();//最后记得关闭文件流
                }
            }
        }
    }
}