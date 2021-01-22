namespace Assets.Scripts.SaveSystem.Serialization
{
	public interface ISerializationFileSystem : ISerializationSystem
	{
		string Extension { get; }
		string DirectoryName { get; set; }

		bool SerializeObject<T>(T obj, string key);
		T DeserializeObject<T>(string key);
	}
}
