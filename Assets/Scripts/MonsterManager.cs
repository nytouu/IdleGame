using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
	private Monster currentMonster;
	private float xp, increment, maxHp, startTime, fade;

	[SerializeField] Image monsterImage; 
	[SerializeField] TextMeshProUGUI xpText; 
	[SerializeField] TextMeshProUGUI monsterText; 
	[SerializeField] Camera mainCamera;
	[SerializeField] Slider slider;
	[SerializeField] ParticleSystem particles;

	public List<Monster> monsterList;
	public Color firstColor;
	public Color secondColor;

	public float fadeDuration;

    // Start is called before the first frame update
    void Start()
    {
		Spawn();
		xp = 0;
		increment = 1;
		fade = 0;
    }

	void Update(){
		if (fade >= 1) {
			fade = 0f;
			if (particles.isPlaying) 
				particles.Stop();
			monsterImage.color = Color.white;
		} else if (fade <= 1 && fade > 0) {
			fade += Time.deltaTime / fadeDuration;
			monsterImage.color = Color.Lerp(Color.red, Color.white, fade);
		}
	}

	public void Attack(float power, bool shouldAnimate) {
		if (currentMonster) {
			if (shouldAnimate){
				StartAnimateDamage();
			}

			currentMonster.hp -= power;
			slider.value += (power * 100f / maxHp) / 100f;

			if (currentMonster.hp <= 0) {
				UpdateXp(xp += increment);
				increment *= 1.5f;

				Spawn();
			}
		}
	}

	public void Spawn(){
		Monster selected = GetFromList();
		currentMonster = ScriptableObject.CreateInstance<Monster>();

		currentMonster.hp = selected.hp;
		currentMonster.texture = selected.texture;
		currentMonster.displayName = selected.displayName;

		monsterText.text = selected.displayName;
		monsterImage.sprite = selected.texture;

		maxHp = selected.hp;
		slider.value = 0f;
	}

	public Monster GetFromList(){
		int i = Random.Range(0, monsterList.Count);
		return monsterList[i];
	}

	private void UpdateXp(float value){
		xp += value;
		xpText.text = "XP: " + xp.ToString();

        mainCamera.backgroundColor = xp switch
        {
			>= 1000f => secondColor,
			>= 100f => firstColor,
			_ => firstColor
        };
    }

	private void StartAnimateDamage(){
		startTime = Time.time;
		monsterImage.color = Color.red;
		fade = 0.01f;
		particles.Play();
	}
}
