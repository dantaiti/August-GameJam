using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private UnityEngine.UI.Button _button;
    private GameObject aaa;
    
    public bool bug() => _button;//????????????????
    public bool kkk() => aaa; /// <su
    /// </summary>
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
