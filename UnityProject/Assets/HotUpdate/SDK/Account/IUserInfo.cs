/// <summary>
/// 账户信息
/// </summary>
public interface IUserInfo
{
    /// <summary>
    /// 唯一Id
    /// </summary>
    public string UId { get; }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; }
}
