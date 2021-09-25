using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject Destination { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Destination = GameObject.Find("Destination");
    }
}
