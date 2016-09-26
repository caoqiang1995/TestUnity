using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
public class TestProxy : Proxy {
    public new const string NAME = "TestProxy;";
    public CharactorInfo Data { get; set; }
    public TestProxy() : base(NAME) {
        Data = new CharactorInfo();
    }
    public void ChangeLevel(int change) {
        Data.Level += change;     
        SendNotification(NotificationConstant.LevelChange, Data);//让它更新视图发送到Mediator进行更新，若是Mediator感兴趣的，则调用Mediator里感兴趣的Handle方法
    }
    public void ChangeHp(int hp) {
        Data.Hp += hp;
        SendNotification(NotificationConstant.HpChange, Data);
    }
}
