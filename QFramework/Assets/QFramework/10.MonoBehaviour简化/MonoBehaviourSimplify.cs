using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace QFramework
{
    /// <summary>
    /// 类
    /// </summary>
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {
        public  void Show( )
        {
            GameObjectSimplify.Show(gameObject);
        }

        public  void Hide()
        {
          GameObjectSimplify.Hide(gameObject);
        }

        public  void Identity()
        {
            TransformSimplify.Identity(transform);
        }


    }
    
    public class Hide : MonoBehaviourSimplify
    {
        private void Awake()
        {
            Hide();
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/10.MonoBehaviour 简化",false,10)]

        static void MenuClicked()
        {
            //TODO UnityEditor.EditorApplication.isPlaying 利用脚本启动unity工程
            //   UnityEditor.EditorApplication.isPlaying = true;
            Debug.Log(UnityEditor.EditorApplication.applicationPath);
            Debug.Log(UnityEditor.EditorApplication.applicationContentsPath);
            Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

            GameObject aa = new GameObject();
            aa.name = "新建对象";
            aa.AddComponent<Hide>();
        }
#endif
        protected override void OnBeforeDestroy()
        {
            throw new System.NotImplementedException();
        }
    }
}

