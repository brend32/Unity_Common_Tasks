using UnityEngine;

namespace SOLID
{
    public class HandWeapon : MonoBehaviour
    {
        public void Equip()
        {
            gameObject.SetActive(true);
        }

        public void Hit()
        {
            Debug.Log("Hand attack");
        }
    }
}