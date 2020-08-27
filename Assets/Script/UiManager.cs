using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using  DG.Tweening;
public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private WolfManager catManager;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI allcatcountText;
    void Start()
    {
       catManager.catFollow.AddListener((x) => UpdateCatNumber(x));
      
    }

    private void Update()
    {
        allcatcountText.text = catManager.allMikataNum.ToString();
    }
    // Update is called once per frame

    void UpdateCatNumber(int num)
    {
        countText.transform.DOComplete();
        countText.transform.DOPunchScale(Vector3.one/3, .3f, 10, 1);
        countText.text = num.ToString();
    }
    
}
