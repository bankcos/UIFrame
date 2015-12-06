using UnityEngine;
using System.Collections;
using FrameWork;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Instance.Init();
        ResManager.Instance.Init();
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/TestOne"));
        TestOne tt = go.GetComponent<TestOne>();
        if (null == tt)
        {
            tt = go.AddComponent<TestOne>();

        }	
	}
	

}
