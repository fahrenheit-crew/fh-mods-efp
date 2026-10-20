// SPDX-License-Identifier: MIT
//
// This file is part of Extensions, Fixes and Patches, a mod for FF X/X-2 HD. © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the MIT License. See LICENSE.

namespace Fahrenheit.Mods.EFP;

public class EfpSettings : FhSettingProvider<EfpModule> {
    protected override IEnumerable<FhSetting> get() {
        return [
            new FhSettingsCategory("fixes", [
                //patches.overdrive_cost.get_settings(),
                // Add your patches here like so: `patches.patch_name.get_settings()`
            ]),
            new FhSettingsCategory("patches", [
                // Add your patches here like so: `patches.patch_name.get_settings()`
            ]),
            new FhSettingsCategory("extensions", [
                // Add your patches here like so: `patches.patch_name.get_settings()`
            ]),
        ];
    }
}

// Choose which category to put your patch in:
// - Fixes are EfpPatches that fix vanilla bugs, such as commands not properly dealing with arbitrary overdrive costs
// - Patches are EfpPatches that provide commonly desired changes, such as guaranteed AP for all party members
// - Extensions are EfpPatches that provide Fahrenheit with runtime functionality for its APIs, such as adding new commands

[FhLoad(FhGameId.FFX)]
public class EfpModule : FhModule {
    private readonly EfpSettings _settings;

    public EfpModule() {
        _settings = new();
    }

    public override bool init(FhModContext context, FileStream global_state) {
        return true;
    }
}
