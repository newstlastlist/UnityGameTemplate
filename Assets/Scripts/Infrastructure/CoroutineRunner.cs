using Infrastructure;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
