using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon RetainerSellList.
/// </summary>
public sealed unsafe class ClickRetainerSellList : ClickBase<ClickRetainerSellList>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickRetainerSellList"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickRetainerSellList(IntPtr addon = default)
        : base("RetainerSellList", addon)
    {
    }

    /// <summary>
    /// Gets the number of sale listings.
    /// </summary>
    public int ListingCount => ((AtkUnitBase*)this.AddonAddress)->GetComponentListById(11)->ListLength;

    public static implicit operator ClickRetainerSellList(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickRetainerSellList Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Click a listing.
    /// </summary>
    /// <param name="index">Listing index.</param>
    public void Listing(int index)
        => this.FireCallback(0, index, 1);

    /// <summary>
    /// Put an item from the inventory up for sale.
    /// </summary>
    /// <param name="inventoryId">Inventory index.
    /// 6 => Equipment
    /// 9 => Crystals, slot id is up-to-down left-to-right
    /// 17 => Retainer crystals
    /// 48 - 51 => Inventory1 - Inventory4
    /// 52 - 56 => Retainer inventory 1-5
    /// 57 - 68 => Armory chest
    /// 69 - 70 => Chocobo saddlebag</param>
    /// <param name="slot">Inventory slot index.</param>
    public void SellItem(int inventoryId, int slot)
        => this.FireCallback(2, inventoryId, slot);

#pragma warning disable SA1134,SA1516,SA1600
    [ClickName("select_listing1")] public void Listing1() => this.Listing(0);
    [ClickName("select_listing2")] public void Listing2() => this.Listing(1);
    [ClickName("select_listing3")] public void Listing3() => this.Listing(2);
    [ClickName("select_listing4")] public void Listing4() => this.Listing(3);
    [ClickName("select_listing5")] public void Listing5() => this.Listing(4);
    [ClickName("select_listing6")] public void Listing6() => this.Listing(5);
    [ClickName("select_listing7")] public void Listing7() => this.Listing(6);
    [ClickName("select_listing8")] public void Listing8() => this.Listing(7);
    [ClickName("select_listing9")] public void Listing9() => this.Listing(8);
    [ClickName("select_listing10")] public void Listing10() => this.Listing(9);
    [ClickName("select_listing11")] public void Listing11() => this.Listing(10);
    [ClickName("select_listing12")] public void Listing12() => this.Listing(11);
    [ClickName("select_listing13")] public void Listing13() => this.Listing(12);
    [ClickName("select_listing14")] public void Listing14() => this.Listing(13);
    [ClickName("select_listing15")] public void Listing15() => this.Listing(14);
    [ClickName("select_listing16")] public void Listing16() => this.Listing(15);
    [ClickName("select_listing17")] public void Listing17() => this.Listing(16);
    [ClickName("select_listing18")] public void Listing18() => this.Listing(17);
    [ClickName("select_listing19")] public void Listing19() => this.Listing(18);
    [ClickName("select_listing20")] public void Listing20() => this.Listing(19);
#pragma warning restore SA1134,SA1516,SA1600
}
