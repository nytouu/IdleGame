using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
	private Monster currentMonster;
	private float xp, increment, maxHp, startTime, fade;

	[SerializeField] Shop shop;
	[SerializeField] Image monsterImage; 
	[SerializeField] TextMeshProUGUI xpText; 
	[SerializeField] TextMeshProUGUI monsterText; 
	[SerializeField] TextMeshProUGUI hpText; 
	[SerializeField] Camera mainCamera;
	[SerializeField] Slider slider;
	[SerializeField] ParticleSystem particles;
	[SerializeField] TextMeshProUGUI moneyText;

	public CameraShake cameraShake;

	public List<Monster> monsterList;
	public Color firstColor, secondColor, thirdColor;

	public float fadeDuration;

	private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
		Spawn();
		xp = 0;
		increment = 1;
		fade = 0;

		audioSource = GetComponent<AudioSource>();
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
			hpText.text = currentMonster.hp + "/" + maxHp;

			if (currentMonster.hp <= 0) {
				shop.money += (int)maxHp;
				moneyText.text = "Gold: " + shop.money;

				UpdateXp(xp += increment);
				increment += 1.5f;

				audioSource.Play();
				StartCoroutine(cameraShake.Shake(0.15f, 0.1f));
				Spawn();
			}
		}
	}

	public void Spawn(){
		Monster selected = GetFromList();
		currentMonster = ScriptableObject.CreateInstance<Monster>();

		currentMonster.hp = selected.hp + xp;
		currentMonster.texture = selected.texture;
		currentMonster.displayName = selected.displayName;

		monsterText.text = selected.displayName;
		monsterImage.sprite = selected.texture;

		maxHp = selected.hp + xp;
		slider.value = 0f;
		hpText.text = currentMonster.hp + "/" + maxHp;
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
			>= 10000f => thirdColor,
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
