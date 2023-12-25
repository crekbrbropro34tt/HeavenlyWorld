using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private Transform elevator;
    [SerializeField] private Transform PointUp, PointDown;

    [SerializeField] private float speed;
    private bool WhereIsHeGoing;

    private bool TrueTranslate;
    [SerializeField] private GameObject panelPressF;
    private bool inMove;

    [SerializeField] private RotateObject[] shesterenki;

    private void FixedUpdate()
    {

        elevatorTranslateUp();

        if (WhereIsHeGoing)
        {
            if(Vector2.Distance(elevator.position, PointUp.position) > 0)
            {
                elevator.position = Vector2.MoveTowards(elevator.position, PointUp.position, speed * Time.deltaTime);

                for (int i = 0; i < shesterenki.Length; i++)
                {
                    shesterenki[i].enabled = true;
                }

                inMove = true;
            } else
            {
                for (int i = 0; i < shesterenki.Length; i++)
                {
                    shesterenki[i].enabled = false;
                }

                transform.position = this.transform.position;
                inMove = false;
            }
        }

        if (!WhereIsHeGoing)
        {
            if (Vector2.Distance(elevator.position, PointDown.position) > 0)
            {
                for (int i = 0; i < shesterenki.Length; i++)
                {
                    shesterenki[i].enabled = true;
                }

                elevator.position = Vector2.MoveTowards(elevator.position, PointDown.position, speed * Time.deltaTime);
                inMove = true;
            }
            else
            {
                for (int i = 0; i < shesterenki.Length; i++)
                {
                    shesterenki[i].enabled = false;
                }

                transform.position = this.transform.position;
                inMove = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            TrueTranslate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            TrueTranslate = false;
        }
    }

    public void elevatorTranslateUp()
    {
        if (!inMove)
        {
            panelPressF.SetActive(TrueTranslate);
            if (TrueTranslate)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    WhereIsHeGoing = !WhereIsHeGoing;
                }
            }
        } else
        {
            panelPressF.SetActive(false);
        }
    }

}
