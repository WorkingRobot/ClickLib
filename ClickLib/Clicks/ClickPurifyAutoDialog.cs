using System;

using ClickLib.Attributes;
using ClickLib.Bases;

namespace ClickLib.Clicks;

/// <summary>
/// Addon PurifyAutoDialog.
/// </summary>
public sealed unsafe class ClickPurifyAutoDialog : ClickBase<ClickPurifyAutoDialog>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickPurifyAutoDialog"/> class.
    /// </summary>
    /// <param name="addon">Addon pointer.</param>
    public ClickPurifyAutoDialog(IntPtr addon = default)
        : base("PurifyAutoDialog", addon)
    {
    }

    public static implicit operator ClickPurifyAutoDialog(IntPtr addon) => new(addon);

    /// <summary>
    /// Instantiate this click using the given addon.
    /// </summary>
    /// <param name="addon">Addon to reference.</param>
    /// <returns>A click instance.</returns>
    public static ClickPurifyAutoDialog Using(IntPtr addon) => new(addon);

    /// <summary>
    /// Click the quit button.
    /// </summary>
    [ClickName("purify_auto_close")]
    public void Quit()
        => this.FireCallback(-1);
}
