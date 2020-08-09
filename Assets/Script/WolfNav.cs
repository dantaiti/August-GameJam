using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.AI;
using Random = System.Random;

public class WolfNav : MonoBehaviour
{
    public MikataState state = default;

    private NavMeshAgent _agent;
    
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
    
    public enum MikataState {
        Idle, Follow, Interact
    };
    void Start () {
        _animator = GetComponentInChildren<Animator> ();
        _agent = GetComponent <NavMeshAgent> ();
        MikataState state = MikataState.Idle;


    }

    private void Update()
    {
        
        
        
        if (state == MikataState.Follow)
        {
            _agent.SetDestination(target.transform.position);
        
            //　到着している時
            if(_agent.remainingDistance < arrivedDistance) {
                //agent.Stop()
                _agent.isStopped = true;
                _animator.SetFloat("Speed", _agent.desiredVelocity.magnitude);
                //　到着していない時で追いかけ出す距離になったら
            } else if(_agent.remainingDistance > followDistance) {
                //agent.Resume();
                //　Unity5.6バージョン以降の再開
                _agent.isStopped = false;
                _animator.SetFloat("Speed", _agent.desiredVelocity.magnitude);
            }
        }
      
    }
    
    
    
    
    
}
