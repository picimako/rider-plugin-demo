using JetBrains.Application.DataContext;
using JetBrains.Application.UI.Controls;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.DataContext;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.TextControl;
using JetBrains.Util;
using JetBrains.Application.UI.Components.UIApplication;
using JetBrains.UI.StdApplicationUI;
using JetBrains.Platform.VisualStudio.Backend.ProjectModel.PropertiesExtender;
using JetBrains.UI.Extensions;
using JetBrains.UI.SrcView.LayoutDesigner.Controls.Editors;

namespace ReSharperPlugin.RiderDemo;

// See ReplaceSelectionAction.cs

// A lot of great utilities to see how you can work with text control, carets, etc.
// https://github.com/StyleCop/StyleCop.ReSharper/blob/master/src/dotnet/StyleCop.StyleCop/Core/Utils.cs

// Preview .xaml dialogs
// https://blog.jetbrains.com/dotnet/2021/02/17/xaml-preview-tool-improvements-in-rider-2021-1-eap/

// Example XAML dialog class and usage for inspiration
// JetBrains.PsiFeatures.UIInteractive.Features.Intentions.Options.ChangeInspectionSeverityDialog
// JetBrains.PsiFeatures.Web.UIInteractive.Inspection.WebLinters.WpfLinterSeverityChangeWindowProvider
public class ReplaceSelectionBulbAction : IBulbAction
{
    public void Execute(ISolution solution, ITextControl textControl)
    {
        //Show a simple message box with predefined Yes and No buttons
        // var yesOrNo = MessageBox.ShowYesNo("Message box text.", "Success");

        // var textRangeOfElementAtCaret = RetrieveTextRangeOfElementAtCaret(solution, textControl);

        //Insert text into the document where the caret is placed
        // textControl.Document.InsertText(textControl.Caret.Offset(), yesOrNo ? "YES" : "NOPE");

        //Replace the text of the entire element under the caret
        // textControl.Document.ReplaceText(textRangeOfElementAtCaret, yesOrNo ? "YES" : "NOPE");

        //Delete the text of the entire element under the caret
        // textControl.Document.DeleteText(textRangeOfElementAtCaret);

        //Stores one or more selection ranges depending on the number of carets/selections in the document
        var selectionRanges = textControl.Selection.Ranges.GetValue();
        // //Start and end offsets of selection, separately
        // var startOffsetOfSelection = selectionRanges[0].Start.ToDocOffset();
        // var endOffsetOfSelection = selectionRanges[0].End.ToDocOffset();
        // //Selection range as TextRange
        var selectionRange = selectionRanges[0].ToDocRangeNormalized();
        // //Replace selected text determined by the retrieved selection range
        // textControl.Document.ReplaceText(selectionRange, yesOrNo ? "YES" : "NOPE");

        StringEditorModel model = new StringEditorModel
        {
            Title = "String Editor Window",
            InitialText = "Initial text",
            Value = ""
        };
        var stringEditorWindow = new StringEditorWindow(model);
        stringEditorWindow.Closed += (sender, args) =>
        {
            textControl.Document.ReplaceText(selectionRange, model.Value);
        };
        stringEditorWindow.Show();
    }

    //Retrieve the text range of the element where the caret is placed
    private TextRange RetrieveTextRangeOfElementAtCaret(ISolution solution, ITextControl textControl)
    {
        var file = textControl.Document.GetPsiSourceFile(solution).GetDominantPsiFile<CSharpLanguage>() as ICSharpFile;
        var elementAtCaret = file.FindTokenAt(new TreeOffset(textControl.Caret.Offset()));
        return elementAtCaret.GetDocumentRange().TextRange;
    }

    public string Text { get; }
}
