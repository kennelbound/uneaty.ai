public interface IAISensor<T>
{
    string Name { get; }
    T Sense();
}