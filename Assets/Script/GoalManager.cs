using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GoalManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private List<GameObject> catlist = new List<GameObject>();
   private Animator _doorAnim;
    void Start()
    {
        _doorAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (catlist.Count >= 5)
        {
            _doorAnim.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("aaaa");
        if (other.gameObject.CompareTag("SubChara") && !catlist.Contains(other.gameObject))
            catlist.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SubChara") && catlist.Contains(other.gameObject))
            catlist.Remove(other.gameObject);
    }
}
