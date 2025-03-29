using System;
using System.Runtime.InteropServices;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks;

[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe struct AddonPurifyResult
{
    [FieldOffset(0x00)]
    public AtkUnitBase AtkUnitBase;
}

/// <summary>
/// Addon PurifyResult.
/// </summary>
public sealed unsafe class ClickPurifyResult : ClickBase<ClickPurifyResult, AddonPurifyResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickPurifyResult"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickPurifyResult(IntPtr addon = default)
        : base("PurifyResult", addon)
    {
    }

    public static implicit operator ClickPurifyResult(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickPurifyResult Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Click the automatic button.
    /// </summary>
    [ClickName("purify_result_automatic")]
    public void RepairAll()
        => this.ClickAddonButton(this.Addon->AtkUnitBase.GetButtonNodeById(19), 1);

    /// <summary>
    /// Click the quit button.
    /// </summary>
    [ClickName("purify_result_close")]
    public void Quit()
        => this.FireCallback(-1);
}
