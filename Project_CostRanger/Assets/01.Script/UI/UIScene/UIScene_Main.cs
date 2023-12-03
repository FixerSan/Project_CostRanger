using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene_Main : UIScene
{
    public override bool Init()
    {
        if (!base.Init())
            return false;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindEvent(GetButton((int)Buttons.Button_Battle).gameObject, () => { Managers.UI.ShowPopupUI<UIPopup_WorldMap_ChapterOne>(); });
        BindEvent(GetButton((int)Buttons.Button_Gacha).gameObject, () => { Managers.UI.ShowPopupUI<UIPopup_Gacha>(); });

        RedrawUI();
        return true;
    }

    public override void RedrawUI()
    {
        GetText((int)Texts.Text_Name).text = $"{Managers.Game.playerData.name}";
        GetText((int)Texts.Text_Level).text = $"LV.{Managers.Game.playerData.level}";
        GetText((int)Texts.Text_Gem).text = $"{Managers.Game.playerData.gem}";
        GetText((int)Texts.Text_Gold).text = $"{Managers.Game.playerData.gold}";
        GetText((int)Texts.Text_EXP).text = $"추가해야함";
    }

    private enum Buttons
    {
        Button_Battle, Button_Gacha
    }

    private enum Texts
    {
        Text_Name, Text_Level, Text_Gem, Text_Gold, Text_EXP
    }
}
