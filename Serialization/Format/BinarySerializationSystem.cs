using System.Runtime.Serialization.Formatters.Binary;

namespace SaveSystems.Serialization.Format
{
	public class BinarySerializationSystem : FormatterSerialisationSystem<BinaryFormatter>
	{
		public override string Extension => "bin";
		public BinarySerializationSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
