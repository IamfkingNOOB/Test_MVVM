using UnityEngine;

public class Enemy : MonoBehaviour // [Temp] Enemy Class
{
	[SerializeField] private int _atk;

	public int GetATK()
	{
		return _atk;
	}
}