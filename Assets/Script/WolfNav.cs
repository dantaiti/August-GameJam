using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using  UnityEngine.AI;
using UnityEngine.Serialization;
using Random = System.Random;

public class WolfNav : MonoBehaviour
{
    public MikataState state = default;

    public NavMeshAgent agent;
    private GameObject _player;
    
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
    public bool isGrounded;
    private CharacterController controller;
    private float verticalVel;
    private Vector3 moveVector;
    public enum MikataState {
        Idle, Follow, Interact
    };
    void Start () {
        controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator> ();
        agent = GetComponent <NavMeshAgent> ();
        MikataState state = MikataState.Idle;
        _player = GameObject.FindWithTag("Player");
        


    }

    private void Update()
    {
        
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 1;
        }
        moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        //controller.Move(moveVector);

        
        if (state == MikataState.Follow)
        {
            target = GameObject.Find("followPoint");
            
            agent.SetDestination(target.transform.position);
        
            //　到着している時
            if(agent.remainingDistance < arrivedDistance) {
                //agent.Stop()
                agent.isStopped = true;
                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
                //transform.LookAt(_player.transform.position);
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
