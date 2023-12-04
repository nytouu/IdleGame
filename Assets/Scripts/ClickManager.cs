using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
	[SerializeField] private MonsterManager monsters;
	public bool autoClickEnabled;
	public float delay = 1f;

	private float clickPower = 1;
	private float autoClickPower = 0f;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(AutoClick());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("clicked");
		}
    }

	private IEnumerator AutoClick() {
		while (autoClickEnabled) {
			monsters.currentMonster.Attack(clickPower);
			yield return new WaitForSeconds(delay);
		} 
		while (!autoClickEnabled) {
			yield return new WaitForSeconds(delay * 5);
		}
	}
}
