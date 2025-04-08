using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] protected float inputVertical = 0;
    [SerializeField] protected float inputHorizontal = 0;

    public float InputVertical => inputVertical;

    void Update()
    {
        this.GetInputs();
    }

    protected virtual void GetInputs()
    {
        this.inputVertical = Input.GetAxis("Vertical");
        this.inputHorizontal = Input.GetAxis("Horizontal");
    }

    public virtual float GetInputVertical()
    {
        return this.inputVertical;
    }
}
