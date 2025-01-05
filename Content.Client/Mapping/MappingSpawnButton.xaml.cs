﻿using System.Linq;
using System.Numerics;
using Robust.Client.AutoGenerated;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Mapping;

[GenerateTypedNameReferences]
public sealed partial class MappingSpawnButton : Control
{
    public MappingPrototype? Prototype;

    public MappingSpawnButton()
    {
        RobustXamlLoader.Load(this);
    }

    public void Gallery()
    {
        Button.ToolTip = Label.Text;
        Button.TooltipDelay = 0;
        Label.Visible = false;
        Button.AddStyleClass("ButtonSquare");
        SetWidth = 48;
        SetHeight = 48;
    }

    public void SetTextures(List<Texture> textures)
    {
        Button.RemoveStyleClass("OpenBoth");
        Button.AddStyleClass("OpenLeft");
        CollapseButton.RemoveStyleClass("OpenRight");
        CollapseButton.AddStyleClass("ButtonSquare");
        Texture.Visible = true;
        Texture.Textures.AddRange(textures);
        if (textures.FirstOrDefault() is { } texture)
            Texture.TextureScale = new Vector2(Texture.SetSize.X / texture.Height, Texture.SetSize.X / texture.Height);
        Texture.InvalidateMeasure();
    }
}
