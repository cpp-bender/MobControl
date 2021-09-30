using UnityEngine;

public interface IEntity
{
    void Move();
    void SetScale(GameObject gameObject, Vector3 scale);
    bool CanMove { get; set; }
}
