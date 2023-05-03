using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "", order = 1)]
public class Cards : ScriptableObject
{
    public string CardName;

    [TextArea]public string CardDescription;

    public Sprite CardImage;

    public int Attack;

    public int FireAttack;

    public int PoisonAttack;

    public int HolyAttack;

    public int Heal;

    public AudioClip playSound;

    public bool draw = false;

    public bool isReshuffle = false;
}
