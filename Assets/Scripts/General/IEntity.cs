using UnityEngine;

public interface IEntity
{
    void Move();
    void SetScale(GameObject gameObject, Vector3 scale);
    void ResetVelocityTo(Vector3 newVelocity);
    bool CanMove { get; set; }
}
