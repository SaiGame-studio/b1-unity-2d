using UnityEngine;

public class SaiBehaviour : MonoBehaviour
{
    protected void Awake()
    {
        this.LoadComponents();
    }

    protected void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //for override
    }
}
