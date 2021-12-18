using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerPrime : MonoBehaviour
    {
        private float _maximumHealth;
        
        [SerializeField] private float maxHealth;
        [SerializeField] private UnityEvent<float> healthChanged;

        private void Start()
        {
            healthChanged?.Invoke(maxHealth);
            _maximumHealth = maxHealth;
        }
        
        public void AddHealth(float healthCount)
        {
            if (maxHealth + healthCount > _maximumHealth)
                maxHealth = _maximumHealth;
            else
            {
                maxHealth += healthCount;
            }
        
            healthChanged?.Invoke(maxHealth);
        }
    
        public void TakeDamage(float damage)
        {
            maxHealth -= damage;
            healthChanged?.Invoke(maxHealth);
        
            if(maxHealth <= 0)
                PlayerDie();
        }

        private void PlayerDie()
        {
            gameObject.SetActive(false);
        }
    }
}
