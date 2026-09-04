// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.EFP;

public abstract class EfpPatch {
    public abstract FhSettingsCategory get_settings();

    public abstract void hook();
}
