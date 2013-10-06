using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public static class XMLUtil {
	
	// some helper functions
	private static string UTF8ByteArrayToString(byte[] chars) {
		return (new UTF8Encoding()).GetString(chars);
	}
	
	private static byte[] StringToUTF8ByteArray(string s) {
		return (new UTF8Encoding()).GetBytes(s);
	}
	
	public static string Serialize(object o) {
		XmlSerializer serializer = new XmlSerializer(o.GetType());
		XmlTextWriter writer = new XmlTextWriter(new MemoryStream(), Encoding.UTF8);
		serializer.Serialize(writer, o);
		return UTF8ByteArrayToString(((MemoryStream) writer.BaseStream).ToArray());
	}
	
	public static T Deserialize<T>(string s) {
		XmlSerializer serializer = new XmlSerializer(typeof(T));
		MemoryStream stream = new MemoryStream(StringToUTF8ByteArray(s));
		XmlTextReader reader = new XmlTextReader(stream);
		return (T) serializer.Deserialize(reader);
	}
	
	public static void SaveXML(string path, object o) {
		// overwrite the existing file with the same path
		StreamWriter file = new StreamWriter(path, false, Encoding.UTF8);
		file.Write(Serialize(o));
		file.Close();
	}
	
	public static T LoadXML<T>(string path) {
		StreamReader file = new StreamReader(path, Encoding.UTF8);
		string tmp = file.ReadToEnd();
		file.Close();
		return Deserialize<T>(tmp);
	}
}
