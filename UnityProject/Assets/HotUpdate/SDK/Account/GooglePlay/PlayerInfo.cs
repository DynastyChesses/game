public class PlayerInfo : IUserInfo
{
    public string playerId;

    public string playerName;

    public string UId => playerId;

    public string UserName => playerName;
}