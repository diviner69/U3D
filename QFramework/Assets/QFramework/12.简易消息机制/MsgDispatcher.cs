using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgDispatcher : MonoBehaviour
{

    private static Dictionary<string, Action<object>> _mRegisterdMsgs = new Dictionary<string, Action<object>>();


    public static void Register(string msgName, Action<object> OnMsgReceived)
    {
        if (!_mRegisterdMsgs.ContainsKey(msgName))
        {
            _mRegisterdMsgs.Add(msgName, _ => { });
        }
        _mRegisterdMsgs [msgName]+= OnMsgReceived;
    }

    public static void UnRegisterAll(string msgName)
    {
        _mRegisterdMsgs.Remove(msgName);
    }
    public static void UnRegister (string msgName, Action<object> OnMsgReceived)
    {
        if (_mRegisterdMsgs.ContainsKey(msgName))
        {
            _mRegisterdMsgs[msgName] -= OnMsgReceived;
        }
    }

    public static void Send(string msgName,object data)
    {
        if (_mRegisterdMsgs.ContainsKey(msgName))
        {
        _mRegisterdMsgs[msgName](data);

        }
    }

#if  UNITY_EDITOR
    [UnityEditor.MenuItem("QFramework/12.简易消息机制", false, 12)]
    static void MenuItemClicked()
    {
        //lamada表达式
        Action<object> onMsgReceived = data => { Debug.LogFormat("消息1：{0}", data); };

        Register("消息1", onMsgReceived);
        Register("消息1", onMsgReceived );
        Send("消息1","hello world");

        UnRegister("消息1", onMsgReceived);

        Send("消息1","hello hi");

    }
    /// <summary>
    /// 消息
    /// </summary>
    /// <param name="data"></param>
    static void OnMsgReceived1(object data)
    {
        Debug.LogFormat("消息1：{0}", data);
    }



#endif
}
