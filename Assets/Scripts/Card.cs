using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Cards card;
    [SerializeField] Animation anim;
    bool grabbingCard;
    [SerializeField] GameObject cardObject;

    [SerializeField] Text cardName, cardDesc;
    [SerializeField] Image cardImage;

    int i = 0;

    Health health;

    PlaySound playSound;
    [SerializeField] AudioClip clip;

    [SerializeField]EnemyManager enemyManager;

    CameraShake cameraShake;

    private void Start()
    {
        health = GameObject.FindGameObjectWithTag("Scene").GetComponent<Health>();
        enemyManager = GameObject.FindGameObjectWithTag("Scene").GetComponent<EnemyManager>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        playSound = GetComponentInParent<PlaySound>();
        GetRandomCard();
    }

    private void SetupCard()
    {
        cardName.text = card.CardName;
        cardDesc.text = card.CardDescription;
        cardImage.sprite = card.CardImage;
        
        anim.Play("getCard");
    }

    private void Update()
    {
        if (grabbingCard)
        {
            this.transform.position = Input.mousePosition;
        }
    }

    bool TopHalf()
    {
        return Input.mousePosition.y > Screen.height / 2.5f;
    }

    public void HoverOverCard()
    {
        i = 0;
        cardObject.transform.SetAsLastSibling();
        if (!grabbingCard)
        {
            anim.Play("hover");
        }
    }
    public void HoverOff()
    {
        if (i == 0)
        {
            anim.Play("back");
            i++;
        }
    }
    public void GrabCard()
    {
        i++;
        grabbingCard = true;
    }

    public void ReleaseCard()
    {
        if(TopHalf() && card.isReshuffle)
        {
            PlayCard();
        }
        else if (TopHalf() && enemyManager.inFight)
        {
            PlayCard();
        }
        else
        {
            anim.Play("back");
            this.transform.localPosition = Vector3.zero;
            grabbingCard = false;
        }
    }

    public void GetRandomCard()
    {
        int i = UnityEngine.Random.Range(0, Deck.Instance.currentDeck.Count);
        card = Deck.Instance.currentDeck[i];

        SetupCard();
    }

    public void PlayCard()
    {
        if (!card.isReshuffle)
        {
            health.HP += card.Heal;
            enemyManager.enemy.enemyHealth -= (card.Attack) + (card.FireAttack * enemyManager.enemy.enemyFireWeakness) + (card.PoisonAttack * enemyManager.enemy.enemyPoisonWeakness) + (card.HolyAttack * enemyManager.enemy.enemyHolyWeakness);
        }

        playSound.PlaySoundVoid(card.playSound);
        this.transform.localPosition = Vector3.zero;
        grabbingCard = false;
        if (card.draw)
        {
            GetRandomCard();
        }
        else if (card.isReshuffle)
        {
            Deck.Instance.Reshuffle(0);
            Destroy(this.gameObject);
        }
        else
        {
            Deck.Instance.cardsInHand--;
            Destroy(this.gameObject);
        }

        if(card.isReshuffle == false)
        {
            cameraShake.StartCoroutine(cameraShake.Shake(0.13f, 1.2f));
        }
    }
}