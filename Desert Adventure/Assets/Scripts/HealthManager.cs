using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

	public enum OnDeathAction
	{
		ReloadLevel,
		DoNothing
	}

	public float HealthPoints = 10.0f;

	public int NumberOfLives = 2;
	public bool IsAlive = true;	

	public GameObject ExplosionPrefab;

	public OnDeathAction OnAllLivesGone = OnDeathAction.ReloadLevel;

	private Vector3 _respawnPosition;
	private Quaternion _respawnRotation;
	private float _respawnHealthPoints;

	private Transform _transform;
	private Rigidbody _rigidbody;

	void Awake()
	{
		_transform = transform;
		_rigidbody = GetComponent<Rigidbody>();

		_respawnPosition = _transform.position;
		_respawnRotation = _transform.rotation;
		_respawnHealthPoints = HealthPoints;
	}
		
	void Update () 
	{
		if (HealthPoints <= 0)
		{			
			NumberOfLives--;			

			if (ExplosionPrefab != null)
			{
				Instantiate (ExplosionPrefab, _transform.position, Quaternion.identity);
			}

			if (NumberOfLives > 0)
			{
				_transform.position = _respawnPosition;
				_transform.rotation = _respawnRotation;
				HealthPoints = _respawnHealthPoints;

				_rigidbody.velocity = Vector3.zero;
			} else
			{
				IsAlive = false;

				switch(OnAllLivesGone)
				{
					case OnDeathAction.ReloadLevel:
						SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
						break;
					case OnDeathAction.DoNothing:
						// do nothing, death must be handled in another way elsewhere
						break;
				}
				Destroy(gameObject);
			}
		}
	}

	public void ApplyDamage(float amount)
	{	
		HealthPoints -= amount;	
	}

	public void ApplyHeal(float amount)
	{
		HealthPoints += amount;
	}

	public void ApplyBonusLife(int amount)
	{
		NumberOfLives += amount;
	}

	public void UpdateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
	{
		_respawnPosition = newRespawnPosition;
		_respawnRotation = newRespawnRotation;
	}
}
