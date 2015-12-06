using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TestTwo : MonoBehaviour {

    private Button btn;
    // Use this for initialization
    void Start()
    {
        btn = transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/TestOne"));
        TestOne tt = go.GetComponent<TestOne>();
        if (null == tt)
        {
            tt = go.AddComponent<TestOne>();
        }
        Close();
    }
    private void Close()
    {
        Destroy(gameObject);
    }
}
