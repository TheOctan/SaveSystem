using UnityEngine;

namespace Assets.Scripts.SaveSystem.Serialization.Format
{
	public class JsonUnitySerializationSystem : TextSerializationSystem
	{
		public override string Extension => "json";

		public JsonUnitySerializationSystem(string directoryName) : base(directoryName)
		{
		}

		protected override string GetString<T>(T obj)
		{
			return JsonUtility.ToJson(obj);
		}

		protected override T GetObject<T>(string line)
		{
			return JsonUtility.FromJson<T>(line);
		}
	}
}
