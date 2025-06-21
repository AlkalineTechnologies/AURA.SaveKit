using FlaxEngine;
using System;

namespace AURASaveKit;

/// <summary>
/// Base class for save components.
/// </summary>
public class SaveComponent {

    /// <summary>
    /// Saves the component data.
    /// </summary>
    public virtual void Save() {
        if (!SaveManager.RegisteredComponents.Contains(this)) {
            SaveManager.RegisteredComponents.Add(this);
        }
    }

    /// <summary>
    /// Loads the component data.
    /// </summary>

    public virtual void Load() {
        if (!SaveManager.RegisteredComponents.Contains(this)) {
            SaveManager.RegisteredComponents.Add(this);
        }
    }

}