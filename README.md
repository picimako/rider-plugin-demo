# Rider Demo

## What was done to setup this project?

Installed:
- [.NET Framework latest](https://dotnet.microsoft.com/en-us/download/dotnet-framework)
- [Amazon Corretto 11](https://docs.aws.amazon.com/corretto/latest/corretto-11-ug/downloads-list.html)
- [JetBrains Rider](https://www.jetbrains.com/rider/)
- [PsiViewer plugin](https://plugins.jetbrains.com/plugin/227-psiviewer) (for inspecting document AST)

Project setup according to the [**resharper-rider-plugin**](https://github.com/jetbrains/resharper-rider-plugin) template:
- Downloaded the latest **JetBrains.ReSharper.SamplePlugin.*.nupkg** from the **Releases** page.
- Executed the two commands in the GitHub readme.
- Updated the plugin version in:
  - plugin.xml
  - gradle.properties
  - buildPlugin.ps1
  - runVisualStudio.ps1
- Updated since/until-build versions in **plugin.xml** for 2022.1:
  ```xml
  <idea-version since-build="221" until-build="221.*" />
  ```
- Added some C# code.
- Ran the **Rider - Frontend (Windows)** run configuration
- Complied and ran the plugin in Rider, with the **Rider (Windows)** Run Configurations.

## Classes

The relevant classes in this solution are:
- `ReSharperPlugin.RiderDemo.ReplaceSelectionContextAction`:
defines a Context Action (Intention Action) with the rule of its availability and the menu item to display
- `ReSharperPlugin.RiderDemo.ReplaceSelectionBulbAction`:
defines a Bulb Action that is displayed in the context menu (Alt+Enter) when `ReplaceSelectionContextAction` is available
- `ReSharperPlugin.RiderDemo.StringEditorWindow`:
a custom `JetBrains.UI.Controls.Common.Window` implementation that contains a single TextBox whose text is saved upon closing
- `ReSharperPlugin.RiderDemo.StringEditorModel`
The model class for `StringEditorWindow` to store some data

## Resources
Short summaries of Rider/ReSharper plugin development + links to code of published plugins 
- [IntelliJ SDK - Rider Plugin Development](https://plugins.jetbrains.com/docs/intellij/rider.html)
- [IntelliJ SDK - The IntelliJ Platform / Rider](https://plugins.jetbrains.com/docs/intellij/intellij-platform.html#rider)

A bit more info about the history of Rider/ReSharper and architectural details:
- [The .NET Tools Blog - Writing plugins for ReSharper and Rider](https://blog.jetbrains.com/dotnet/2019/02/14/writing-plugins-resharper-rider/)
- [Codemag.com - Building a .NET IDE with JetBrains Rider](https://www.codemag.com/Article/1811091/Building-a-.NET-IDE-with-JetBrains-Rider)

Plugin template and ReSharper Platform SDK documentation
- [GitHub - resharper-rider-plugin - Plugin Template](https://github.com/jetbrains/resharper-rider-plugin)
- [ReSharper Platform SDK](https://www.jetbrains.com/help/resharper/sdk/welcome.html)
