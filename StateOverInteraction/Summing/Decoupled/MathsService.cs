namespace StateOverInteraction.Summing.Decoupled;

class MathsService : IMathsService
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}