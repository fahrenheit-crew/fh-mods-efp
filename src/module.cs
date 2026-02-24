// SPDX-License-Identifier: MIT

using System.IO;

namespace Fahrenheit.Mods.EFP;

public class Patches {
    //public static OverdriveCostFix overdrive_cost = new();
    // Add patch here like so: `public static PatchType patch_name = new();`
}

[FhLoad(FhGameId.FFX)]
public class EfpModule : FhModule {
    public Patches patches; // TODO: re-evaluate.

    private FhModContext? _context;
    private FileStream?   _global_state;

    public override bool init(FhModContext context, FileStream global_state) {
        patches  = new();
        settings = new FhSettingsCategory("fh.efp", [
            // Choose which category to put your patch in:
            // - Fixes are EfpPatches that fix vanilla bugs, such as commands not properly dealing with arbitrary overdrive costs
            // - Patches are EfpPatches that provide commonly desired changes, such as guaranteed AP for all party members
            // - Extensions are EfpPatches that provide Fahrenheit with runtime functionality for its APIs, such as adding new commands
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
        ]);

        _context      = context;
        _global_state = global_state;

        //patches.overdrive_cost.hook();
        // Add patch here like so: `patches.patch_name.hook()`

        return true;
    }
}
