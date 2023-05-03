using System.Collections;
using UnityEngine;

public class Next : MonoBehaviour
{
    [SerializeField] GameObject[] order;
    [SerializeField] int i = 0;
    [SerializeField] GameObject prev;
    bool playing;
    [SerializeField] float waitTime = 1f;

    private void Start()
    {
        StartCoroutine(Load(order[0]));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playing && i < order.Length - 1)
        {
            order[i].SetActive(false);

            i++;
            StartCoroutine(Load(order[i]));
        }
    }

    IEnumerator Load(GameObject g)
    {
        playing = true;
        yield return new WaitForSeconds(waitTime);
        g.SetActive(true);
        playing = false;
    }
}