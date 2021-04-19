namespace SaveSystems.Serialization
{
	public interface ISerializationSystem
	{
		bool SerializeObject<T>(T obj);
		T DeserializeObject<T>();
	}
}
