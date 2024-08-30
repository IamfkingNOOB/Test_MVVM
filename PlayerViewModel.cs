using System.ComponentModel;

public class PlayerViewModel : INotifyPropertyChanged // Binds PlayerView to PlayerModel.
{
	#region [Fields]
	
	// View Model has an instance or a reference of Model.
	private PlayerModel _model;

	// [Event] Property Changed Event; will invoke when data of Model changes.
	public event PropertyChangedEventHandler PropertyChanged;

	#endregion [Fields]
	
	#region [Methods]

	// [Constructor] Initializes values of the Model's data.
	public PlayerViewModel()
	{
		_model = GameManager.Instance.PlayerModel; // Gets the reference of Model from GameManager.
		_model.PropertyChanged += OnPropertyChanged; // Adds listeners to Property Changed Event.
	}
	
	// [Method] Invokes Property Changed Event.
	private void InvokePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	
	// [Method] Callback of Model's Property Changed Event
	private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		BindModelProperty(e.PropertyName); // Binds Properties of Model with View Model.
	}
	
	// [Method] Binds Properties of Model with View Model.
	private void BindModelProperty(string propertyName)
	{
		switch (propertyName)
		{
			case nameof(_model.CurrentHealthPoint):
				HealthPoint = _model.CurrentHealthPoint;
				break;
			case nameof(_model.CurrentSkillPoint):
				SkillPoint = _model.CurrentSkillPoint;
				break;
		}
	}
	
	// [Method] Removes listeners of Model's Property Changed Event.
	public void RemoveListeners()
	{
		_model.PropertyChanged -= OnPropertyChanged;
	}
	
	#endregion [Methods]

	#region [Properties / Methods] Binds Data from Model.
	
	// [Property] HP
	public int HealthPoint
	{
		get => _model.CurrentHealthPoint;
		private set => InvokePropertyChanged(nameof(HealthPoint));
	}
	
	// [Property] SP
	public int SkillPoint
	{
		get => _model.CurrentSkillPoint;
		private set => InvokePropertyChanged(nameof(SkillPoint));
	}
	
	// [Method] Heals HP.
	public void HealHealthPoint(int amount)
	{
		_model.HealHealthPoint(amount);
	}
	
	// [Method] Damages HP.
	public void DamageHealthPoint(int amount)
	{
		_model.DamageHealthPoint(amount);
	}
	
	// [Method] Heals SP.
	public void HealSkillPoint(int amount)
	{
		_model.HealSkillPoint(amount);
	}
	
	// [Method] Damages SP.
	public void DamageSkillPoint(int amount)
	{
		_model.DamageHealthPoint(amount);
	}
	
	#endregion [Properties / Methods] Binds Data from Model.
}