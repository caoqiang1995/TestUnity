using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class TestCommand : SimpleCommand {
    public new const string NAME = "TestCommand";
    public override void Execute(INotification notification)
    {
        TestProxy proxy = (TestProxy)Facade.RetrieveProxy(TestProxy.NAME);
        proxy.ChangeLevel(1);        
    }
}
