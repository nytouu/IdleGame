using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
	[SerializeField] private MonsterManager monsters;
	[SerializeField] private bool autoClickEnabled;
	[SerializeField] private float clickPower = 2;
	[SerializeField] private float autoClickPower = 1f;
	public float delay = 1f;

	public TextMeshProUGUI scoreText;

	private float score;

    // Start is called before the first frame update
    void Start()
    {
		if (autoClickEnabled){
			StartCoroutine(AutoClick());
		}
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
			UpdateScore(clickPower);
		}
    }

	public float UpdateScore(float value){
		score += value;
		scoreText.text = score.ToString();

		Debug.Log(score);
		return score;
	}

	private IEnumerator AutoClick() {
		while (autoClickEnabled) {
			/* monsters.currentMonster.Attack(autoClickPower); */
			UpdateScore(autoClickPower);
			yield return new WaitForSeconds(delay);
		} 
		while (!autoClickEnabled) {
			yield return new WaitForSeconds(delay * 5);
		}
	}
}
