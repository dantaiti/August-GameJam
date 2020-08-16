using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.AI;
using UnityEngine.Serialization;
using Random = System.Random;

public class WolfNav : MonoBehaviour
{
    public MikataState state = default;

    public NavMeshAgent agent;
    
// 追いかけるキャラクター
    [SerializeField]
    private GameObject target;
    private Animator _animator;
//　到着したとする距離
    [SerializeField]
    private float arrivedDistance = 1.5f;
//　追いかけ始める距離
    [SerializeField]
    private float followDistance = 1f;

    private int _ram;
    private Vector3 _distination;
    public int dashSpeed;
    public enum MikataState {
        Idle, Follow, Interact
    };
    void Start () {
        _animator = GetComponentInChildren<Animator> ();
        agent = GetComponent <NavMeshAgent> ();
        MikataState state = MikataState.Idle;


    }

    private void Update()
    {
        
        
        
        if (state == MikataState.Follow)
        {
            target = GameObject.Find("followPoint");
            
            agent.SetDestination(target.transform.position);
        
            //　到着している時
            if(agent.remainingDistance < arrivedDistance) {
                //agent.Stop()
                agent.isStopped = true;
                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
                //　到着していない時で追いかけ出す距離になったら
            } else if(agent.remainingDistance > followDistance) {
                //agent.Resume();
                //　Unity5.6バージョン以降の再開
                agent.isStopped = false;
                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
            }
        }

        if (state == MikataState.Interact)
        {
            //agent.isStopped = false;
            agent.speed = dashSpeed;
            
            agent.SetDestination(_distination);
            if(agent.remainingDistance < arrivedDistance) {
                //agent.Stop()
                agent.isStopped = true;
                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
                //　到着していない時で追いかけ出す距離になったら
            } else if(agent.remainingDistance > followDistance) {
                //agent.Resume();
                //　Unity5.6バージョン以降の再開
                agent.isStopped = false;
                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
            }
        }
       
        
        
      
    }

    public void SetDestination(Vector3 dist)
    {

        _distination= dist;
    }

  
}
