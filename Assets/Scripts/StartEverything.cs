using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartEverything : MonoBehaviour
{
    [SerializeField] GameObject startSounds;
    [SerializeField] GameObject text;
    [SerializeField] Image img;
    bool playing;
    void Update()
    {
        if(Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            if (!playing)
            {
                StartCoroutine("Init");
            }
        }
    }

    IEnumerator Init()
    {
        
        playing = true;
        img.enabled = false;
        startSounds.SetActive(true);
        yield return new WaitForSeconds(8f);
        text.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
