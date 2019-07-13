#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace QFramework
{ /// <summary>
  /// 可能会扩张，所以用partial
  /// </summary>
    public partial class GameObjectSimplify
    {
        public static void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        [MenuItem("QFramework/7.GameObject active 简化", false, 7)]
#endif
        private static void MenuClicked()
        {
            GameObject gameObject = new GameObject();

            Hide(gameObject);
        }
    }
}