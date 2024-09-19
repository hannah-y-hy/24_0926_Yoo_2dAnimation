using UnityEngine;

public class BuildingSetPassScript : MonoBehaviour
{
    private LogicScript logic;

    // Start is called before the first frame update
    // 게임 시작 시 호출되는 메서드입니다 / Method called at the start of the game
    void Start()
    {
        // LogicManager 태그가 있는 오브젝트를 찾아 LogicScript 컴포넌트에 연결 / Find the object with LogicManager tag and connect to the LogicScript component
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
    }

    // 플레이어가 빌딩 세트를 통과할 때 호출되는 메서드입니다 / Method called when the player passes the building set
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1점 추가 / Add 1 point
            logic.AddScore(1);
        }
    }
}
