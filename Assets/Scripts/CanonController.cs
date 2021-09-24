using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] CanonControllerData canonData;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        float canonPosX = transform.position.x + canonData.MoveSpeed * horizontalInput * Time.deltaTime;
        canonPosX = Mathf.Clamp(canonPosX, canonData.LowerThreshold, canonData.UpperThreshold);
        transform.position = new Vector3(canonPosX, transform.position.y, transform.position.z);
    }
}
