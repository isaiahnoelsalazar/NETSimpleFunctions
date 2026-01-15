# How to install?
### In Visual Studio
#### Step 1
- Go to "Tools > NuGet Package Manager > Manage NuGet Packages for Solution"
#### Step 2
- Go to "Browse" tab and search for "NETSimpleFunctions" and simply install the latest version

### In Visual Studio Package Manager Console
```
dotnet add package NETSimpleFunctions --version [latest release version]
```
> Note: Remove the brackets for version

# Available methods
- [Check](#check)
- [Cipher](#cipher)
- [Convert](#convert)
- [Memory](#memory)
- [PyCS](#pycs)
- [SimpleFileHandler](#simplefilehandler)
- [Sort](#sort)

## Check
### HasNumbers
- will check a String for a number
- returns a boolean value
```csharp
Check.HasNumbers("Sample text"); // returns false
Check.HasNumbers("Sample text 1"); // returns true
```
### HasSymbols
- will check a String for a symbol
- returns a boolean value
```csharp
Check.HasSymbols("Sample text"); // returns false
Check.HasSymbols("Sample text!"); // returns true
```
### HasSpaces
- will check a String for a space
- returns a boolean value
```csharp
Check.HasSpaces("Sample_text"); // returns false
Check.HasSpaces("Sample text"); // returns true
```
### IsAValidPhilippineMobileNumber
- will check a String if it is a valid Philippine mobile number
- returns a boolean value
```csharp
Check.IsAValidPhilippineMobileNumber("+15551234567"); // returns false
Check.IsAValidPhilippineMobileNumber("09171234567"); // returns true
```
### Email.AddValidDomainName
- adds a valid domain name to the list of valid domain names
```csharp
Check.Email.AddValidDomainName("gmail");
```
### Email.AddValidDomainExtension
- adds a valid domain extension to the list of valid domain extensions
```csharp
Check.Email.AddValidDomainExtension("com");
```
### Email.AddValidDomain
- adds a valid domain to the list of valid domains
```csharp
Check.Email.AddValidDomain("gmail.com");
```
### Email.ShouldUseFullDomain
- sets the checker to use full domains or not
```csharp
Check.Email.ShouldUseFullDomain();

// Or

Check.Email.ShouldUseFullDomain(true);

// Or

Check.Email.ShouldUseFullDomain(false);
```
### Email.IsValid
- checks a String if it is a valid email or not
- will return false if the email domain is not listed in the valid domains
```csharp
Check.Email.IsValid("test@gmail.com"); // returns true
Check.Email.IsValid("test@outlook.com"); // returns false
Check.Email.IsValid("test@asd.com"); // returns false
```
## Cipher
### TranspositionCipher
```csharp
Cipher.TranspositionCipher("Sample text");
```
## Convert
### Reverse
- will reverse a String
```csharp
Convert.Reverse("Sample text"); // returns "txet elpmaS"
```
### ToBase64
- will convert a String to its Base64 version
- returns a String
```csharp
Convert.ToBase64("Sample text"); // returns "U2FtcGxlIHRleHQ="
```
### FromBase64
- will convert a Base64 String to its normal version
- returns a String
```csharp
Convert.FromBase64("U2FtcGxlIHRleHQ="); // returns "Sample text"
```
### ToByteArray
- will convert a String to a byte array
- returns a byte array
```csharp
byte[] byteArray = Convert.ToByteArray("Sample text");
```
### FromByteArray
- will convert a byte array to a String
- returns a String
```csharp
byte[] byteArray = Convert.ToByteArray("Sample text");
string temp = Convert.FromByteArray(byteArray);
```
## Memory
### Initialization
```csharp
Memory<AnyClassType> memory = new Memory<AnyClassType>();

// Or

Memory<string> memory = new Memory<string>(); // something general like this
```
### Add
- adds an item to memory
```csharp
AnyClassType item = new AnyClassType();
memory.Add(item);

// Or

memory.Add("Sample text");
```
### Contains
- checks if memory contains an item
```csharp
bool contains = memory.Contains(new AnyClassType());
```
### Remove
- removes an item from memory
```csharp
memory.Remove(item); // assuming 'item' already exists in memory
```
### RemoveAt
- removes an item from memory at a specific index
```csharp
memory.RemoveAt(1);
```
### Get
- returns an item from memory at a specific index
```csharp
AnyClassType item = memory.Get(0);

// Or

string text = memory.Get(0);
```
### Count
- returns the number of items in memory
```csharp
int count = memory.Count();
```
### Clear
- clears all items in memory
```csharp
memory.Clear();
```
## PyCS
Run Python 3.12 scripts and commands from C#
### Initialization
```csharp
PyCS pycs = new PyCS();

// Or

PyCS pycs = new PyCS(true); // default value
PyCS pycs = new PyCS(false); // no console messages
```
### InstallPip
- download and install pip for PyCS
```csharp
pycs.InstallPip();
```
### Pip
- starts a pip install command
```csharp
pycs.Pip(new string[]
{
	"numpy"
});
```
### PipLocal
- starts a pip install command for already downloaded .whl files
```csharp
pycs.PipLocal(new string[]
{
	"numpy-2.2.6-cp312-cp312-win32.whl",
	"opencv_python-4.12.0.88-cp37-abi3-win32.whl"
});
```
### Run
- runs a given Python script in a string value
```csharp
pycs.Run("print('Hello')"); // prints "Hello" in the console
```
### RunFile
- runs a given Python script in a given file path
```csharp
pycs.RunFile("scripts/hello.py"); // prints "Hello" in the console
```
### GetOutput
- runs a given Python script in a string value and returns the console message in a string value
```csharp
string text = pycs.GetOutput("print('Hello')"); // returns "Hello"
```
### GetFileOutput
- runs a given Python script in a given file path and returns the console message in a string value
```csharp
string text = pycs.GetFileOutput("scripts/hello.py"); // returns "Hello"
```
## SimpleFileHandler
### Write
- writes text to a file
```csharp
SimpleFileHandler.Write("path/to/file.txt", "Sample text");
```
### Read
- reads text from a file
```csharp
string text = SimpleFileHandler.Read("path/to/file.txt");
```
### Append
- appends text to a file
```csharp
SimpleFileHandler.Append("path/to/file.txt", "Sample text 2");
```
### ProjectToLocation
- extract a file from the project to a given location
```csharp
SimpleFileHandler.ProjectToLocation(Assembly.GetExecutingAssembly(), "SampleClass.cs");

// Or

SimpleFileHandler.ProjectToLocation(Assembly.GetExecutingAssembly(), "SampleClass.cs", "path/to/destination");
```
## Sort
### BubbleSort
```csharp
Sort.BubbleSort(new int[]{ 10, 8, 52, 27, 63, 95, 6, 46 });
```