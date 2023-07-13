using UnityEngine;
using Zenject;

public class DebugClassB : MonoBehaviour
{
    private DebugClassA _classA;
    [Inject]
    public void Construct(DebugClassA classA)
    {
        _classA = classA;
        print("AAAAA");
    }

    private void Start()
    {
        print(_classA == null);
    }
}
