namespace IoReader.Communication.Mediators
{
    public interface IHasContentMediator
    {
        IContentMediator Mediator { get; }
    }
}