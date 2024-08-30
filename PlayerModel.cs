using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerModel : INotifyPropertyChanged // Defines the data of Player.
{
	// Model doesn't have any instances or references of View & View Model.
	
	#region [Fields]
	
	// [Field] Data of Player
	private readonly int _maxHealthPoint; // Max HP
	private readonly int _maxSkillPoint; // Max SP
	
	private int _currentHealthPoint; // HP
	private int _currentSkillPoint; // SP
	
	public int CurrentHealthPoint // HP Property
	{
		get => _currentHealthPoint;
		set => SetField(ref _currentHealthPoint, value, nameof(CurrentHealthPoint));
	}
	
	public int CurrentSkillPoint // SP Property
	{
		get => _currentSkillPoint;
		set => SetField(ref _currentSkillPoint, value, nameof(CurrentSkillPoint));
	}

	// [Event] Property Changed Event; will invoke when the data changes.
	public event PropertyChangedEventHandler PropertyChanged;

	#endregion [Fields]
	
	#region [Methods]

	// [Constructor] Sets values of HP & SP.
	public PlayerModel(int maxHealthPoint, int maxSkillPoint)
	{
		CurrentHealthPoint = _maxHealthPoint = maxHealthPoint;
		CurrentSkillPoint = _maxSkillPoint = maxSkillPoint;
	}
	
	// [Method] Invokes Property Changed Event.
	private void InvokePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	
	// [Method] Sets values of a property with invoking Property Changed Event.
	private void SetField<T>(ref T field, T value, string propertyName)
	{
		// Invokes the event only when the value is changed.
		if (!EqualityComparer<T>.Default.Equals(field, value))
		{
			field = value; // Changes the value of the property.
			InvokePropertyChanged(propertyName); // Invokes the event.
		}
	}
	
	#endregion [Methods]
	
	#region [Method] Controls Fields.
	
	// [Method] Heals HP.
	public void HealHealthPoint(int amount)
	{
		CurrentHealthPoint = Mathf.Min(CurrentHealthPoint + amount, _maxHealthPoint);
	}
	
	// [Method] Damages HP.
	public void DamageHealthPoint(int amount)
	{
		CurrentHealthPoint = Mathf.Max(0, CurrentHealthPoint - amount);
	}
	
	// [Method] Heals SP.
	public void HealSkillPoint(int amount)
	{
		CurrentSkillPoint = Mathf.Min(CurrentSkillPoint + amount, _maxSkillPoint);
	}
	
	// [Method] Damages SP.
	public void DamageSkillPoint(int amount)
	{
		CurrentSkillPoint = Mathf.Max(0, CurrentSkillPoint - amount);
	}
	
	#endregion [Method] Controls Fields.
}