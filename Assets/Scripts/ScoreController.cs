using UnityEngine.UI;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
	public static int LastScore = 0;

	public Text scoreText;
    public UIVisibleChange _visibleChanged;

    [SerializeField]
    private float timeSlice = 1.0f; //Время м-ду срезами
    [SerializeField]
    private int scoreForOneFruit = 100; //Счет за 1 срез
    private float timeAfterLastSlice;
    private int combo; //Сколько фруктов срезано в комбо
    private int score; //Счет

    void Start()
    {
        timeAfterLastSlice = 0;
        score = 0;
    }

    void Update() => timeAfterLastSlice += Time.deltaTime;

    //Add score for one slice
    public void AddScore() => AddScore(1);

    public void AddScore(int valueFruits)
    {
        combo = (timeSlice >= timeAfterLastSlice)? combo+valueFruits: valueFruits;
        score += scoreForOneFruit * valueFruits;
        timeAfterLastSlice = 0;
        UpdateGUIScore(this.score);
        _visibleChanged?.ActivateText(combo);
    }

	private void UpdateGUIScore(int value)
	{
		LastScore = value;
		scoreText.text = value.ToString();
	}
}
