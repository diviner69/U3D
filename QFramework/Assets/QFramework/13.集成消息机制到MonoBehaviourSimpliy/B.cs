using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public abstract partial class MonoBehaviourSimplify
    {
        private List<MsgRecord> mMsgRecords = new List<MsgRecord>();
        // Dictionary<string, Action<object>> mMsgRegisterRecorder = new Dictionary<string, Action<object>>();

        class MsgRecord
        {
            private static Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();

            private MsgRecord(){}//不想在外部new出来，只能通过allocate 访问  严格控制

            public static MsgRecord Allocate(string msgName, Action<object> onMsgReceived)
            {
                var retRecord = mMsgRecordPool.Count > 0? mMsgRecordPool.Pop(): new MsgRecord();

                retRecord.Name = msgName;
                retRecord.OnMysgReceived = onMsgReceived;
                return retRecord;
            }

            public void Recycle()
            {
                Name = null;
                OnMysgReceived = null;
                mMsgRecordPool.Push(this);
            }

            public string Name;
            public Action<object> OnMysgReceived;
        }

        public void RegisterMsg(string msgName, Action<object> onMsgReceived)
        {
            MsgDispatcher.Register(msgName, onMsgReceived);
            //   mMsgRegisterRecorder.Add(msgName, onMsgReceived);
            mMsgRecords.Add(MsgRecord.Allocate(msgName, onMsgReceived));
        }

        void OnDestroy()
        {
            OnBeforeDestroy();
            foreach (var msgRecord in mMsgRecords)
            {
                MsgDispatcher.UnRegister(msgRecord.Name,msgRecord.OnMysgReceived);
                msgRecord.Recycle();
            }
        }

        protected abstract void OnBeforeDestroy();
       
    }

    public class B : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/13.消息机制集成到MonoBehaviorSimpliy", false, 13)]
        static void MenuItemClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("MsgReceiverObj").AddComponent<B>();
        }
#endif
        private void Awake()
        {
            RegisterMsg("Do", DoSomething);
            RegisterMsg("Do", DoSomething);
            RegisterMsg("Do1", _ => { });
            RegisterMsg("Do2", _ => { });
        }

        void DoSomething(object data)
        {
            Debug.LogFormat("接收到的消息时{0}",data);
        }

        private IEnumerator Start()
        {
            MsgDispatcher.Send("Do","你好");
            yield return new WaitForSeconds(3f);
            MsgDispatcher.Send("Do","你好呀，哈哈");


        }

        protected override void OnBeforeDestroy()
        {
            throw new NotImplementedException();
        }
    }

}
