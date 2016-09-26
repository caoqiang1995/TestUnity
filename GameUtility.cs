using UnityEngine;
using System.Collections;

public class GameUtility : MonoBehaviour {
    //获取一个Transform
    public static Transform GetChild(GameObject root, string path) {
        Transform tra = root.transform.Find(path);
        if (tra == null) Debug.Log(path + "not find");
        return tra;
    }
    //获取一个组件
    public static T GetChildComponent<T>(GameObject root, string path) {
        Transform tra = root.transform.Find(path);
        if (tra == null) Debug.Log(path + "not find");
        T t = tra.GetComponent<T>();
        return t;
    }
}
