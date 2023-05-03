using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public bool inFight = false;

    public Enemy enemy;

    [SerializeField] GameObject enemyHealthbarUi;

    [SerializeField] Text enemyName;

    [SerializeField] Slider enemyHealthBar;

    [SerializeField] Text enemyWeakness;

    [SerializeField] GameObject darkUi;

    [SerializeField] MouseLook mouseLook;

    [SerializeField] Animator anim;

    [SerializeField] Animation fadeAnim;
    
    private bool playOnce = false;

    public void KillEnemy()
    {
        enemy.enemyHealth = -100;
    }

    public void Setup()
    {
        playOnce = false;
        enemyWeakness.text = "Weakness: " + enemy.weakness;
        enemyName.text = enemy.enemyName;
        enemyHealthBar.maxValue = enemy.enemyHealth;
    }
    private void Update()
    {
        if (inFight)
        {
            mouseLook.running = false;
            anim.enabled = false;

            enemyHealthbarUi.SetActive(true);
            enemyHealthBar.value = enemy.enemyHealth;
            darkUi.SetActive(true);
            if (enemy.enemyHealth <= 0)
            {
                StartCoroutine(FadeBack());
            }
        }
        else
        {
            mouseLook.running = true;
            anim.enabled = true;
            enemyHealthbarUi.SetActive(false);
        }
    }

    private IEnumerator FadeBack()
    {
        if (!playOnce)
        {
            playOnce = true;
            Deck.Instance.Reshuffle(1);
            fadeAnim.Play("fadeOut");
            yield return new WaitForSeconds(0.15f);
            inFight = false;
            enemy = null;
            yield return new WaitForSeconds(0.55f);
            darkUi.SetActive(false);
        }
    }
}
