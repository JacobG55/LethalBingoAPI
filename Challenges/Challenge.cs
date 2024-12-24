namespace LethalBingoAPI.Challenges
{
    public abstract class Challenge(string triggerKey, string description)
    {
        public readonly string triggerKey = triggerKey;
        public string description = description;
        public virtual bool Success() => true;
        public abstract void Reset();

        public bool Check<T1>(T1 val1)
        {
            if (this is GenericChallenge<T1> generic)
            {
                return generic.Check(generic, val1);
            }
            return false;
        }
        public bool Check<T1, T2>(T1 val1, T2 val2)
        {
            if (this is GenericChallenge<T1, T2> generic)
            {
                return generic.Check(generic, val1, val2);
            }
            return false;
        }
        public bool Check<T1, T2, T3>(T1 val1, T2 val2, T3 val3)
        {
            if (this is GenericChallenge<T1, T2, T3> generic)
            {
                return generic.Check(generic, val1, val2, val3);
            }
            return false;
        }
        public bool Check<T1, T2, T3, T4>(T1 val1, T2 val2, T3 val3, T4 val4)
        {
            if (this is GenericChallenge<T1, T2, T3, T4> generic)
            {
                return generic.Check(generic, val1, val2, val3, val4);
            }
            return false;
        }
        public bool Check<T1, T2, T3, T4, T5>(T1 val1, T2 val2, T3 val3, T4 val4, T5 val5)
        {
            if (this is GenericChallenge<T1, T2, T3, T4, T5> generic)
            {
                return generic.Check(generic, val1, val2, val3, val4, val5);
            }
            return false;
        }
        public bool Check<T1, T2, T3, T4, T5, T6>(T1 val1, T2 val2, T3 val3, T4 val4, T5 val5, T6 val6)
        {
            if (this is GenericChallenge<T1, T2, T3, T4, T5, T6> generic)
            {
                return generic.Check(generic, val1, val2, val3, val4, val5, val6);
            }
            return false;
        }
    }
}
