﻿using HDJ.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LanguageDataEditorUtils
{


    #region 加载/保存编辑器设置

    public static void SaveData(SystemLanguage langeuageName, string fullkeyFileName, DataTable data)
    {
        if (data == null)
            return;
        string path = LanguageDataUtils.SavePathDir + langeuageName + "/" + LanguageManager.GetLanguageDataName(langeuageName, fullkeyFileName) + ".txt";

        string text = DataTable.Serialize(data);

        FileUtils.CreateTextFile(path, text);
        UnityEditor.AssetDatabase.Refresh();
    }

    /// <summary>
    /// 加载所有某种语言的所有多语言文件，并转换成带"/"路径的数据
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    public static List<string> LoadLangusgeAllFileNames(SystemLanguage language)
    {
        List<string> datas = new List<string>();

        string pathDir = LanguageDataUtils.SavePathDir + language;
        string[] fileNames = PathUtils.GetDirectoryFileNames(pathDir, new string[] { ".txt" });
        foreach (var item in fileNames)
        {
            string temp = item.Replace(LanguageManager.c_DataFilePrefix + language + "_", "").Replace("_", "/");
            if (string.IsNullOrEmpty(temp))
                continue;
            datas.Add(temp);
        }
        return datas;
    }

    #endregion

    public static List<string> GetLanguageAllFunKeyList()
    {
        List<string> list = new List<string>();
        LanguageSettingConfig config = LanguageDataUtils.LoadEditorConfig();
        List<string> allFilePath = LoadLangusgeAllFileNames(config.defaultLanguage);
        foreach (var item in allFilePath)
        {
            DataTable data = LanguageDataUtils.LoadFileData(config.defaultLanguage, item);
            foreach (var key in data.TableIDs)
            {
                list.Add(item + "/" + key);
            }
        }
        return list;
    }

    public static List<string> GetLanguageLayersKeyList()
    {
        List<string> list_strs = new List<string>();
        list_strs.Add("作者竟然没有定义这样的方法，但是却用到了");
        return list_strs;
    }
}

