using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon RetainerSell.
/// </summary>
public sealed unsafe class ClickRetainerSell : ClickBase<ClickRetainerSell, AddonRetainerSell>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickRetainerSell"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickRetainerSell(IntPtr addon = default)
        : base("RetainerSell", addon)
    {
    }

    public static implicit operator ClickRetainerSell(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickRetainerSell Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Click the confirm button.
    /// </summary>
    [ClickName("retainer_sale_confirm")]
    public void Confirm()
        => this.UnitBase->FireCallbackInt(0);

    /// <summary>
    /// Click the cancel button.
    /// </summary>
    [ClickName("retainer_sale_cancel")]
    public void Cancel()
        => this.ClickAddonButton(this.Addon->Cancel, 22);

    /// <summary>
    /// Click the compare prices button.
    /// </summary>
    [ClickName("retainer_sale_compare_prices")]
    public void ComparePrices()
        => this.ClickAddonButton(this.Addon->ComparePrices, 4);

    /// <summary>
    /// Click the commence button.
    /// </summary>
    /// <param name="quantity">Quantity to sell.</param>
    public void SetQuantity(int quantity)
        => this.Addon->Quantity->SetValue(quantity);

    /// <summary>
    /// Click the commence button.
    /// </summary>
    /// <param name="price">Price to sell at.</param>
    public void SetAskingPrice(int price)
        => this.Addon->AskingPrice->SetValue(price);
}