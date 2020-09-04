using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using  DG.Tweening;

public class GoalManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private List<GameObject> catlist = new List<GameObject>();
   private Animator _doorAnim;
   [SerializeField] private int needNum;
  [SerializeField] private TextMeshProUGUI needNumText;
  [SerializeField] private TextMeshProUGUI currentNumText;  
  [SerializeField] private TextMeshProUGUI needNumText2;
  [SerializeField] private TextMeshProUGUI currentNumText2;
  

  void Start()
  {
      currentNumText.text = catlist.Count.ToString();
        _doorAnim = GetComponentInChildren<Animator>();
        needNumText.text = needNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        needNumText.gameObject.SetActive(false);
        currentNumText.gameObject.SetActive(false);
        
        if (catlist.Count > 0)
        {
            needNumText.gameObject.SetActive(true);
            currentNumText.gameObject.SetActive(true);
            

        }
        
        if (catlist.Count >= needNum)
        {
            _doorAnim.SetBool("Open", true);
        }
        else
        {
            _doorAnim.SetBool("Open", false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("SubChara") && !catlist.Contains(other.gameObject))
            catlist.Add(other.gameObject);
        
        currentNumText.transform.DOComplete();
        currentNumText.transform.DOPunchScale(Vector3.one/3, .3f, 10, 1);
        currentNumText.text = catlist.Count.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SubChara") && catlist.Contains(other.gameObject))
            catlist.Remove(other.gameObject);
        
        currentNumText.transform.DOComplete();
        currentNumText.transform.DOPunchScale(Vector3.one/3, .3f, 10, 1);
        currentNumText.text = catlist.Count.ToString();
    }
}
