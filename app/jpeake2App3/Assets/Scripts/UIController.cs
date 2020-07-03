using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
	public TextMeshProUGUI waveCounter;
	public TextMeshProUGUI waveCountdown;
	public TextMeshProUGUI livesUI;
	public TextMeshProUGUI moneyUI;

	public float lastwave;

	void Start()
	{

	}

	public void SetWaveCounterText(float c)
	{
		waveCounter.text = $"Wave: {c}/{lastwave}";
	}

	public void SetwaveCountdownText(float c)
	{
		waveCountdown.text = $"Next Wave: {c}";
	}

	public void SetLives(int c)
	{
		livesUI.text = $"{c}";
	}

	public void SetMoney(int c)
	{
		moneyUI.text = $"{c}";
	}
}
