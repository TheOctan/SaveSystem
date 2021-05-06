using Newtonsoft.Json;

namespace OctanGames.SaveModule.Serialization.Format
{
	public class JsonSerializationSystem : TextSerializationSystem
	{
		public JsonSerializationSystem(string directoryName) : base(directoryName)
		{
		}

		public override string Extension => "json";

		protected override T GetObject<T>(string line)
		{
			return JsonConvert.DeserializeObject<T>(line);
		}

		protected override string GetString<T>(T obj)
		{
			return JsonConvert.SerializeObject(obj);
		}
	}
}
