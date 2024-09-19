using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // 이동 속도

    void Update()
    {
        // 오른쪽으로 이동
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // 장애물이 화면의 오른쪽 끝을 완전히 벗어난 후 제거
        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x + GetComponent<SpriteRenderer>().bounds.size.x)
        {
            Destroy(gameObject);
        }
    }
}
