using MobileSDK.Account;
using osP1.Helper;
using UnityEngine;

public class LoginState: ClientState
{
    private ClientStateManager _innerCSM;

    public LoginState(IClientStateManager csm):base(csm, GameStateConst.LOGIN)
    {
        
    }
    
    public override void OnEnterState(int prevState, object context)
    {
        //
        _innerCSM = new ClientStateManager(GameStateManager.NONE_STATE);
#if UNITY_IOS && !UNITY_EDITOR
        AuthSDKManager.LoadStrategy(SignInStrategy.GameCenter, OnResult);
#else
        AuthSDKManager.LoadStrategy(SignInStrategy.Guest, OnResult);
#endif
    }

    private void OnResult(bool obj)
    {
        AccountManager.instance.Auth(OnAuth);
    }

    private void OnAuth(bool arg1, IUserInfo arg2)
    {
        if (arg1)
        {
            GameStateManager.instance.Input(GameStateConst.IN_GAME, false);
            Debug.Log($" The Next:{ arg2.UserName}");
        }
        else
        {
            // 走游客模式 TODO
            AuthSDKManager.LoadStrategy(SignInStrategy.Guest, OnResult);
        }
    }

    public override void OnLeaveState(int nextState, object context)
    {
        Logger.Debug("离开登录状态");
		
		_innerCSM.Dispose();
        
    }
}