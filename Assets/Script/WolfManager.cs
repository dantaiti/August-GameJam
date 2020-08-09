using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WolfManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<GameObject> mikata;
    [SerializeField] private WolfContoroller contoroller;
    [SerializeField] private float selectionRadius = 1;
    private GameObject _wolf;

    void Start()
    {
       _wolf = GameObject.Find("SubChara");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_wolf.gameObject.name);
       if(Vector3.Distance(_wolf.transform.position, contoroller.target.position) < selectionRadius)
       {
           _wolf.GetComponent<WolfNav>().state = WolfNav.MikataState.Follow;
       }
    }
    
    
    
    
    
}
