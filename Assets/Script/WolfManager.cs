using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class WolfManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<WolfNav> allmikata = new List<WolfNav>();
    private int _controlledWolf = 0;
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
        if (Input.GetKeyDown(KeyCode.Space))
            Time.timeScale = Time.timeScale == 1 ? .2f : 1;

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);


        if (Input.GetMouseButton(1))
        {
            foreach ( WolfNav wolf in allmikata)
            {
                if(Vector3.Distance(wolf.transform.position, contoroller.target.position) < selectionRadius)
                {
                    wolf.state = WolfNav.MikataState.Follow;

                }
            }
        }
        //Debug.Log(_wolf.gameObject.name);
       /*if(Vector3.Distance(_wolf.transform.position, contoroller.target.position) < selectionRadius)
       {
           _wolf.GetComponent<WolfNav>().state = WolfNav.MikataState.Follow;
           
       }*/
       
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
