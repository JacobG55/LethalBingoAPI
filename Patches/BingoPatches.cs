using GameNetcodeStuff;
using HarmonyLib;
using LethalBingoAPI.Board;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LethalBingoAPI.Patches
{
    internal class BingoPatches
    {
        // This is an example showing how to implement a bingo event that a challenge can be registered to be triggered by.
        // This will run the function for every uncompleted challenge using the 'EnemyDeath' triggerKey.
        [HarmonyPatch(typeof(EnemyAI), "KillEnemy")]
        [HarmonyPostfix]
        public static void patchKillEnemy(EnemyAI __instance)
            => BingoBoard.CheckSpaces("EnemyDeath", (x) => x.Check(__instance));

        [HarmonyPatch(typeof(HUDManager), "UseSignalTranslatorServerRpc")]
        [HarmonyPrefix]
        public static void patchSignalTransmit(string signalMessage)
            => BingoBoard.CheckSpaces("TransmitMessage", (x) => x.Check(signalMessage));

        [HarmonyPatch(typeof(StartOfRound), "EndOfGameClientRpc")]
        [HarmonyPrefix]
        public static void patchEndOfGame(StartOfRound __instance)
        {
            if (!(__instance.IsHost || __instance.IsServer)) return;
            List<GrabbableObject> itemsOnboard = Object.FindObjectsByType<GrabbableObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Where((x) => x.isInShipRoom).ToList();
            int deadPlayersCount = __instance.allPlayerScripts.Where((player) => player.isPlayerDead).Count();
            BingoBoard.CheckSpaces("EndOfGame", (x) => x.Check(itemsOnboard, RoundManager.Instance.scrapCollectedThisRound, deadPlayersCount));
        }

        [HarmonyPatch(typeof(RoundManager), "FinishGeneratingNewLevelClientRpc")]
        [HarmonyPostfix]
        public static void patchFinishNewLevelGeneration(RoundManager __instance)
        {
            if (!(__instance.IsHost || __instance.IsServer)) return;
            List<GrabbableObject> spawnedScrap = __instance.spawnedScrapContainer.gameObject.GetComponentsInChildren<GrabbableObject>().ToList();
            BingoBoard.CheckSpaces("FinishLevelGeneration", (x) => x.Check(spawnedScrap));
        }

        [HarmonyPatch(typeof(PlayerControllerB), "KillPlayerServerRpc")]
        [HarmonyPostfix]
        public static void patchPlayerKilled(int playerId, bool spawnBody, Vector3 bodyVelocity, int causeOfDeath, int deathAnimation, Vector3 positionOffset)
        {
            PlayerControllerB player = StartOfRound.Instance.allPlayerScripts[playerId];
            BingoBoard.CheckSpaces("PlayerKilled", (x) => x.Check(player, causeOfDeath, spawnBody));
        }
    }
}
