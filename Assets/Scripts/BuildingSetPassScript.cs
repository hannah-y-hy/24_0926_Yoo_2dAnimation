using UnityEngine;

public class BuildingSetPassScript : MonoBehaviour
{
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject. layer == 3)
        {
            Debug.Log("비행기 무사통과 . Paper airplane passed the building set");
            logic.AddScore();
        }
    }

}

