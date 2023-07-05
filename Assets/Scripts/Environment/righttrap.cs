using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class righttrap : MonoBehaviour
{
    public Transform firstTransform;
    public Transform secondTransform;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(secondTransform.position, time)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
}
