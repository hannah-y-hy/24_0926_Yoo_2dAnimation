using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject cityScapePrefab;  // 파노라마 이미지 프리팹
    public float spawnRate = 2f;        // 장애물 생성 간격
    private float timer = 0f;           // 스폰 타이머
    public float heightOffset = 0f;     // Y 위치 오프셋 (필요에 따라 조정)

    void Start()
    {
        // 초기 스폰
        SpawnBuilding();
    }

    void Update()
    {
        // 타이머 증가
        timer += Time.deltaTime;

        // 일정 시간이 지나면 새로운 장애물 스폰
        if (timer >= spawnRate)
        {
            SpawnBuilding();
            timer = 0f; // 타이머 초기화
        }
    }

    void SpawnBuilding()
    {
        // 스프라이트 높이 계산
        float screenHeight = Camera.main.orthographicSize * 2f;
        float spawnYPosition = -screenHeight / 2f + heightOffset; // 바닥에 맞추기 위한 오프셋 추가

        // 스프라이트 너비 계산
        float buildingWidth = cityScapePrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        // 화면 왼쪽 바깥에서 스폰
        Vector2 spawnPosition = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - buildingWidth, spawnYPosition);
        Instantiate(cityScapePrefab, spawnPosition, Quaternion.identity);
    }
}

