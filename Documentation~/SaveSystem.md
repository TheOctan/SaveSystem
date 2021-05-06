# Save System Documentation

## Functions description
| Function              	| Description  						|
|---------------------------|-----------------------------------------------------------|
| Save     		    | Saves data by key						|
| Load			    | Loads data by key						|
| HasKey 		    | Сhecks for a saved file by key				|
| ResetSave       	    | Removes the file by key					|
| ResetAllSaves   	    | Removes all files						|
| SetSaveDirectory   	    | Sets the target directory for saving			|
| SetSerializationSystem    | Sets the serialization object for serialization format	|

---
## Code examples
### Read-Write data
```csharp
SaveSystem.Save("key", data);		// save data by key
var data = SaveSystem.Load<int>("key");	// load data

if(SaveSystem.HasKey("key"))		// check for a saved file by key
{
	// ...
}
```
### Reset saves
```csharp
SaveSystem.ResetSave("key");	// delete file by key
SaveSyste.ResetAllSaves();	// delete all saves
```

### Configurations
```csharp
// Set save path
SaveSystem.SetSaveDirectory("C:/Users");

// Set new custom serialization format
SaveSystem.SetSerializationSystem(new XmlSerializationSystem("C:/Users")); 
```

### Write custom serialization format
```csharp
public class CustomSerializationFormat : BaseSerializationFileSystem
{
	public override string Extension => "txt"; // file extension without dot

	public CustomSerializationFormat(string directoryName) : base(directoryName)
	{}

	// overrides for load object
	protected override T HandleLoadObject<T>(Stream stream)
	{
		// use for example StreamReader with stream for object loading
		// ...
		return someObject;	// returns object of type T
	}

	// override for save object
	protected override bool HandleSaveObject<T>(Stream stream, T obj)
	{
		// use for example StreamReader with stream for object saving
		// ...
		return true;	// return true for successful save
	}
}
```