using System.Linq;
using System.Text;
using Content.Client.Stylesheets;
using Content.Shared._DV.CartridgeLoader.Cartridges;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._DV.CartridgeLoader.Cartridges;

[GenerateTypedNameReferences]
public sealed partial class NanoChatLookupUiFragment : BoxContainer
{
    public NanoChatLookupUiFragment()
    {
        IoCManager.InjectDependencies(this);
        RobustXamlLoader.Load(this);
    }


    public void UpdateState(NanoChatLookupUiState state)
    {
        UpdateContactList(state.Contacts);
    }

    public void UpdateContactList(List<NanoChatRecipient> contacts)
    {
        ContactsList.RemoveAllChildren();
        for (var idx = 0; idx < contacts.Count; idx++)
        {
            var contact = contacts[idx];
            var contactString = new StringBuilder(contact.Name);
            contactString.AppendFormat(": #{0:D4}", contact.Number);


            var nameLabel = new Label()
            {
                Text = contact.Name,
                HorizontalAlignment = HAlignment.Left,
                HorizontalExpand = true
            };
            var numberLabel = new Label()
            {
                Text = $"#{contact.Number:D4}",
                HorizontalAlignment = HAlignment.Right,
            };


            var panel = new PanelContainer()
            {
                HorizontalExpand = true,
            };

            panel.AddChild(nameLabel);
            panel.AddChild(numberLabel);

            string styleClass = idx % 2 == 0 ? "PanelBackgroundBaseDark" : "PanelBackgroundLight";
            panel.StyleClasses.Add(styleClass);

            ContactsList.AddChild(panel);
        }
    }
}
