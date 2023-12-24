using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedScaleGameObject : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float scaleMax = 1.3f;
    [SerializeField] private float scaleMin = 1f;

    private float _time = 0f;
    private bool _ascending = true;

    private void Update()
    {
        _time += Time.deltaTime * (_ascending ? 1 : -1);
        if (_time > duration)
        {
            _ascending = !_ascending;
        }
        else if (_time < 0)
        {
            _ascending = !_ascending;
        }

        var scale = Mathf.Lerp(scaleMin, scaleMax, animationCurve.Evaluate(_time / duration));
        transform.localScale = new Vector3(scale, scale, scale);
    }
}