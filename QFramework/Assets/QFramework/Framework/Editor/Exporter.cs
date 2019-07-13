using System;
using System.IO;
using UnityEngine;

//#if UNITY_EDITOR
using UnityEditor;
//#endif

namespace QFramework
{
    public class Exporter
    {
        //只有此脚本使用，private
        private static string GeneratePackageName()
        {
            return "QFramework_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
        }

//因为脚本已经放置在editor目录下了，不影响打包。所以不需要editor宏定义了
//#if UNITY_EDITOR
        [MenuItem("QFramework/Framwork/Editor %e", false, 1)]
        static void MenuClicked()
        {
            EditorUtil.ExportPackage("Assets/QFramework", GeneratePackageName() + ".unitypackage");
            EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }

//#endif
    }
}