using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    public bool UpButton,DownButton,ShootButton;
    public Text ScoreText;
    public Image[] HealthSystem;
    public GameObject[] PlayerPrefab;
    public bool IsPrefab=true;
    public Vector2 Position;
    public int Selected;

	void Start () {
        ShootButton = false;
        Position.x = -15;
        Position.y = 0;
        Selected = PlayerPrefs.GetInt("Selected");
        PlayerInstantiate();
    }
	
	void Update () {
        ScoreText.text = "SCORE: " + Statik.Skor.ToString();
    }

    public void PlayerInstantiate()
    {
        if (IsPrefab)
        {

            Instantiate(PlayerPrefab[Selected], Position, Quaternion.identity);
            IsPrefab = false;
        }
    }
    public void OnUp()
    {
        UpButton = true;
    }
    public void OnDown()
    {
        DownButton = true;
    }
    public void OffUp()
    {
        UpButton = false;
    }
    public void OffDown()
    {
        DownButton = false;
    }
    public void OnShoot()
    {
        ShootButton = true;
    }
}
