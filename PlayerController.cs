using UnityEngine;

public class PlayerController : MonoBehaviour // Controls the Player.
{
	// Controller has a reference of Model.
	private PlayerModel _model;
	
	// [Method] Awake()
	private void Awake()
	{
		// [Temp] Supposes that there is a DataManger, which has data of Player.
		_model = DataManager.Instance.GetPlayerData("PlayerName"); // Gets the correct Model from DataManager.
		GameManager.Instance.PlayerModel = _model; // Set the reference of Model of GameManager.
	}
	
	// [Method] OnTriggerEnter()
	private void OnTriggerEnter(Collision other)
	{
		// [Temp] Supposes that there is a Enemy component, which has an ATK field, etcs.
		if (other.gameObject.TryGetComponent<Enemy>(out Enemy attacker))
		{
			int damage = attacker.GetATK(); // Gets the value of ATK from Enemy.
			_model.DamageHealthPoint(damage); // Changes values of Model.
		}
	}
}