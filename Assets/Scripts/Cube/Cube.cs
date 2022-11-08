using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    public Animator _animator;
    public float Speed { get; set; }
    public float Distance { get; set; }
    public float LifeTime { get { return Distance / Speed; } }

    private const string DIE = "Die";
    private const string RUN = "Run";
    private const string DISABLE = "Disable";

    public void Init(float speed, float distance, Vector3 newPosition)
    {
        Speed = speed;
        Distance = distance;
        transform.position = newPosition;
    }
    public void Move()
    {
        PlayRunAnim();
        transform.DOMoveZ(Distance, LifeTime).OnComplete(() => PlayDieAnim());
    }

    private void PlayRunAnim()
    {
        _animator.StopPlayback();
        _animator.CrossFade(RUN, 0.05f);
    }

    private void PlayDieAnim()
    {
        _animator.StopPlayback();
        _animator.CrossFade(DIE, 0.05f);
        RuntimeAnimatorController ac = _animator.runtimeAnimatorController;
        float clipDuration = 0;
        for (int i = 0; i < ac.animationClips.Length; i++)                 
        {
            if (ac.animationClips[i].name == DIE)     
            {
                clipDuration = ac.animationClips[i].length;
            }
        }
        Invoke(DISABLE, clipDuration);
    }

    private void Disable()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName(DIE))
            gameObject.SetActive(false);
    }
}