using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


[System.Serializable] public class SubCharaEvent : UnityEvent<int> { }
public class WolfManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<WolfNav> allmikata = new List<WolfNav>();
    public int allMikataNum;
   [SerializeField] private Transform follow;
    [SerializeField] private WolfContoroller contoroller;
    [SerializeField] private float selectionRadius = 1;
    [FormerlySerializedAs("SubCharaPrefab")]
    [Header("Spawning")]
    [SerializeField] private WolfNav subCharaPrefab = default;
    
    [Header("Events")]
    public SubCharaEvent catFollow;

    private int _contorolledNum=0;

    private GameObject _player;
    

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
      
       WolfSpawner[] spawners = FindObjectsOfType(typeof(WolfSpawner)) as WolfSpawner[];
       foreach (WolfSpawner spawner in spawners)
       {
           spawner.SpawnPikmin(subCharaPrefab, ref allmikata);
       }

       
    }

    // Update is called once per frame
    void Update()
    {
        allMikataNum = allmikata.Count;
       
        if (Input.GetKeyDown(KeyCode.Space))
            Time.timeScale = Time.timeScale == 1 ? .2f : 1;

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);


        if (Input.GetMouseButton(1))
        {
            foreach ( WolfNav wolf in allmikata)
            {
                if(Vector3.Distance(wolf.transform.position, contoroller.hitPoint) < selectionRadius)
                {
                    

                    if (wolf.state != WolfNav.MikataState.Follow)
                    {
                        
                        _contorolledNum++;
                        catFollow.Invoke(_contorolledNum);
                        wolf.SetFollowPoint(follow.position);
                    }
                    
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (WolfNav wolf in allmikata)
            {
                if (wolf.state == WolfNav.MikataState.Follow && Vector3.Distance(wolf.transform.position, _player.transform.position) < 10)
                {
                    //wolf.agent.enabled = false;
                    wolf.SetMovePoint(contoroller.hitPoint);
                    
                    _contorolledNum--;
                    catFollow.Invoke(_contorolledNum);
                    break;
                    

                }
            }
        }
       
    }

  
}
