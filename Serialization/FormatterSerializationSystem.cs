using System.IO;
using System.Runtime.Serialization;

namespace SaveSystems.Serialization
{
	public abstract class FormatterSerialisationSystem<T> : BaseSerializationFileSystem where T : IFormatter, new()
	{
		public override abstract string Extension { get; }

		public FormatterSerialisationSystem(string directoryName) : base(directoryName)
		{
		}

		protected override T1 LoadObjectImplementatio<T1>(Stream stream)
		{
			var formatter = new T();
			T1 obj = (T1)formatter.Deserialize(stream);

			return obj;
		}

		protected override bool SaveObjectImplementaion<T1>(Stream stream, T1 obj)
		{
			var formatter = new T();
			formatter.Serialize(stream, obj);

			return true;
		}
	}
}
