using System.IO;

namespace Assets.Scripts.SaveSystem.Serialization
{
	public abstract class BaseSerializationFileSystem : ISerializationFileSystem, ISerializationSystem
	{
		public string DirectoryName { get; set; }
		public abstract string Extension { get; }
		public virtual string DefaultKey => "SaveFile";

		public BaseSerializationFileSystem(string directoryName)
		{
			DirectoryName = directoryName;
		}

		public virtual bool SerializeObject<T>(T obj)
		{
			return SerializeObject(obj, DefaultKey);
		}
		public virtual bool SerializeObject<T>(T obj, string key)
		{
			if (!Directory.Exists(DirectoryName))
			{
				Directory.CreateDirectory(DirectoryName);
			}

			using (FileStream stream = new FileStream(SavePath(key), FileMode.Create))
			{
				return SaveObjectImplementaion(stream, obj);
			}
		}
		public T DeserializeObject<T>()
		{
			return DeserializeObject<T>(DefaultKey);
		}
		public virtual T DeserializeObject<T>(string key)
		{
			if(!File.Exists(SavePath(key)))
			{
				return default;
			}

			using (FileStream stream = new FileStream(SavePath(key), FileMode.Open))
			{
				return LoadObjectImplementatio<T>(stream);
			}
		}

		private string SavePath(string key)
		{
			return DirectoryName + key + "." + Extension;
		}

		protected abstract bool SaveObjectImplementaion<T>(Stream stream, T obj);
		protected abstract T LoadObjectImplementatio<T>(Stream stream);
	}
}
