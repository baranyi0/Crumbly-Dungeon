using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] Countdown countdown;
    [SerializeField] Animation[] anims;
    [SerializeField] Health hp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hp.cantDie = true;
            foreach (var item in anims)
            {
                item.Play("slowFadeOut");
            }
            countdown.counting = false;
            anim.Play("gateOpen");
        }
    }
}
