﻿using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace QFramework
{
    /// <summary>
    /// 可能会扩张，所以用partial
    /// </summary>
    public partial class EditorUtil
    {
        public static void OpenInFolder(string folderPath)
        {
            Application.OpenURL("file:///" + folderPath);
        }

#if UNITY_EDITOR
        public static void ExportPackage(string assetPathName, string fileName)
        {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }

        [MenuItem("QFramework/Examble/2.MenuItem 复用", false, 3)]
        private static void MenuClicked()
        {
            EditorUtil.CallMenuItem("2.复制文本到剪切板");

        }

        public static void CallMenuItem(string menuName)
        {
            EditorApplication.ExecuteMenuItem(menuName);
        }
#endif
    }
}