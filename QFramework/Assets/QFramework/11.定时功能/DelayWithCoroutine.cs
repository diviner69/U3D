using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public partial class MonoBehaviourSimplify
    {
        public void Delay(float seconds, Action onFinishedAction)
        {
            StartCoroutine(DelayCoroutine(seconds, onFinishedAction));
        }


        private IEnumerator DelayCoroutine(float seconds,Action onFinishedAction)
        {
            yield return  new WaitForSeconds(seconds);
            onFinishedAction();
        }
    }


    public  class DelayWithCoroutine : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/11.定时功能", false, 11)]
        static void MenuItemClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject().AddComponent<DelayWithCoroutine>();
        }
#endif


        // Use this for initialization
        void Start()
        {
            Delay(5.0f, () =>
            {
                Debug.Log("5秒后消失");
                Hide();
            });
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected override void OnBeforeDestroy()
        {
            throw new NotImplementedException();
        }
    }
}