using System.Runtime.Serialization.Formatters.Binary;

namespace OctanGames.SaveModule.Serialization.Format
{
	public class BinarySerializationSystem : FormatterSerializationSystem<BinaryFormatter>
	{
		public override string Extension => "bin";
		public BinarySerializationSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
