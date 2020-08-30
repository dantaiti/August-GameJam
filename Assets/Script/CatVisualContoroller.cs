using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;

public class CatVisualContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    private WolfNav _cat;

     void Awake()
    {
        _cat = GetComponent<WolfNav>();
        _cat.onStartFollow.AddListener((x) => OnStartFollow(x));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartFollow(int num)
    {
        transform.DOJump(transform.position, .4f, 1, .3f);
        transform.DOPunchScale(-Vector3.up / 2, .3f, 10, 1).SetDelay(0f);
        
    }
}
