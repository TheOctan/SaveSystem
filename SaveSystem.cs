using SaveSystems.Serialization;
using SaveSystems.Serialization.Format;
using System.IO;
using UnityEngine;

namespace SaveSystems
{
	public class SaveSystem
	{
		private static ISerializationFileSystem serializationFileSystem = new BinarySerializationSystem(Application.persistentDataPath + "/Saves/");

		public static bool Save<T>(string saveName, T saveData)
		{
			return serializationFileSystem.SerializeObject(saveData, saveName);
		}
		public static T Load<T>(string path)
		{
			try
			{
				return serializationFileSystem.DeserializeObject<T>(path);
			}
			catch (InvalidCastException e)
			{
				Debug.LogError(e.Message);
				return default;
			}
			catch
			{
				Debug.LogError($"Failed to load file at {path}");
				return default;
			}
		}
		public static bool HasKey(string key)
		{
			var targetPath = $"{serializationFileSystem.DirectoryName}{key}.{serializationFileSystem.Extension}";
			return File.Exists(targetPath);
		}
		public static bool ResetSave(string key)
		{
			var file = new FileInfo(serializationFileSystem + key + serializationFileSystem.Extension);
			file.Delete();

			return true;
		}
		public static bool ResetAllSaves()
		{
			var directory = new DirectoryInfo(serializationFileSystem.DirectoryName);
			directory.Delete();
			Directory.CreateDirectory(serializationFileSystem.DirectoryName);

			return true;
		}
		public static void SetSerializationSystem(ISerializationFileSystem serializationFileSystem)
		{
			SaveSystem.serializationFileSystem = serializationFileSystem;
		}
		public static void SetSaveDirectory(string directory)
		{
			serializationFileSystem.DirectoryName = directory;
		}
	}
}
