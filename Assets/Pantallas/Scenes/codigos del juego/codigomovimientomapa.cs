using UnityEngine;

public class WorldMapMovement : MonoBehaviour
{
    public Transform[] nodes;

    public float speed = 3f;

    int currentNode = 0;

    bool moving = false;

    void Update()
    {
        if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentNode < nodes.Length - 1)
                {
                    currentNode++;
                    moving = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentNode > 0)
                {
                    currentNode--;
                    moving = true;
                }
            }
        }

        if (moving)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                nodes[currentNode].position,
                speed * Time.deltaTime
            );

            if (Vector2.Distance(
                transform.position,
                nodes[currentNode].position) < 0.01f)
            {
                moving = false;
            }
        }
    }
}