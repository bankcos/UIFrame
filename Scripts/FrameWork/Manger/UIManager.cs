using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    class UIManager : Singletion<UIManager>
    {
        class UIInfoData
        {
            private EnumUIType _uiType;
            private string _path;
            private object[] _uiParams;

            public EnumUIType UIType { get; private set; }
            public string Path { get; private set; }
            public object[] UIparams { get; private set; }
            public UIInfoData(EnumUIType _uiType,string _path,params object[] _uiParams)
            {
                UIType = _uiType;
                Path = _path;
                UIparams = _uiParams;
            }



        }
        
        private Dictionary<EnumUIType, GameObject> dicOpenUIs = null;
        
        private Stack<UIInfoData> stackOpenUIs = null;   //UI needs to opening
       
        /// <summary>
       /// Init this instance
       /// </summary>
        public override void Init()
        {
            dicOpenUIs = new Dictionary<EnumUIType, GameObject>();
            stackOpenUIs = new Stack<UIInfoData>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_uiType"></param>
        /// <returns></returns>
        public T GetUI<T>(EnumUIType _uiType) where T : BaseUI
        {
            GameObject _retObj = null;
            if (!dicOpenUIs.TryGetValue(_uiType, out _retObj))
            {
                if ( _retObj != null ){
                    return _retObj.GetComponent<T>();
                }
            }
            return null;
        }

        /// <summary>
        /// Gets  the user interface object
        /// </summary>
        /// <param name="_uiType"></param>
        /// <returns></returns>
        public GameObject GetUIObject(EnumUIType _uiType)
        {
            GameObject _retObj = null;
            if (!dicOpenUIs.TryGetValue(_uiType, out _retObj))
                throw new Exception("获取UI失败" + _uiType);
            return _retObj;
        }


        public void OpenUI(EnumUIType[] _uiTypes)
        {
            OpenUI(false,_uiTypes,null);
        }

        public void OpenUI(EnumUIType _uiType,params object[] _uiParams)
        {
            EnumUIType[] _uiTypes = new EnumUIType[1];
            _uiTypes[0] = _uiType;
            OpenUI(false, _uiTypes,_uiParams);
        }
    
        public void OpenUICloseOthers(EnumUIType[] _uiTypes)
        {
            OpenUI(true, _uiTypes, null);
        }

        public void OpenUICloseOthers(EnumUIType _uiType, params object[] _uiParams)
        {
            EnumUIType[] _uiTypes = new EnumUIType[1];
            _uiTypes[0] = _uiType;
            OpenUI(true, _uiTypes, _uiTypes);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isCloseOthers"></param>
        /// <param name="_uiTypes"></param>
        /// <param name="_uiParams"></param>
        public void OpenUI(bool _isCloseOthers,EnumUIType[] _uiTypes, params object[] _uiParams)
        {
            if (_isCloseOthers)
            {
                //CloseUI();
            }
            // push _uiTypes
            for (int i = 0; i < _uiTypes.Length; i++)
            {
                EnumUIType _uiType = _uiTypes[i];
                if (!dicOpenUIs.ContainsKey(_uiType))
                {
                    string _path = "";
                    stackOpenUIs.Push( new UIInfoData(_uiType, _path, _uiParams));

                }
                if (stackOpenUIs.Count > 0)
                {
                    //open _uiType
 
                }
            }
        }
    }
}
