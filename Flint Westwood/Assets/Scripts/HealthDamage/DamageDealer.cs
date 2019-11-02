using HealthDamage.Interfaces;
using UnityEngine;

namespace HealthDamage
{
	public class DamageDealer : MonoBehaviour
	{
		[SerializeField] int damage;
		// Start is called before the first frame update
		void Start()
		{
        
		}

		// Update is called once per frame
		void Update()
		{
        
		} 

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.GetComponent<IDamageable>() != null)
			{
				other.gameObject.GetComponent<IDamageable>().TakeDamage(1);
			}
		}
	}
}
