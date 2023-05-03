using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int cardsInHand = 4;

    [SerializeField]GameObject stackOfCards;

    public static Deck Instance;

    public List<Cards> currentDeck = new List<Cards>();

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(cardsInHand <= 0)
        {
            Reshuffle(1);
        }
    }

    public void Reshuffle(float t)
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject, t);
        }
        var cards = Instantiate(stackOfCards, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        cards.transform.SetParent(gameObject.transform);
        cards.transform.localScale = Vector3.one;
        cardsInHand = 4;
    }
}
