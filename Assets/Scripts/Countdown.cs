using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] Text text;
    public bool counting = true;

    [SerializeField] Health hp;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(4.3f);

        for (int i = 20; i >= 0; i--)
        {
            if (counting && hp.HP > 0)
            {
                text.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
            if(i == 0)
            {
                hp.KillPlayer();
            }
        }
    }

}
