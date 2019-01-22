using UnityEngine;

// **********************************************************************
// 文件名:   TableConfigFieldInfo.cs
// 作  者:   #AuthorName#
// 时  间:   #CreateTime#
// 模块描述
// 
// **********************************************************************

/// <summary>
/// 字段描述信息
/// </summary>
public class TableConfigFieldInfo  
{
    // Note :【】高级技巧知识点 ShowGUIName
    [ShowGUIName("字段名")]
    public string fieldName = "";
    [ShowGUIName("描述")]
    public string description = "";
    [ShowGUIName("数据类型")]
    public FieldType fieldValueType;
    [ShowGUIName("数据用途")]
    public DataFieldAssetType fieldAssetType;
    [ShowGUIName("默认值")]
    public object defultValue = null;
    public string enumType = "";
}
