using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.SaveSystem.Serialization.Format
{
	public class BinarySerializationSystem : FormatterSerialisationSystem<BinaryFormatter>
	{
		public override string Extension => "bin";
		public BinarySerializationSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
