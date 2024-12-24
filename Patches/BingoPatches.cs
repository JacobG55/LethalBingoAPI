using HarmonyLib;
using LethalBingoAPI.Board;

namespace LethalBingoAPI.Patches
{
    internal class BingoPatches
    {
        // This is an example showing how to implement a bingo event that a challenge can be registered to be triggered by.
        // This will run the function for every uncompleted challenge using the 'EnemyDeath' triggerKey.
        [HarmonyPatch(typeof(EnemyAI), "KillEnemy")]
        [HarmonyPostfix]
        public virtual void patchKillEnemy(EnemyAI __instance)
            => BingoBoard.CheckSpaces("EnemyDeath", (x) => x.Check(__instance));
    }
}
