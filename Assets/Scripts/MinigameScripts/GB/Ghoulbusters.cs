using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoulbusters : BaseMinigame
{
    public int ghoulsKilled = 0;
    int ghoulsSpawned = 0;
    int offset = 1;
    [SerializeField] GameObject _ghoulPrefab;
    private void OnEnable()
    {
        GameManager.winMinigame += Win;
    }
    private void Start()
    {
        AudioSource music = GetComponent<AudioSource>();
        music.pitch = GameManager.speedUpModifier;
        SpawnGhoul(Vector3.right * Random.Range(-5f,5f));
    }

    private void SpawnGhoul(Vector3 position)
    {
        GameObject ghoul = Instantiate(_ghoulPrefab, position,Quaternion.identity);
        ghoul.transform.parent = transform;
        ghoulsSpawned += 1;
    }

    void Win()
    {
        _isWon = true;
    }
    private void Update()
    {
        _timer += Time.deltaTime * GameManager.speedUpModifier;
        CheckGhoulSpawn();
        if(ghoulsKilled == 3)
        {
            GameManager.winMinigame();
        }
        if (_timer >= 4f)
        {
            GameManager.endMinigame(_isWon);
        }
    }

    void CheckGhoulSpawn()
    {
        if(_timer>=1 && ghoulsSpawned == 1)
        {
            Vector3 ghoulPos = new Vector3(Random.Range(-5f, 5f), 3f, 0);
            SpawnGhoul(ghoulPos);
        }
        if (_timer >= 2 && ghoulsSpawned == 2)
        {
            Vector3 ghoulPos = new Vector3(Random.Range(-5f, 5f), -3f, 0);
            SpawnGhoul(ghoulPos);
        }
    }
}
