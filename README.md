# Save System

<div align="left">
  <img src="Save.png" alt="SaveSystem" width="400">
</div>

## Serialization formats
* Json Newtonsoft
* Unity Json
* XML
* SOAP
* Bynary

## Documentation
| Function              	| Description  												|
|---------------------------|-----------------------------------------------------------|
| Save     		  			| Saves data by key											|
| Load			  			| Loads data by key											|
| HasKey 		  			| Сhecks for a saved file by key							|
| ResetSave       			| Removes the file by key									|
| ResetAllSaves   			| Removes all files											|
| SetSaveDirectory   		| Sets the target directory for saving						|
| SetSerializationSystem	| Sets the serialization object for serialization format	|
|																						|

## Code examples
### Read-Write data
```csharp
SaveSystem.Save("key", data);			// save data by key
var data = SaveSystem.Load<int>("key");	// load data

if(SaveSystem.HasKey("key"))			// check for a saved file by key
{
	// ...
}
```
### Reset saves
```csharp
SaveSystem.ResetSave("key");			// delete file by key
SaveSyste.ResetAllSaves();				// delete all saves
```

### Configurations
```csharp
SaveSystem.SetSaveDirectory("C:/Users"); 									// Set save path
SaveSystem.SetSerializationSystem(new XmlSerializationSystem("C:/Users"));	// Set new custom serialisation format
```

### Write custom serialization format
```csharp
public class CustomSerialyzationFormat : BaseSerializationFileSystem
{
	public override string Extension => "txt";	// file extension without dot

	public CustomSerialyzationFormat(string directoryName) : base(directoryName)
	{}

	protected override T LoadObjectImplementatio<T>(Stream stream)	// overrides for load object
	{
		// use for example StreamReader with stream for object loading
		// ...
		return someObject;	// returns object of type T
	}
	protected override bool SaveObjectImplementaion<T>(Stream stream, T obj)	// override for save object
	{
		// use for example StreamReader with stream for object saving
		// ...
		return true;	// return true for successful save
	}
}
```
