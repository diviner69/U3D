using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QFramework
{
    public partial class MonoBehaviourSimplify
    {
        public void UnRegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            var selectedRecords =
                mMsgRecords.FindAll(record => record.Name == msgName && record.OnMysgReceived == onMsgReceived);
            selectedRecords.ForEach(record =>
            {
                MsgDispatcher.UnRegister(record.Name,record.OnMysgReceived);
                mMsgRecords.Remove(record);
                record.Recycle();
            });
            selectedRecords.Clear();
        }
        public void UnRegisterMsg(string msgName )
        {
            var selectedRecords =
                mMsgRecords.FindAll(record => record.Name == msgName  );
            selectedRecords.ForEach(record =>
            {
                MsgDispatcher.UnRegister(record.Name, record.OnMysgReceived);
                mMsgRecords.Remove(record);
                record.Recycle();
            });
            selectedRecords.Clear();
        }
        public static void SendMsg(string msgName, object data)
        {
            MsgDispatcher.Send(msgName, data);
        }
    }

    public class UnifyAPIStyle : MonoBehaviourSimplify
    {

#if UNITY_EDITOR
        [MenuItem("QFramework/14.统一API风格", false, 14)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("MsgReceiverObj").AddComponent<UnifyAPIStyle>();
        }
#endif

        void Awake()
        {
            RegisterMsg("ok", data =>
            {
                Debug.Log(data);
                UnRegisterMsg("ok");

            });
        }
        void Start()
        {
            SendMsg("ok","hello");
            SendMsg("ok", "hello");
            //RegisterMsg("Do", _ => { });//不推荐使用，注销时找不到相同的方法
            //RegisterMsg("Do",DoSomething);//推荐使用 
            
        }

        // Update is called once per frame
        void DoSomething(object data)
        {
            Debug.LogFormat("接收到的消息时{0}", data);
        }

        protected override void OnBeforeDestroy()
        {
          
        }
    }
}
