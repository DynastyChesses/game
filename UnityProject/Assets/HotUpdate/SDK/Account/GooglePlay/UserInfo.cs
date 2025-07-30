public class Userinfo : IUserInfo
{
    private string _uid;
    private string _userName;

    public Userinfo(string uid, string userName)
    {
        this._uid = uid;
        this._userName = userName;
    }

    public string UId => this._uid;

    public string UserName => this._userName;
}