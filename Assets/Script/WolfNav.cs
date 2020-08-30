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
     private GameObject _target;

    private Animator _animator;

//　到着したとする距離
    [SerializeField] private float arrivedDistance = 1.5f;

//　追いかけ始める距離
    [SerializeField] private float followDistance = 1f;
    private int _ram;
    private Vector3 _distination;
    public int dashSpeed;
    public bool isGrounded;
    private CharacterController controller;
    private float verticalVel;
    private Vector3 moveVector;
    public SubCharaEvent onStartFollow;
   
   



    public enum MikataState
    {
        Idle,
        Follow,
        Start,
    };

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        MikataState state = MikataState.Idle;
        _player = GameObject.FindWithTag("Player");
        _target = GameObject.Find("followPoint");
        state = MikataState.Start; 
       

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

        if (state == MikataState.Follow)
        {
            _distination = _target.transform.position;
        }
        Debug.Log(_distination);
        moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        //controller.Move(moveVector);

        if (state == MikataState.Follow || state == MikataState.Idle)
        {


            agent.SetDestination(_distination);

            //　到着している時
            if (agent.remainingDistance < arrivedDistance)
            {
                //agent.Stop()
                agent.isStopped = true;
                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
                //transform.LookAt(_player.transform.position);
                //　到着していない時で追いかけ出す距離になったら
            }
            else if (agent.remainingDistance > followDistance)
            {
                //agent.Resume();
                //　Unity5.6バージョン以降の再開
                agent.isStopped = false;

                _animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
            }
        }
    }
    
    public void SetFollowPoint(Vector3 point)
    {
        //_distination = point;
        onStartFollow.Invoke(0);
        state = MikataState.Follow;
    }
    
    public void SetMovePoint(Vector3 movepoint)
    {
        _distination = movepoint;
        state = MikataState.Idle;
    }
    
   
    
  
}
