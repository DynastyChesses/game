public class TBaseProxy<T> : BaseProxy where T : TBaseProxy<T>
{
    public TBaseProxy(string proxyName) : base(proxyName)
    {
        s_proxyName = proxyName;
    }

    private static string s_proxyName = null;
    private static T s_instance = null;
    public static T instance
    {
        get
        {
            s_instance = s_instance ?? ApplicationFacade.instance.RetrieveProxy(s_proxyName) as T;
            return s_instance;
        }
    }

    protected override void DoOnRemove()
    {
        s_instance = null;
    }
}