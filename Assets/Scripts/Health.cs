using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int HP = 5;
    [SerializeField]Text text;

    [SerializeField] GameObject hurtUI;
    [SerializeField] CameraShake cameraShake;

    [SerializeField] MouseLook mouseLook;
    [SerializeField] Animator animRun;
    [SerializeField] Animation death;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] GameObject player, deathCam, cards, uiHP, uiCount;
    bool doOnce;
    public bool cantDie;
    private void Update()
    {
        if(HP > 5)
        {
            HP = 5;
        }
        text.text = HP.ToString();
        if (HP <= 0)
        {
            if (!doOnce)
            {
                KillPlayer();
            }
        }
    }

    public void KillPlayer()
    {
        if(cantDie == false)
        {
            HP = 0;
            doOnce = true;
            if (enemyManager.enemy != null)
            {

                enemyManager.KillEnemy();
            }
            cards.SetActive(false);
            deathCam.SetActive(true);
            player.SetActive(false);
            uiHP.SetActive(false);
            uiCount.SetActive(false);
        }
    }

    public void HurtPlayer(int dmg)
    {
        hurtUI.SetActive(true);
        HP -= dmg;
        cameraShake.StartCoroutine(cameraShake.Shake(0.11f, 0.7f));
    }
}
