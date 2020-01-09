using UnityEngine;
using UnityEngine.UI;

public class UIVisibleChange : MonoBehaviour
{

    [SerializeField] private GameObject _object;
    [SerializeField] private float period = 1;
    [SerializeField] private bool setColor = true;
    [SerializeField] private Color color;

    private bool Activate = false;
    private Graphic g;
    private Text t;

    void Start()
    {
        g = _object.GetComponent<Graphic>();
        t = _object.GetComponent<Text>();
        g.color = new Color(g.color.r, g.color.g, g.color.b, 0);
    }

    void Update()
    {
        if (!Activate) return;

        float a = Mathf.Lerp(g.color.a*period, 0, Time.deltaTime) / period;//Mathf.PingPong(Time.time, period) / period;

        if (setColor)
            g.color = new Color(color.r, color.g, color.b, a);
        else
            g.color = new Color(g.color.r, g.color.g, g.color.b, a);

        if (a == 0) Activate = false;
    }

    public void ActivateText(int value)
    {
        t.text = "X" + value.ToString();
        g.color = new Color(g.color.r, g.color.g, g.color.b, 1);
        Activate = true;
    }
}
