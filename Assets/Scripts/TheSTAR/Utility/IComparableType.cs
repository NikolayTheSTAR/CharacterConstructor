namespace TheSTAR.Utility
{
    public interface IComparableType<in T>
    {
        int CompareToType<T1>() where T1 : T;
    }
}