using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class Test2Command : SimpleCommand
{
    public new const string NAME = "Test2Command";
    public override void Execute(INotification notification)
    {
        TestProxy proxy = (TestProxy)Facade.RetrieveProxy(TestProxy.NAME);
        proxy.ChangeHp(10);
    }
}
