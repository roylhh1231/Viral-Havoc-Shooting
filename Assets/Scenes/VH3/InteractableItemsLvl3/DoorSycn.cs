using UnityEngine;

public class DoorSync : MonoBehaviour
{
    public Transform doorModel; // 门的可见模型
    public BoxCollider boxCollider; // 门的Box Collider

    // 更新门模型的位置和旋转
    public void SyncDoorModel()
    {
        doorModel.position = boxCollider.transform.position;
        doorModel.rotation = boxCollider.transform.rotation;
    }
}
