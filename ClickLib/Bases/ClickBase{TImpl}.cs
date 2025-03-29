using System;

using ClickLib.Exceptions;
using ClickLib.Structures;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Bases;

/// <summary>
/// Click base class.
/// </summary>
/// <typeparam name="TImpl">The implementing type.</typeparam>
public abstract unsafe class ClickBase<TImpl> : IClickable
    where TImpl : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClickBase{TImpl}"/> class.
    /// </summary>
    /// <param name="name">Addon name.</param>
    /// <param name="addon">Addon address.</param>
    public ClickBase(string name, IntPtr addon)
    {
        this.AddonName = name;

        if (addon == default)
            addon = this.GetAddonByName(this.AddonName);

        this.AddonAddress = addon;
        this.UnitBase = (AtkUnitBase*)addon;
    }

    /// <summary>
    /// Gets the associated addon name.
    /// </summary>
    protected string AddonName { get; init; }

    /// <summary>
    /// Gets a pointer to the addon.
    /// </summary>
    protected IntPtr AddonAddress { get; init; }

    /// <summary>
    /// Gets a pointer to the underlying AtkUnitBase.
    /// </summary>
    protected AtkUnitBase* UnitBase { get; }

    public static implicit operator TImpl(ClickBase<TImpl> cb) => (cb as TImpl)!;

    /// <summary>
    /// Fire an addon callback.
    /// </summary>
    /// <param name="values">AtkValue values.</param>
    /// <returns>Itself.</returns>
    protected TImpl FireCallback(params object[] values)
    {
        using var atkValues = new AtkValueArray(values);
        this.UnitBase->FireCallback((uint)atkValues.Length, atkValues);
        
        return this;
    }

    /// <summary>
    /// Fire an addon callback and update visibility.
    /// </summary>
    /// <param name="values">AtkValue values.</param>
    /// <returns>Itself.</returns>
    protected TImpl FireCallbackWithVisibility(params object[] values)
    {
        using var atkValues = new AtkValueArray(values);
        var fireCallback = (delegate* unmanaged[Stdcall]<AtkUnitBase*, int, AtkValue*, bool, void>)AtkUnitBase.MemberFunctionPointers.FireCallback;
        fireCallback(this.UnitBase, atkValues.Length, atkValues, true);

        return this;
    }

    /// <summary>
    /// Fire an addon callback.
    /// </summary>
    /// <param name="close">A parameter.</param>
    /// <returns>Itself.</returns>
    protected TImpl FireNullCallback(bool close)
    {
        this.UnitBase->FireCallback(0, null, close);

        return this;
    }

    /// <summary>
    /// Hide the addon.
    /// </summary>
    /// <returns>Itself.</returns>
    protected TImpl HideAddon()
    {
        this.UnitBase->Hide(false, false, 0);

        return this;
    }

    private IntPtr GetAddonByName(string name, int index = 1)
    {
        var atkStage = AtkStage.Instance();
        if (atkStage == null)
            throw new InvalidClickException("AtkStage is not available");

        var unitMgr = atkStage->RaptureAtkUnitManager;
        if (unitMgr == null)
            throw new InvalidClickException("UnitMgr is not available");

        var addon = unitMgr->GetAddonByName(name, index);
        if (addon == null)
            throw new InvalidClickException("Addon is not available");

        return (IntPtr)addon;
    }
}
