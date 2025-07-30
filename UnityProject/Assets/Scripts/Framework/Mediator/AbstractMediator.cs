using PureMVC.Patterns;

public abstract class AbstractMediator : Mediator {

    public AbstractMediator(string mediatorName)
        : base(mediatorName, null) { }

    protected override PureMVC.Interfaces.IFacade Facade
    {
        get {
            return _facade;
        }
    }
	
    private ApplicationFacade _facade = ApplicationFacade.instance;
}