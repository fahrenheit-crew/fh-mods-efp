// SPDX-License-Identifier: MIT
//
// This file is part of Extensions, Fixes and Patches, a mod for FF X/X-2 HD. © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the MIT License. See LICENSE.

namespace Fahrenheit.Mods.EFP;

/// <summary>
///     Provides a 'soft reset' function.
/// </summary>
[FhLoad(FhGameId.FFX | FhGameId.FFX2 | FhGameId.FFX2LM)]
public sealed class FhSoftResetModule : FhModule {

    public override bool init(FhModContext mod_context, FileStream global_state_file) {
        return true;
    }

    public override void render_imgui() {
        bool activated = (ImGui.IsKeyDown(ImGuiKey.GamepadL1) && ImGui.IsKeyDown(ImGuiKey.GamepadR1) && ImGui.IsKeyPressed(ImGuiKey.GamepadStart))
                      || (ImGui.IsKeyDown(ImGuiKey.R)         && ImGui.IsKeyDown(ImGuiKey.S)         && ImGui.IsKeyPressed(ImGuiKey.T));

        if (!activated)
            return;

        if (FhCall.MsBattleCheck.fnptr!() != 0) {
            FhUtil.set_at<ushort>(FhUtil.select(0xD2C9F1, 0x9F84B5, 0x9F84B5), 1); // btl.battle_end_type = GAME_OVER
            FhUtil.set_at<byte>  (FhUtil.select(0xD2A8E0, 0x9F68A0, 0x9F68A0), 2); // btl.battle_state    = END
            return;
        }

        FhCall.graphicDestroyFmv.fnptr!();
        FhCall.AtelJumpGameOver .fnptr!();
    }

}
