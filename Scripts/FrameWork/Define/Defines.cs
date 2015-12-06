using System;
using UnityEngine;

namespace FrameWork
{
    #region 全局枚举对象
    public enum EnumObjectState
    {
        None,
        Initial,
        Loading,
        Ready,
        Disabled,
        Closing
    }

    public enum EnumUIType : int
    {
        None = -1,
        TestOne = 0,
        TestTwo = 1,
    }
    #endregion
    public class UIPathDefines
    {
        public const string UI_PREFAB = "UIPrefab/";
        public const string UI_CONTROLS_PREFAB = "UIPrefab/Control/";
        public const string UI_SUBUI_PREFAB = "UIPrefab/SubUI/";
        public const string UI_ICON_PATH = "UI/Icon";

        public static string GetPrefabsPathByType(EnumUIType _uiType)
        {
            string _path = string.Empty;
            switch( _uiType ){
                case EnumUIType.TestOne:
                    _path = UI_CONTROLS_PREFAB + "TestOne";
                    break;
                case EnumUIType.TestTwo:
                    _path = UI_CONTROLS_PREFAB + "TestTwo";
                    break;
                default:
                    Debug.Log("404 NOT FIND");
                    break;
            }
            return _path;
        }
    }

    class Defines
    {
    }
}
