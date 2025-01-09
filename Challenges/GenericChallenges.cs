using System;

namespace LethalBingoAPI.Challenges
{
    public class GenericChallenge(string triggerKey, string description, params int[] defaultCounters) : Challenge(triggerKey, description)
    {
        private int[] counters = defaultCounters;
        private readonly int[] defaultValues = defaultCounters;

        public override void Reset()
        {
            counters = defaultValues;
        }

        public void AddPoint(int id = 0, int value = 1)
        {
            if (InBounds(id)) counters[id] += value;
        }
        public void RemovePoint(int id = 0, int value = 1) => AddPoint(id, -value);
        public bool InBounds(int value) => value >= 0 && value < counters.Length;
        public int GetCount(int id = 0)
        {
            if (InBounds(id)) return counters[id];
            else return 0;
        }
    }

    public class GenericChallenge<T1>(string triggerKey, string description, Func<GenericChallenge, T1, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2>(string triggerKey, string description, Func<GenericChallenge, T1, T2, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2, T3>(string triggerKey, string description, Func<GenericChallenge, T1, T2, T3, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, T3, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2, T3, T4>(string triggerKey, string description, Func<GenericChallenge, T1, T2, T3, T4, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, T3, T4, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2, T3, T4, T5>(string triggerKey, string description, Func<GenericChallenge, T1, T2, T3, T4, T5, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, T3, T4, T5, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2, T3, T4, T5, T6>(string triggerKey, string description, Func<GenericChallenge, T1, T2, T3, T4, T5, T6, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, T3, T4, T5, T6, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2, T3, T4, T5, T6, T7>(string triggerKey, string description, Func<GenericChallenge, T1, T2, T3, T4, T5, T6, T7, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, T3, T4, T5, T6, T7, bool> Check = finalCheck;
    }
    public class GenericChallenge<T1, T2, T3, T4, T5, T6, T7, T8>(string triggerKey, string description, Func<GenericChallenge, T1, T2, T3, T4, T5, T6, T7, T8, bool> finalCheck, params int[] defaultCounters) : GenericChallenge(triggerKey, description, defaultCounters)
    {
        public readonly Func<GenericChallenge, T1, T2, T3, T4, T5, T6, T7, T8, bool> Check = finalCheck;
    }
}
