using System;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;


public partial class SROptions
{
    [NumberRange(1, 48)]
    [Category("Enter Level")]
    public int LevelId { get; set; }

    [Category("Enter Level")]
    public void EnterLevel()
    {
        ApplicationFacade.instance.SendNotification("DebugEnterLevel", LevelId);
    }


    [Category("Level Controller")]
    public void GameWin()
    {
        ApplicationFacade.instance.SendNotification("DebugGameWin");
    }

    [Category("Level Controller")]
    public void FillFeverEnergy()
    {
        ApplicationFacade.instance.SendNotification("DebugFillFeverEnergy");
    }


    [Category("Player Assets")]
    public void ClearSave()
    {
        ApplicationFacade.instance.SendNotification("DebugClearSave");
    }


    [Category("Player Assets")]
    public void AddStamina()
    {
        ApplicationFacade.instance.SendNotification("DebugAddStamina");
    }

    [Category("Player Assets")]
    public void RemoveStamina()
    {
        ApplicationFacade.instance.SendNotification("DebugRemoveStamina");
    }


    [NumberRange(1, int.MaxValue)]
    [Category("Player Assets")]
    public int GoldNumber { get; set; }

    [Category("Player Assets")]
    public void AddGold()
    {
        ApplicationFacade.instance.SendNotification("DebugAddGold", GoldNumber);
    }

    [Category("Player Assets")]
    public void RemoveGold()
    {
        ApplicationFacade.instance.SendNotification("DebugRemoveGold", GoldNumber);
    }

    [Category("Player Assets")]
    public void AddAdTicket()
    {
        ApplicationFacade.instance.SendNotification("DebugAddAdTicket");
    }

    [Category("Player Assets")]
    public void RemoveAdTicket()
    {
        ApplicationFacade.instance.SendNotification("DebugRemoveAdTicket");
    }


    [Category("Player Assets")]
    public void AddMagnet()
    {
        ApplicationFacade.instance.SendNotification("DebugAddMagnet");
    }

    [Category("Player Assets")]
    public void AddForceChoose()
    {
        ApplicationFacade.instance.SendNotification("DebugAddForceChoose");
    }

    [Category("Player Assets")]
    public void AddHammer()
    {
        ApplicationFacade.instance.SendNotification("DebugAddHammer");
    }

    [Category("Player Assets")]
    public void AddRefresh()
    {
        ApplicationFacade.instance.SendNotification("DebugAddRefresh");
    }
    
    [NumberRange(1,1800)]
    [Category("Player Assets")]
    public int RemainTime { get; set; }

    [Category("Player Assets")]
    public void SetRemainTime()
    {
        
        ApplicationFacade.instance.SendNotification("DebugSetRemainTime",RemainTime);
    }
}