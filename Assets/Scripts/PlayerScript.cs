using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도 / Movement speed
    public float flyForce = 1f; // 상승 힘 / Fly force
    private Rigidbody2D rb; // 리지드바디 컴포넌트 / Rigidbody2D component
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트 / SpriteRenderer component

    public Sprite Player; // 기본 플레이어 스프라이트 / Default player sprite
    public Sprite PlayerHitOnce; // 첫 번째 충돌 후 스프라이트 / Sprite after first collision
    public Sprite PlayerHitTwice; // 두 번째 충돌 후 스프라이트 / Sprite after second collision

    private int hitCount = 0; // 충돌 횟수 / Collision count
    private LogicScript logic; // 로직 스크립트 / LogicScript

    // Start is called before the first frame update
    // 게임 시작 시 호출되는 메서드입니다 / Method called at the start of the game
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // LogicManager 태그가 있는 오브젝트를 찾아 LogicScript 컴포넌트에 연결 / Find the object with LogicManager tag and connect to the LogicScript component
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();

        rb.gravityScale = 1f;
    }

    // Update is called once per frame
    // 매 프레임마다 호출되는 메서드입니다 / Method called every frame
    void Update()
    {
        // 위/아래 방향키 입력 처리 / Handling up/down arrow key input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, flyForce);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -flyForce);
        }

        // 좌/우 방향키 입력 처리 / Handling left/right arrow key input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    // 장애물과의 충돌 처리 / Handling collision with obstacles
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hitCount++;
            UpdatePlayerSprite();

            if (hitCount >= 3)
            {
                Debug.Log("Game Over");
                // 게임 오버 처리 / Trigger game over
                logic.GameOver();
            }
        }
    }

    // 충돌 횟수에 따라 플레이어 스프라이트 업데이트 / Update player sprite based on collision count
    void UpdatePlayerSprite()
    {
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
