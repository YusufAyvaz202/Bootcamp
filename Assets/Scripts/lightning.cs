using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public int abc;
    public GameObject[] lights=new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("nisa", 0f,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator light()
    {
        yield return new WaitForSeconds(0f);
        int index = Random.Range(0, lights.Length);
        abc = index;
        lights[index].SetActive(true);
        StartCoroutine(activefalse(abc));
        foreach (var item in lights)
        {
            if (item.gameObject != lights[index])
            {
                item.SetActive(false);
            }
        }
    }
    public IEnumerator activefalse(int index)
    {
        yield return new WaitForSeconds(1.8f);
        lights[index].SetActive(false);
    }
    public void nisa()
    {
        StartCoroutine(light());
    }
}
