using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.UI;

namespace XRL.World.Parts
{
    [Serializable]
    public class helado_MusicBox_MusicPlayer : IPart
    {
        public const string MOD_PREFIX = "helado_Music Box";
        public const string MUSIC_LOCK = MOD_PREFIX + "_Music Lock";

        public static readonly string[] Tracks = {
            "Overworld1",
            "Caves1",
            "MoghrayiRemembrance",
            "Track1",
            "Kyakukya",
            "MehmetsMorning",
            "Stoic Porridge",
            "BarathrumsStudy",
            "Golgotha (Graveyard)",
            "Lazarus",
            "AmongTheTombs",
            "DeeperEaters",
            "Onward",
            "Substrate"
        };

        public Random RandomSource;

        public static bool IsMusicLockOn()
        {
            return
                XRLCore.Core?.Game != null &&
                XRLCore.Core.Game.GetBooleanGameState(MUSIC_LOCK);
        }

        public override void Attach()
        {
            RandomSource = XRL.Rules.Stat.GetSeededRandomGenerator(
                $"{MOD_PREFIX}_{ParentObject.id}"
            );
        }

        public override bool WantEvent(int id, int cascade)
        {
            return
                id == GetInventoryActionsEvent.ID ||
                id == InventoryActionEvent.ID ||
            base.WantEvent(id, cascade);
        }

        public override bool HandleEvent(GetInventoryActionsEvent @event)
        {
            @event.AddAction(
                Name: "Activate",
                Key: 'a',
                Display: "{{W|a}}ctivate",
                Command: "Activate",
                WorksTelekinetically: true
            );

            // If a music player is currently playing, allow deactivating it.
            if (IsMusicLockOn())
            {
                @event.AddAction(
                    Name: "Deactivate",
                    Key: 'd',
                    Display: "{{W|d}}eactivate",
                    Command: "Deactivate",
                    WorksTelekinetically: true
                );
            }

            return true;
        }

        public override bool HandleEvent(InventoryActionEvent @event)
        {
            switch (@event.Command)
            {
                case "Activate":
                    string track = null;

                    if (@event.Actor.IsPlayer())
                    {
                        var index = Popup.ShowOptionList(
                            Title: "Choose a track.",
                            Options: Tracks,
                            AllowEscape: true
                        );

                        if (index != -1)
                        {
                            track = Tracks[index];
                        }
                    }
                    else
                    {
                        track = Tracks.GetRandomElement(RandomSource);
                    }

                    if (track != null)
                    {
                        XRLCore.Core?.Game?.SetBooleanGameState(MUSIC_LOCK, false);
                        SoundManager.PlayMusic(track, Crossfade: true);
                        XRLCore.Core?.Game?.SetBooleanGameState(MUSIC_LOCK, true);
                        @event.RequestInterfaceExit();
                    }

                    return true;

                case "Deactivate":
                    XRLCore.Core?.Game?.SetBooleanGameState(MUSIC_LOCK, false);

                    // If the current zone has its own music, play that.
                    // Otherwise, just be silent.
                    SoundManager.PlayMusic(
                        XRLCore.Core?.Game?.Player?.Body?.CurrentZone?.
                            FindFirstObject("ZoneMusic")?.
                            GetStringProperty("Track"),
                        Crossfade: true
                    );

                    @event.RequestInterfaceExit();
                    return true;

                default:
                    return false;
            }
        }
    }
}
