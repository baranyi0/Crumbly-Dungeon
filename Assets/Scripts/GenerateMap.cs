using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public int length = 8;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject end;
    void Awake()
    {
        length = UnityEngine.Random.Range(19, 22);
        Generate();
    }

    private void Generate()
    {
        for (int i = 4; i < length; i++)
        {
            Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)], new Vector3(0, 0, i), new Quaternion(0, 0, 0, 0));
        }

    }
}
