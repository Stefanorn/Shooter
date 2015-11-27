using UnityEngine;
using System.Collections;

public class SetSelfInActive : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("SetInActive", 1f);
    }
    void SetInActive()
    {
        gameObject.SetActive(false);
    }
}
