using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class CatAudioContoroller : MonoBehaviour
{
    private WolfNav _cat;

    private AudioSource _audioSource;
    [Header("Sounds")]
    public List<AudioClip> noticeSound = new List<AudioClip>();
    // Start is called before the first frame update
    void Awake()
    {
        //_cat = GetComponent<WolfNav>();
        _audioSource = GetComponent<AudioSource>();
        //_cat.onStartFollow.AddListener((x) => FollowSoundPlay(x));
    }
    // Update is called once per frame
   public void FollowSoundPlay(int n)
    {
        //int i = Random.Range(0, 2);
        
        _audioSource.PlayOneShot(noticeSound[n]);
    }
}
