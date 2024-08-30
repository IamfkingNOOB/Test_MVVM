public class GameManager : Singleton<GameManager> // Manages the main system of game as Singleton.
{
	// Has an instance of Player Model for Views to use a same reference.
	public PlayerModel PlayerModel { get; set; }
}