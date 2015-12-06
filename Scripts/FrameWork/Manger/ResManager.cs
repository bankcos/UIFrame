using System;
using UnityEngine;

namespace FrameWork
{
    class ResManager : Singletion<ResManager>
    {
        public override void Init()
        {
            base.Init();
            Debug.Log("ResManager干死你");
        }
    }

}
