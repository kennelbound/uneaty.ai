public interface IAISensor<T>
{
    string Name { get; }
    int InputsRequired { get; }
    T Sense();
}