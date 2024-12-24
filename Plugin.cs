using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalBingoAPI.Board;
using LethalBingoAPI.Challenges;
using LethalBingoAPI.Patches;

namespace LethalBingoAPI
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    [BepInDependency("evaisa.lethallib", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("MaxWasUnavailable.LethalModDataLib")]
    public class Plugin : BaseUnityPlugin
    {
		public const string ModGUID = "JacobG5.LethalBingoAPI";
		public const string ModName = "LethalBingoAPI";
		public const string ModVersion = "1.0.0";

        private readonly Harmony harmony = new(ModGUID);
        internal static ManualLogSource mls;

        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(ModGUID);
            harmony.PatchAll(typeof(BingoPatches));

            // This is just an example of registering a challenge
            BingoBoard.RegisterChallenge("example_challenge", new GenericChallenge<EnemyAI>("EnemyDeath", "Kill 5 nutcrackers outside the facility.", (challenge, enemy) =>
            {
                if (enemy is NutcrackerEnemyAI nutcracker && nutcracker.isOutside)
                {
                    challenge.Add();
                    return challenge.Get() >= 5;
                }
                return false;
            }, 0));
        }
    }
}
