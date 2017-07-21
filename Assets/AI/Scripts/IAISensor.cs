public interface IAISensor<T>
{
    string Name { get; }
    int InputsRequired { get; }
    T Sense();
}

// TODO: Actually implement the ability for a sensor's range, etc. to vary between generations.