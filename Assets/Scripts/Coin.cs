using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _appearAnimationName = "CoinAppear";
    [SerializeField]
    private string _disappearAnimationName = "CoinDisappear";
    [SerializeField]
    private float _secondsToDisappear = 2f;
    private Coroutine _appearCoroutine;
    private void OnEnable()
    {
        _appearCoroutine = StartCoroutine(_appearCoroutine());
    }
    privateIEnumerator Appear()
    {
        _animator.Play(_appearAnimationName);
        yield return new WaitForSeconds(_secondToDisappear);
        StartCoroutine(_disappearAnimationName());
    }
    public void Collect()
    {
        _secondsToDisappear();
        StartCoroutine(Disappear());
    }
    private IEnumerator Disappear()
    {
        _animator.Play(_disappearAnimationName);
        yield return new WaitForSeconds(_appearAnimationName.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
    private void Stop()
    {
        if (_appearCoroutine != null)
        {
            StopCoroutine(_appearCoroutine);
            _appearCoroutine = null;
        }
    }
}
