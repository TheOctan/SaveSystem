using System.Runtime.Serialization.Formatters.Soap;

namespace Assets.Scripts.SaveSystem.Serialization.Format
{
	public class SoapSerializationSystem : FormatterSerialisationSystem<SoapFormatter>
	{
		public override string Extension => "soap";
		public SoapSerializationSystem(string directoryName) : base(directoryName)
		{
		}
	}
}
