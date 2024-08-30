using System.Collections.Generic;

public class DataManager : Singleton<DataManager> // [Temp] Manages all data, as Singleton.
{
	private Dictionary<string, PlayerModel> _playerDictionary;

	public PlayerModel GetPlayerData(string playerName)
	{
		return _playerDictionary.GetValueOrDefault(playerName);
	}
}