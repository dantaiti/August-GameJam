using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLooker : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform _rt;
    void Start()
    {
        _rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rt.LookAt(Camera.main.transform);
        _rt.Rotate(new Vector3(0,-180f,0f));
    }
}
