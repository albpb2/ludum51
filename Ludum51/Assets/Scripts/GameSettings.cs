using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static GameSettings instance;

    public bool HardcoreMode { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}