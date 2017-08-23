using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Collections;
using System.Runtime;

namespace SlarkInc.HttpHelper
{
	public class XMLHelp
	{
		private XDocument _document;

		public XDocument Document
		{
			get { return _document; }
			set { _document = value; }
		}
		private string _fPath = "";

		public string FPath
		{
			get { return _fPath; }
			set { _fPath = value; }
		}

		/// <summary>
		/// 初始化数据文件，当数据文件不存在时则创建。
		/// </summary>
		public void Initialize()
		{
			if (!File.Exists(this._fPath))
			{
				this._document = new XDocument(
				new XElement("entity", string.Empty)
				);
				this._document.Save(this._fPath);
			}
			else
				this._document = XDocument.Load(this._fPath);
		}

		public void Initialize(string xmlData)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlData);

			this._document = XmlDocumentExtensions.ToXDocument(doc, LoadOptions.None);
		}
		/// <summary>
		/// 清空用户信息
		/// </summary>
		public void ClearGuest()
		{
			XElement root = this._document.Root;
			if (root.HasElements)
			{
				XElement entity = root.Element("entity");
				entity.RemoveAll();
			}
			else
				root.Add(new XElement("entity", string.Empty));
		}


		///LYJ 修改
		/// <summary>
		/// 提交并最终保存数据到文件。
		/// </summary>

		public void Commit()
		{
			try
			{
				this._document.Save(this._fPath);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		/// <summary>
		/// 更新
		/// </summary>
		public void UpdateQrState(string PId, string state)
		{
			XElement root = this._document.Root;
			XElement entity = root.Element("entity");

			IEnumerable<XElement> elements = entity.Elements().Where(p =>
			p.Attribute("PId").Value == PId);
			if (elements.Count() == 0)
				return;
			else
			{
				XElement guest = elements.First();
				guest.Attribute("FQdState").Value = state;
				guest.Attribute("FQdTime").Value = DateTime.Now.ToString();
				Commit();
			}
		}

		public IEnumerable<XElement> GetXElement()
		{
			XElement root = this._document.Root;
			IEnumerable<XElement> elements = root.Elements();
			return elements;
		}



		public DataTable GetEntityTable()
		{
			DataTable dtData = new DataTable();
			XElement root = this._document.Root;
			IEnumerable<XElement> elements = root.Elements();

			foreach (XElement item in elements)
			{
				dtData.Columns.Add(item.Name.LocalName);
			}
			DataRow dr = dtData.NewRow();
			int i = 0;
			foreach (XElement item in elements)
			{
				dr[i] = item.Value;
				i = i + 1;
			}
			dtData.Rows.Add(dr);
			return dtData;
		}

	}

	public static class XmlDocumentExtensions
	{
		public static XDocument ToXDocument(this XmlDocument document)
		{
			return document.ToXDocument(LoadOptions.None);
		}

		public static XDocument ToXDocument(this XmlDocument document, LoadOptions options)
		{
			using (XmlNodeReader reader = new XmlNodeReader(document))
			{
				return XDocument.Load(reader, options);
			}
		}
        public static string WritTxt(string html, string file)
        {
            //FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\" + file, FileMode.Append);
            FileStream fileStream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~\\App_Data") + "\\" + file, FileMode.Append);
            
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
            streamWriter.Write(html + "\r\n");
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
            return "ture";
        }
    }

   
}