using System;

using ClickLib.Attributes;
using ClickLib.Bases;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks;

/// <summary>
/// Addon Gathering.
/// </summary>
public sealed unsafe class ClickGathering : ClickBase<ClickGathering, AddonGathering>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickGathering"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickGathering(IntPtr addon = default)
        : base("Gathering", addon)
    {
    }

    public static implicit operator ClickGathering(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickGathering Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Toggle the quick gathering checkbox.
    /// </summary>
    public void SetQuickGathering(bool value)
        => this.FireCallback(130, value);

    /// <summary>
    /// Enable the quick gathering button.
    /// </summary>
    [ClickName("gathering_enable_quick_gathering")]
    public void EnableQuickGathering()
        => this.SetQuickGathering(true);

    /// <summary>
    /// Disable the quick gathering button.
    /// </summary>
    [ClickName("gathering_disable_quick_gathering")]
    public void DisableQuickGathering()
        => this.SetQuickGathering(false);

    /// <summary>
    /// Click a gathering box.
    /// </summary>
    /// <param name="index">Gather index.</param>
    public void Gather(int index)
        => this.FireCallback(index);

#pragma warning disable SA1134,SA1516,SA1600
    [ClickName("gathering_gather1")] public void Gather1() => this.Gather(0);
    [ClickName("gathering_gather2")] public void Gather2() => this.Gather(1);
    [ClickName("gathering_gather3")] public void Gather3() => this.Gather(2);
    [ClickName("gathering_gather4")] public void Gather4() => this.Gather(3);
    [ClickName("gathering_gather5")] public void Gather5() => this.Gather(4);
    [ClickName("gathering_gather6")] public void Gather6() => this.Gather(5);
    [ClickName("gathering_gather7")] public void Gather7() => this.Gather(6);
    [ClickName("gathering_gather8")] public void Gather8() => this.Gather(7);
#pragma warning restore SA1134,SA1516,SA1600

    /// <summary>
    /// Click the close button.
    /// </summary>
    [ClickName("gathering_close")]
    public void Close()
        => this.FireCallback(-1);
}
