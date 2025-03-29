using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon PurifyItemSelector.
/// </summary>
public sealed unsafe class ClickPurifyItemSelector : ClickBase<ClickPurifyItemSelector>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickPurifyItemSelector"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickPurifyItemSelector(IntPtr addon = default)
        : base("PurifyItemSelector", addon)
    {
    }

    /// <summary>
    /// Gets the number of purifiable items.
    /// </summary>
    public int ListingCount => ((AtkUnitBase*)this.AddonAddress)->GetComponentListById(6)->ListLength;

    public static implicit operator ClickPurifyItemSelector(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickPurifyItemSelector Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Purify an item.
    /// </summary>
    /// <param name="index">List index.</param>
    public void Purify(int index)
        => this.FireCallback(12, index);

#pragma warning disable SA1134,SA1516,SA1600
    [ClickName("purify_item1")] public void Purify1() => this.Purify(0);
    [ClickName("purify_item2")] public void Purify2() => this.Purify(1);
    [ClickName("purify_item3")] public void Purify3() => this.Purify(2);
    [ClickName("purify_item4")] public void Purify4() => this.Purify(3);
    [ClickName("purify_item5")] public void Purify5() => this.Purify(4);
    [ClickName("purify_item6")] public void Purify6() => this.Purify(5);
    [ClickName("purify_item7")] public void Purify7() => this.Purify(6);
    [ClickName("purify_item8")] public void Purify8() => this.Purify(7);
    [ClickName("purify_item9")] public void Purify9() => this.Purify(8);
    [ClickName("purify_item10")] public void Purify10() => this.Purify(9);
    [ClickName("purify_item11")] public void Purify11() => this.Purify(10);
    [ClickName("purify_item12")] public void Purify12() => this.Purify(11);
    [ClickName("purify_item13")] public void Purify13() => this.Purify(12);
    [ClickName("purify_item14")] public void Purify14() => this.Purify(13);
    [ClickName("purify_item15")] public void Purify15() => this.Purify(14);
    [ClickName("purify_item16")] public void Purify16() => this.Purify(15);
    [ClickName("purify_item17")] public void Purify17() => this.Purify(16);
    [ClickName("purify_item18")] public void Purify18() => this.Purify(17);
    [ClickName("purify_item19")] public void Purify19() => this.Purify(18);
    [ClickName("purify_item20")] public void Purify20() => this.Purify(19);
#pragma warning restore SA1134,SA1516,SA1600
}
