# RenamePipes Plugin

A simple C# plugin for Autodesk Civil 3D that batch-renames all pipes in a selected pipe network using the format:  
**`[StartStructureName]_[EndStructureName]`**

## What Does It Do?

- **Select any pipe in your Civil 3D drawing**
- The plugin finds the parent pipe network
- **All pipes in that network will be renamed to reflect their upstream and downstream structure names**
- For example, if a pipe connects `MH1` to `MH2`, its name will be set to `MH1_MH2`
- This ensures naming consistency and greatly speeds up QA and design review

## Usage

1. **Build the Plugin**  
   - Open the `...csproj` in Visual Studio and build to generate the DLL

2. **Load in Civil 3D**  
   - In Civil 3D, use the `NETLOAD` command to load the compiled DLL

3. **Run the Command**  (should be corrected later)
   - Type `RENAMEPIPES` in the command line  
   - Select any pipe or manhole in the desired pipe network
   - All pipes in that network will be renamed to `[upstream structure name]_[downstream structure name]`

## Requirements

- Autodesk Civil 3D 2024/2025  
- .NET Framework 4.8  
- Civil 3D admin rights to load DLLs

## Example

| Pipe      | Start Structure | End Structure | New Name      |
|-----------|-----------------|--------------|---------------|
| Pipe1     | MH-101          | MH-102       | MH-101_MH-102 |
| Pipe2     | MH-102          | MH-103       | MH-102_MH-103 |


---

*Open to suggestions and improvements! For issues or new features, open a GitHub issue or PR.*

