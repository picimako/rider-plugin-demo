using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JetBrains.Annotations;
using JetBrains.UI.Extensions;
using TextBox = JetBrains.UI.Controls.Common.TextBox;
using Window = JetBrains.UI.Controls.Common.Window;

namespace ReSharperPlugin.RiderDemo;

// A custom window implementation with a single TextBox that saves its text to the provided 'model' object.
// Based on JetBrains.Platform.VisualStudio.Backend.ProjectModel.PropertiesExtender.StringEditorWindow
public class StringEditorWindow : Window
{
    public StringEditorWindow(StringEditorModel model)
    {
        StringEditorWindow stringEditorWindow = this;
        this.Title = model.Title;
        this.Height = 350.0;
        this.Width = 525.0;
        this.MinHeight = 350.0;
        this.MinWidth = 500.0;
        this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        DockPanel dockPanel = new DockPanel();
        dockPanel.LastChildFill = true;
        this.Content = (object) dockPanel;
        
        TextBox textBox = new TextBox();
        textBox.Margin = new Thickness(6.0);
        textBox.TextWrapping = TextWrapping.Wrap;
        textBox.Text = model.InitialText;
        textBox.TextChanged += (sender, args) =>
        {
            model.Value = textBox.Text;
            stringEditorWindow.DialogResult = new bool?(true);
        };
        dockPanel.AddChild(textBox);
        FocusManager.SetFocusedElement((DependencyObject) this, (IInputElement) textBox);
    }
}
