public class GuestInfo : IUserInfo
{
    public GuestInfo(string UId, string UName)
    {
        this.UId = UId;
        this.UserName = UName;
    }

    public string UId { get; private set; }
    public string UserName { get; private set; }
}