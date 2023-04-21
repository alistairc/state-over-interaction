namespace StateOverInteraction.Summing.Decoupled;

//has to be public for Moq
public interface IMathsService
{
    int Add(int a, int b);
}