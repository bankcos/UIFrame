using UnityEngine;
using System.Collections;


namespace FrameWork
{
    public delegate void StateChangeEvent(Object ui,EnumObjectState newState,EnumObjectState oldState);
    public abstract class BaseUI : MonoBehaviour
    {
        #region Cache gameObj & transform
        private GameObject _cacheGameObject;
        public GameObject CacheGameObject
        {
            get {
                if (null == _cacheGameObject)
                    _cacheGameObject = this.gameObject;
                return _cacheGameObject;
            }

        }

        private Transform _cacheTransform;
        public Transform CacheTransform
        {
            get
            {
                if (null == _cacheTransform)
                    _cacheTransform = this.transform;
                return _cacheTransform;
            }
        }
        #endregion

        protected EnumObjectState _state = EnumObjectState.None;

        public event StateChangeEvent StateChanged;

        public EnumObjectState State
        {
            protected get
            {
                return this._state;
            }
            set 
            {
                EnumObjectState oldState = this._state;
                this._state = value;
                if (null != StateChanged)
                    StateChanged(this, this._state, oldState);
            }
        }

        public abstract EnumUIType GetUIType();


        // Use this for initialization
        void Start()
        {
            OnStart();
        }

        // Update is called once per frame
        void Update()
        {
            if (this._state == EnumObjectState.Ready)
            OnUpdate(Time.deltaTime);
        }
        void Awake()
        {
            this.State = EnumObjectState.Initial;
            OnAwake();
        }
        void Release()
        {
            this.State = EnumObjectState.Closing;
            GameObject.Destroy(this.CacheGameObject);
            
        }
        void OnDestroy()
        {
            this.State = EnumObjectState.None;
        }

        protected virtual void OnStart()
        {
            ;
        }
        protected virtual void OnAwake()
        {
            this.State = EnumObjectState.Loading;
            //播放音乐
            
        }
        protected virtual void OnUpdate(float deltaTime) { ;}

        protected virtual void OnLoadData() {  }

        protected virtual void OnRelease()
        {
            this.State = EnumObjectState.None;
            //关闭音乐

        }

        protected virtual void OnPlayOpenUIAudio() { }
        protected virtual void OnPlayCloseUIAudio() { }

        protected virtual void SetUI(params object[] uiParams)
        {
            this.State = EnumObjectState.Loading;
        }

        public void SetUIWhenOpening(params object[] uiParams)
        {
            SetUI(uiParams);
            StartCoroutine(LoadDataAsyn());
        }
        private IEnumerator LoadDataAsyn()
        {
            yield return new WaitForSeconds(0);
            if (this.State == EnumObjectState.Loading)
            {
                this.OnLoadData();
                this.State = EnumObjectState.Ready;
            }
        }
    }
}

