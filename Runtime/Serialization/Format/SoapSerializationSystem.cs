using System.Runtime.Serialization.Formatters.Soap;

namespace OctanGames.SaveModule.Serialization.Format
{
	public class SoapSerializationSystem : FormatterSerializationSystem<SoapFormatter>
	{
		public override string Extension => "soap";
		public SoapSerializationSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
