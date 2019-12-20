using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float timeBetweenDamages;
    public GameObject[] lifes;

    private int Pos;
    private float timeAfterLastDamage;

    void Start()
    {
        Pos = (lifes!=null)? lifes.Length-1: -1;

        if (Pos == -1) EndGame();

        timeAfterLastDamage = timeBetweenDamages;
    }

    void Update() => timeAfterLastDamage += Time.deltaTime;

    /// <summary>
    /// Add one damage
    /// </summary>
    public void AddDamage() => AddDamage(1);

    /// <summary>
    /// Set Character damage
    /// </summary>
    /// <param name="value"></param>
    public void AddDamage(int value = 1)
    {
        if (timeAfterLastDamage <= timeBetweenDamages) return;
        timeAfterLastDamage = 0;

        for (int i = 0; i < value; i++)
        {
            if (Pos < 0) break;

            lifes[Pos].SetActive(false);
            Pos--;
        }

        if (Pos < 0) EndGame();
    }

    /// <summary>
    /// Add one life
    /// </summary>
    public void AddLife() => AddLife(1);

    /// <summary>
    /// Add health to character
    /// </summary>
    /// <param name="value"></param>
    public void AddLife(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (Pos == lifes.Length) break;

            lifes[Pos].SetActive(true);
            Pos++;
        }

        if (Pos == lifes.Length) Pos--;
    }

    /// <summary>
    /// Метод останавливает игру
    /// </summary>
    public void EndGame()
    {
        this.GetComponent<Spawner>().enabled = false;
        
        //show dead screen for reset level
    }
}
