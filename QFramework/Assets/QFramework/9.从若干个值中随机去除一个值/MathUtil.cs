using UnityEditor;
using UnityEngine;

namespace QFramework
{
    public partial class MathUtil 
    {
        //params 可变参数
        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[Random.Range(0, values.Length)];

        }

#if UNITY_EDITOR
        [MenuItem("QFramework/9.从若干个值中随机去除一个值", false, 9)]
#endif
        public static void MenuClicked1()
        {
            var floatRandomValue = GetRandomValueFrom(new float[] {0.1f, 2f, 3.5f, 4.6f, 5.8f, 6.2f});
            var intRandomValue = GetRandomValueFrom(new int[] {1, 2, 3, 4, 5, 6});
            var intRandomValue1 = GetRandomValueFrom(1, 2, 3, 4, 5, 6);
            Debug.Log(floatRandomValue);
            Debug.Log(intRandomValue);
            Debug.Log(intRandomValue1);
        }

    }
}