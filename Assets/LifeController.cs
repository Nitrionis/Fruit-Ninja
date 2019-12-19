using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameObject[] lifes;
    private int Pos;

    void Start()
    {
        Pos = (lifes!=null)? lifes.Length-1: -1;

        if (Pos == -1) EndGame();
    }

    /// <summary>
    /// Set Character damage
    /// </summary>
    /// <param name="value"></param>
    public void AddDamage(int value = 1)
    {
        for (int i = 0; i < value; i++)
        {
            if (Pos < 0) break;

            lifes[Pos].SetActive(false);
            Pos--;
        }

        if (Pos < 0) EndGame();
    }

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
    /// Прописываем что-то для умертвения(конца концов) персонажа
    /// </summary>
    public void EndGame() { }
}
