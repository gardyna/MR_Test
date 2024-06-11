using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum CatapultAnimation
{
    Charge,
    Release
}
public class CatapultAnimator : MonoBehaviour
{
    private static CatapultAnimator Instance;
    
    [Header("Catapult Parts")]
    [SerializeField] private Transform spoon;
    [SerializeField] private Transform lever;
    [SerializeField] private Transform bigSprocket;
    [SerializeField] private Transform smallSprocket;
    [SerializeField] private Transform tensionRelease;
    
    private Vector3 spoonCache;
    private Vector3 leverCache;
    private Vector3 bigSprocketCache;
    private Vector3 smallSprocketCache;
    
    private Tweener catapultTweener;
    private Sequence catapultSequence;
    private int animationIterations = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        spoonCache = spoon.eulerAngles;
        leverCache = lever.eulerAngles;
        bigSprocketCache = bigSprocket.eulerAngles;
        smallSprocketCache = smallSprocket.eulerAngles;
    }

    public void PlayAnimation(CatapultAnimation animation)
    {
        switch (animation)
        {
            case CatapultAnimation.Charge: LeverSequence();
                break;
            case CatapultAnimation.Release : ReleaseTension();
                break;
        }
    }

    private void LeverSequence()
    {
        PullLever();
        TurnSprocket();
        ChargeSpoonTension();
        
    }

    private void PullLever()
    {
        lever.DORotate(new Vector3(lever.transform.localEulerAngles.x - 25f, lever.transform.localEulerAngles.y, lever.transform.localEulerAngles.z), 0.85f)
            .SetEase(Ease.OutSine);
        
        smallSprocket.DORotate(new Vector3(smallSprocket.transform.localEulerAngles.x - 20f, -90f, -90f), 0.95f)
            .SetEase(Ease.OutSine)
            .OnComplete(() => ResetLever());
    }

    private void ResetLever()
    {
        lever.DORotate(new Vector3(leverCache.x, lever.transform.localEulerAngles.y, lever.transform.localEulerAngles.z), 0.25f)
            .SetEase(Ease.OutSine);
        
        smallSprocket.DORotate(new Vector3(smallSprocketCache.x, -90f, -90f), 0.25f)
            .SetEase(Ease.OutSine);
    }

    private void TurnSprocket()
    {
        bigSprocket.DORotate(new Vector3(bigSprocket.transform.localEulerAngles.x - 20f, -90f, -90f), 1.05f)
            .SetEase(Ease.OutSine)
            .SetDelay(0.1f);
    }

    private void ChargeSpoonTension()
    {
        spoon.DORotate(new Vector3(spoon.transform.localEulerAngles.x + 28f, 90f, 90f), 1.25f)
            .SetEase(Ease.OutBack)
            .SetDelay(0.2f);
    }
    

    private void ReleaseTension()
    {
        tensionRelease.DORotate(new Vector3(12f, -90f, -90f), 0.1f).SetEase(Ease.OutBack);
        spoon.DORotate(spoonCache, 0.25f).SetEase(Ease.OutBounce);
        bigSprocket.DORotate(new Vector3(bigSprocketCache.x, bigSprocket.localEulerAngles.y, bigSprocket.localEulerAngles.z), 0.25f);
        lever.DORotate(leverCache, 0.30f).SetEase(Ease.OutBounce);
        smallSprocket.DORotate(new Vector3(smallSprocketCache.x, smallSprocket.localEulerAngles.y, smallSprocket.localEulerAngles.z), 0.25f);
    }
}