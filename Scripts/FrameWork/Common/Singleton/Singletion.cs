using System;
using UnityEngine;

namespace FrameWork
{
    public abstract class Singletion<T> where T : class,new()
    {
        protected static T _Instance = null;

        public static T Instance
        {
            get
            {
                if (null == _Instance)
                {
                    _Instance = new T();
                }
                return _Instance;
            }
        }

        protected Singletion()
        {
            if (null != _Instance)
                throw new SingletionException("This " + (typeof(T)).ToString() + "Singleton Instance is not null") ;
            //Init();
        }

        public virtual void Init()
        {
            //
            Debug.Log("我是父类");
        }


   }


}
