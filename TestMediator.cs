using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using UnityEngine.UI;
using System.Collections.Generic;
using PureMVC.Interfaces;

public class TestMediator :Mediator {
    public new const string NAME = "TestMediator";
    private Text levelText;
    private Text HpText;
    private Button levelUpButton;
    private Button HpButton;

    #region 用来关联组件
    public TestMediator(GameObject root) : base(NAME) {
        levelText = GameUtility.GetChildComponent<Text>(root, "Text/LevelText");
        HpText= GameUtility.GetChildComponent<Text>(root, "Text/HpText");
        HpButton= GameUtility.GetChildComponent<Button>(root, "HpButton");
        levelUpButton = GameUtility.GetChildComponent<Button>(root, "LevelUpButton");//添加组件
        levelUpButton.onClick.AddListener(OnClickLevelUpButton);//添加方法
        HpButton.onClick.AddListener(OnClickHpButton);
    }
    #endregion


    #region 怎么使用点击事件
    public void OnClickLevelUpButton() {
        SendNotification(NotificationConstant.LevelUp);
    }
    public void OnClickHpButton() {
        SendNotification(NotificationConstant.HpAdd);
    }
    #endregion


    #region 添加以及处理"感兴趣事件"
    public override IList<string> ListNotificationInterests() {
        IList<string> list = new List<string>();
        list.Add(NotificationConstant.LevelChange);
        list.Add(NotificationConstant.HpChange);
        return list;
    }
    public override void HandleNotification(PureMVC.Interfaces.INotification notification   )//执行更新视图
    {
        switch (notification.Name) {
            case NotificationConstant.LevelChange:
                CharactorInfo ci = notification.Body as CharactorInfo;
                levelText.text = ci.Level.ToString();
                break;
            case NotificationConstant.HpChange:
                CharactorInfo hi = notification.Body as CharactorInfo;
                HpText.text = hi.Hp.ToString();
                break;
            default:break;
        }
    }
    #endregion
}
