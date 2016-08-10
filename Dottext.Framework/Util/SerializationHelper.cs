using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;

namespace Dottext.Framework.Util
{
	/// <summary>
	/// Summary description for SerializationHelper.
	/// </summary>
	public class SerializationHelper
	{
		public static ReaderWriterLock rwl = new ReaderWriterLock();

		private SerializationHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static object Load(Type type, string filename)
		{
			FileStream fs = null;
			try
			{
				// open the stream...
				fs = new FileStream(filename, FileMode.Open,FileAccess.Read);
				XmlSerializer serializer = new XmlSerializer(type);
				return serializer.Deserialize(fs);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if(fs != null)
					fs.Close();
			}
		}


		public static void Save(object obj, string filename)
		{
			FileStream fs = null;
			// serialize it...
			try
			{
				fs = new FileStream(filename, FileMode.Create);
				XmlSerializer serializer = new XmlSerializer(obj.GetType());
				serializer.Serialize(fs, obj);	
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				if(fs != null)
					fs.Close();
			}

		}

		//Add by duud
		public static void AppendAndSave(object obj, string filename)  
		{
			if(!File.Exists(filename))
			{
				XmlTextWriter writer=new XmlTextWriter(filename,System.Text.Encoding.UTF8);
				try
				{
					writer.WriteStartDocument(true);
					writer.WriteStartElement(obj.GetType().Name+"s");
					writer.WriteEndElement();
					writer.Flush();
				}
				finally
				{
					writer.Close();
				}
			
			}
			XmlDocument myxml=new XmlDocument();
			//FileStream fs=new FileStream(filename,FileMode.Open);

			
			//fs.Lock(0,fs.Length);
			XmlSerializer mySerializer = new XmlSerializer(obj.GetType());
			System.IO.MemoryStream mystream=new MemoryStream();
			mySerializer.Serialize(mystream,obj,null);
			mystream.Position=0;
			XmlTextReader reader=new XmlTextReader(mystream);
			XmlElement element=null;
			//rwl.AcquireWriterLock(1000);
			try
			{
				myxml.Load(filename);
				while(reader.Read())
				{
					if(reader.NodeType==XmlNodeType.Element)
					{
						if(reader.HasAttributes)
						{
							element=myxml.CreateElement(null,reader.LocalName,null);
						}
						else
						{
							XmlNode mynode=myxml.CreateNode(XmlNodeType.Element,reader.LocalName,null);
							mynode.InnerText=reader.ReadString();
							element.AppendChild(mynode);

						}
				 
					
					}
				}			
			
			
					
				XmlElement root = myxml.DocumentElement;
				root.InsertBefore(element,root.FirstChild);
				myxml.Save(filename);
				
				

			}
			finally
			{
				reader.Close();
				//rwl.ReleaseWriterLock();
			}
			
			
			
			
			
		}
	}
}
