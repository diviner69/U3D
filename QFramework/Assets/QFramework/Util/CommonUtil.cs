using UnityEngine;

namespace QFramework
{
    /// <summary>
    /// 可能会扩张，所以用partial
    /// </summary>
    public partial class CommonUtil
    {
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }
    }
}