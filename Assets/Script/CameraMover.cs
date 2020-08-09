using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMover : MonoBehaviour
{
    private GameObject _playerob;
    private Vector3 _offset;
    private Vector3 _targetPos;
    private float  h2, v2;
    // Start is called before the first frame update
    void Start()
    {
        _playerob = GameObject.FindWithTag("Player");
        
        _offset = _playerob.transform.position - this.transform.position;
        _targetPos = _playerob.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _targetPos - _offset;
        _targetPos = _playerob.transform.position;

        h2 = Input.GetAxis("Horizontal2");
        v2 = Input.GetAxis("Vertical2");
        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(_targetPos, Vector3.up, h2 * Time.deltaTime * 200f);
        // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
      //  transform.RotateAround(_targetPos, transform.right, v2 * Time.deltaTime * 200f);
    }
        
    
}
