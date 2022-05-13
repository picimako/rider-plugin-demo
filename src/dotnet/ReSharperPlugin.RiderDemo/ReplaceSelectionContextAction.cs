using System.Collections.Generic;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Feature.Services.Intentions;
using JetBrains.ReSharper.Feature.Services.Resources;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using IUserDataHolder = JetBrains.Util.IUserDataHolder;

namespace ReSharperPlugin.RiderDemo;

// Context action and editor documentation
// https://www.jetbrains.com/help/resharper/sdk/QuickFixes.html
// https://www.jetbrains.com/help/resharper/sdk/TextControl.html

// Intention instantiation
// https://github.com/StyleCop/StyleCop.ReSharper/blob/master/src/dotnet/StyleCop.StyleCop/QuickFixes/Framework/ChangeStyleCopRule.cs

// Bulb item implementation for the intention action
// https://github.com/StyleCop/StyleCop.ReSharper/blob/master/src/dotnet/StyleCop.StyleCop/QuickFixes/Framework/ChangeStyleCopRuleAction.cs

// Name: action text in Settings
// Description: the description of the action on the right side in Settings
// Group: the group in the Settings tree into which the action is put
[ContextAction(
    Group = "RiderDemo",
    Name = "Replace text in selection with specified text",
    Description =
        "This context action shows a dialog in which one can define custom text, and after closing, the action" +
        " replaces the selected text in the editor with a specified string.")]
public class ReplaceSelectionContextAction : IContextAction
{
    private ICSharpContextActionDataProvider _provider;

    public ReplaceSelectionContextAction(ICSharpContextActionDataProvider provider)
    {
        _provider = provider;
    }

    public bool IsAvailable(IUserDataHolder cache)
    {
        // To always have it enabled, regardless of context
        // return true; 
        
        // Available when the caret is on the identifier of a namespace declaration
        // return _provider.SelectedElement is IIdentifier && _provider.SelectedElement.Parent is ICSharpNamespaceDeclaration;
        
        // Enabled if there is text selected in the current document
        return !_provider.DocumentSelection.IsEmpty; 
    }

    public IEnumerable<IntentionAction> CreateBulbItems()
    {
        return new List<IntentionAction>
        {
            new(new ReplaceSelectionBulbAction(),
                //The text that appears as the text of the context action item
                "Replace text in selection...",
                BulbThemedIcons.ContextAction.Id,
                IntentionsAnchors.ContextActionsAnchor),
        };
    }
}
