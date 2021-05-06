using System.IO;
using System.Xml.Serialization;

namespace OctanGames.SaveModule.Serialization.Format
{
	public class XmlSerializationSystem : BaseSerializationFileSystem
	{
		public override string Extension => "xml";
		public XmlSerializationSystem(string directoryName) : base(directoryName)
		{
		}

		protected override T HandleLoadObject<T>(Stream stream)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			var obj = (T)serializer.Deserialize(stream);

			return obj;
		}

		protected override bool HandleSaveObject<T>(Stream stream, T obj)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(stream, obj);

			return true;
		}
	}
}
