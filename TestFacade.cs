using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
public class TestFacade : Facade {
    public TestFacade(GameObject canvas) {
        RegisterCommand(NotificationConstant.LevelUp, typeof(TestCommand));//Model,注册了之后，点了就会调用之后TestComand的Excute
        RegisterCommand(NotificationConstant.HpAdd, typeof(Test2Command));
        RegisterMediator(new TestMediator(canvas));//管理视图
        RegisterProxy(new TestProxy());//管理模型

        #region 执行方法
        /*
         先用RegisterCommand将TestCommand&Test2Command注册到对应的NC事件中去，再注册Mediator和Proxy
         当在TestMediator中发生点击事件时，点击事件中调用SendNotification发消息执行LevelUp注册的任务
         该任务会调用模型中的函数：
         1.Data.Level += change;     
           改变模型数据
        SendNotification(NotificationConstant.LevelChange, Data);
        发消息通知视图改变=》

        发送消息LevelChange,视图进行判断是否感兴趣，若感兴趣则进行操作，否则不进行操作
                 */
        #endregion

        #region 事件处理机制
        /*
        NotificationConstant用来保存发送的消息常量，其中:

        LevelUp代表的是在模型和视图都没更新时让模型进行更新的操作

        LevelChange代表的是在LevelUp更新了模型之后，等级改变了更新视图的操作

        LevelUp在点击事件发生的时候发送，在本类中使用RegisterCommand为其绑定了所调用的Task
        LevelChange在模型发生改变的时候发送，在TestMediator Ilist中进行接收处理
*/
        #endregion

        #region 总结
        /*通过2个通知，LevelUp，LevelChange，通过对其使用RegisterCommand注册方法，使得接收到该通知时调用方法
         

        SendNotification:发送消息，发送后会在RegisterCommand以及Mediator中查找是否有对应的操作，若注册了方法，则执行该Commond，若在Mediator->HandleNotification中注册了操作，则执行对应的操作
         */
        #endregion
    }
}
