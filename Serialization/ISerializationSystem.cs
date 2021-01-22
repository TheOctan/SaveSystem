namespace Assets.Scripts.SaveSystem.Serialization
{
	public interface ISerializationSystem
	{
		bool SerializeObject<T>(T obj);
		T DeserializeObject<T>();
	}
}
