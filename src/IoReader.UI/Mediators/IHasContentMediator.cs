﻿namespace IoReader.Mediators
{
    public interface IHasContentMediator
    {
        IContentMediator Mediator { get; }
    }
}