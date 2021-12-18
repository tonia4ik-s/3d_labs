using UnityEngine;

namespace Player
{
    public class PlayerRotate : MonoBehaviour
    {
        public void Rotate(Vector3 rotation)
        {
            transform.Rotate(rotation);
        }
    }
}
