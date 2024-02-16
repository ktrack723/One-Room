using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class csURUKManager : MonoBehaviour
{
    [Header("Assigned")]

    [SerializeField] private float speedMultiplier;

    [SerializeField] private string StageNumber;

    [SerializeField] private SpriteRenderer URUK_renderer;

    [SerializeField] private Sprite URUK_Dumb;
    [SerializeField] private Sprite URUK_Eat_01;
    [SerializeField] private Sprite URUK_Eat_02;
    [SerializeField] private Sprite URUK_Charge;
    [SerializeField] private Sprite URUK_Fire_01;
    [SerializeField] private Sprite URUK_Fire_02;
    [SerializeField] private Sprite URUK_Happy;
    [SerializeField] private Sprite URUK_Sad;

    [SerializeField] private GameObject Anchor_Flame;

    [SerializeField] private GameObject Flame_Rise;

    [Header("Debug")]

    [SerializeField] private List<GameObject> floors;

    [SerializeField] private int flameCount;

    [SerializeField] private bool isFiring;



    private void Start()
    {
        floors = GameObject.FindGameObjectsWithTag("Floor").ToList();

        StartCoroutine(StageNumber);
    }



    private void Update()
    {
        if (isFiring == true)
        {
            if (URUK_renderer.sprite == URUK_Fire_02)
            {
                URUK_renderer.sprite = URUK_Fire_01;
            }
            else
            {
                URUK_renderer.sprite = URUK_Fire_02;
            }
        }
    }



    private IEnumerator Stage01()
    {
        yield return new WaitForSeconds(1);

        ShootFlameBy(3);
    }



    private void ShootFlameBy(int arg)
    {
        flameCount = arg;

        StartCoroutine("ShootFlame");
    }



    private IEnumerator ShootFlame()
    {
        URUK_renderer.sprite = URUK_Eat_01;

        for (int i = 0; i < flameCount; i++)
        {
            yield return new WaitForSeconds(0.75f / speedMultiplier);

            if (URUK_renderer.sprite == URUK_Eat_02)
            {
                URUK_renderer.sprite = URUK_Eat_01;
            }
            else
            {
                URUK_renderer.sprite = URUK_Eat_02;
            }
        }

        yield return new WaitForSeconds(0.75f / speedMultiplier);

        URUK_renderer.sprite = URUK_Charge;

        yield return new WaitForSeconds(1.5f / speedMultiplier);

        isFiring = true;

        for (int i = 0; i < flameCount; i++)
        {
            Instantiate(Flame_Rise, Anchor_Flame.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(1.5f / speedMultiplier);
        }

        isFiring = false;

        URUK_renderer.sprite = URUK_Dumb;
    }



    public void EndGame()
    {

    }
}
