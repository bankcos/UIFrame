using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestOne : MonoBehaviour {

    private Button btn;
	// Use this for initialization
	void Start () {
        btn = transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/TestTwo"));
        TestTwo tt = go.GetComponent<TestTwo>();
        if (null == tt)
        {
            tt = go.AddComponent<TestTwo>();
            Close();
        }
    }
    private void Close()
    {
        Destroy(gameObject);
    }

}
