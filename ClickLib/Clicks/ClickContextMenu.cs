using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon ContextMenu.
/// </summary>
public sealed unsafe class ClickContextMenu : ClickBase<ClickContextMenu, AddonContextMenu>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickContextMenu"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickContextMenu(IntPtr addon = default)
        : base("ContextMenu", addon)
    {
    }

    public static implicit operator ClickContextMenu(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickContextMenu Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Select the item at the given index.
    /// </summary>
    /// <param name="index">Index to select.</param>
    public void Item(int index)
        => this.FireCallback(0, index, 0u);

#pragma warning disable SA1134,SA1516,SA1600
    [ClickName("select_context1")] public void Item1() => this.Item(0);
    [ClickName("select_context2")] public void Item2() => this.Item(1);
    [ClickName("select_context3")] public void Item3() => this.Item(2);
    [ClickName("select_context4")] public void Item4() => this.Item(3);
    [ClickName("select_context5")] public void Item5() => this.Item(4);
    [ClickName("select_context6")] public void Item6() => this.Item(5);
    [ClickName("select_context7")] public void Item7() => this.Item(6);
    [ClickName("select_context8")] public void Item8() => this.Item(7);
#pragma warning restore SA1134,SA1516,SA1600
}
