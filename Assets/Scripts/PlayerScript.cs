using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도 / Movement speed
    public float flyForce = 1f;  // 상승하는 힘 / Force applied when flying

    public LogicScript logic;
    public bool AirplaneIsAlive = true;

    private Rigidbody2D rb;      // Rigidbody2D 컴포넌트 참조 / Reference to the Rigidbody2D component
    private SpriteRenderer spriteRenderer; // SpriteRenderer 컴포넌트 참조 / Reference to the SpriteRenderer component
    private Animator animator;   // 애니메이터 컴포넌트

    public Sprite Player;         // 기본 스프라이트 / Default sprite
    public Sprite PlayerHitOnce;  // 한 번 충돌한 후의 스프라이트 / Sprite after one hit
    public Sprite PlayerHitTwice; // 두 번 충돌한 후의 스프라이트 / Sprite after two hits

    private int hitCount = 0; // 충돌 횟수 / Number of hits

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 연결 / Connect the Rigidbody2D component
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트 연결 / Connect the SpriteRenderer component
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 연결

        rb.gravityScale = 1f; // 중력 설정 / Set gravity

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // 위/아래 방향키 입력 처리 / Handle Up/Down arrow key input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, flyForce);
            animator.SetTrigger("Fly"); // Fly 트리거 실행
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -flyForce);
        }

        // 좌/우 방향키 입력 처리 / Handle Left/Right arrow key input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 장애물과 충돌했을 때 / When colliding with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hitCount++; // 충돌 횟수 증가 / Increase the hit count
            UpdatePlayerSprite(); // 플레이어 스프라이트 업데이트 / Update the player sprite

            if (hitCount >= 3)
            {
                Debug.Log("Game Over");
                logic.GameOver(); // 3번째 충돌 시에만 게임 오버 호출 / GameOver only on the third hit
                AirplaneIsAlive = false;
            }
        }
    }

    void UpdatePlayerSprite()
    {
        // 충돌 횟수에 따라 스프라이트 변경 / Change the sprite based on the hit count
        if (hitCount == 1)
        {
            spriteRenderer.sprite = PlayerHitOnce;
        }
        else if (hitCount == 2)
        {
            spriteRenderer.sprite = PlayerHitTwice;
        }
    }
}
