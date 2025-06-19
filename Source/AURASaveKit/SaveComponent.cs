using FlaxEngine;
using System;

namespace AFSM;

/// <summary>
/// Base class for save components.
/// </summary>
public class SaveComponent
{
    
    /// <summary>
    /// Saves the component data.
    /// </summary>
    public virtual void Save() { }

    /// <summary>
    /// Loads the component data.
    /// </summary>

    public virtual void Load() { }


}