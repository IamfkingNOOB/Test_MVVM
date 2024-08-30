using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ※ This View has no actions of request for modifying Model; Is this a proper View for MVVM pattern?
public class PlayerView : MonoBehaviour // Prints the data of Player on UI.
{
	// View has an instance of View Model.
	private PlayerViewModel _viewModel;
	
	// [SerializeField] UI Elements
	[SerializeField] private TextMeshProUGUI text_healthPoint;
	[SerializeField] private TextMeshProUGUI text_skillPoint;
	[SerializeField] private Slider slider_healthPoint;
	[SerializeField] private Slider slider_skillPoint;

	// [Method] OnEnable()
	private void OnEnable()
	{
		if (_viewModel == null)
		{
			_viewModel = new PlayerViewModel(); // Creates a View Model.
			_viewModel.PropertyChanged += OnPropertyChanged; // Adds listeners to Property Changed Event.
		}
	}
	
	// [Method] OnDisable()
	private void OnDisable()
	{
		if (_viewModel != null)
		{
			_viewModel.RemoveListeners(); // Removes listeners of View Model.
			_viewModel.PropertyChanged -= OnPropertyChanged; // Removes listeners from Property Changed Event.
			_viewModel = null; // Removes the View Model.
		}
	}

	// [Method] Callback of View Model's Property Changed Event
	private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		UpdateUI(e.PropertyName); // Updates UIs related to a property.
	}

	// [Method] Updates UIs related to a property.
	private void UpdateUI(string propertyName)
	{
		switch (propertyName)
		{
			case nameof(_viewModel.HealthPoint):
				text_healthPoint.text = $"{_viewModel.HealthPoint}";
				slider_healthPoint.value = _viewModel.HealthPoint;
				break;
			case nameof(_viewModel.SkillPoint):
				text_skillPoint.text = $"{_viewModel.SkillPoint}";
				slider_skillPoint.value = _viewModel.SkillPoint;
				break;
		}
	}
}