using UnityEngine;
using System.Collections;

namespace QFramework
{
    /// <summary>
    /// 可能会扩张，所以用partial
    /// </summary>
    public partial class TransformSimplify
    {
        public static void AddChild(Transform parentTrans,Transform childTrans)
        {
            childTrans.SetParent(parentTrans);
        }
    }

    /// <summary>
    /// 可能会扩张，所以用partial
    /// </summary>
    public partial class GameObjectSimplify
    {
        public static void Show(Transform transform)
        {
            transform.gameObject.SetActive(true);
        }

        public static void Hide(Transform transform)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public class PartialKeyworkd
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/8.partial 关键字", false, 8)]
#endif
        private static void MenuClicked()
        {
            var parentTrans = new GameObject("ParentTransform").transform;
            var childTrans = new GameObject("ChildTransform").transform;

            TransformSimplify.AddChild(parentTrans, childTrans);

            GameObjectSimplify.Hide(parentTrans);
        }
    }
}