using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] protected float inputVertical = 0;
    [SerializeField] protected float inputHorizontal = 0;

    void Update()
    {
        this.GetInputs();
        
    }

    protected virtual void GetInputs()
    {
        this.inputVertical = Input.GetAxis("Vertical");
        this.inputHorizontal = Input.GetAxis("Horizontal");
    }
}
