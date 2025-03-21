using UnityEngine;

public class CarMoving : MonoBehaviour
{
    [SerializeField] protected float speed = 27;

    private void Update()
    {
        transform.parent.Translate(Vector3.up * this.speed * Time.deltaTime);
    }
}
