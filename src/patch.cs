// SPDX-License-Identifier: MIT
//
// This file is part of Extensions, Fixes and Patches, a mod for FF X/X-2 HD. © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the MIT License. See LICENSE.

namespace Fahrenheit.Mods.EFP;

public abstract class EfpPatch : FhModule {
    public abstract FhSettingsCategory get_settings();
}
