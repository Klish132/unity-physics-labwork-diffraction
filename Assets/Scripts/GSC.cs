using UnityEngine;

public class GSC : MonoBehaviour
{
    public static GSC instance = null;

    public static GameObject focusTarget = null;

    public static GameObject bench = null;
    public static GameObject source = null;

    public static GameObject mesh = null;
    public static GameObject meshFrame = null;
    public static GameObject polaroid = null;
    public static GameObject polaroidFrame = null;
    public static GameObject screen = null;
    public static GameObject screenFrame = null;

    public static GameObject multimeterBody = null;

    public static ObjectHolder benchHolder = null;

    public static int benchPosition = 0;
    public static int polaroidAngle = 0;
    public static int multimeterState = 0;

    public static double meshPeriod = 0;
    public static string meshPeriodString;
    public static double waveLength = 0;
    public static string waveLengthString;
    public static int i0 = 0;
    //public static string i0String;

    public static bool isOnRuler = false;
    public static bool isDragging = false;
    public static bool preventRotation = false;
    public static bool sourceIsOn = false;

    void Start()
    {
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        { // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
        }
        Initialize();
    }

    private void Initialize()
    {
        focusTarget = bench = GameObject.Find("bench");
        source = GameObject.Find("source");

        mesh = GameObject.Find("mesh");
        meshFrame = GameObject.Find("MeshFrame");
        polaroid = GameObject.Find("polaroid");
        polaroidFrame = GameObject.Find("PolaroidFrame");
        screen = GameObject.Find("screen");
        screenFrame = GameObject.Find("ScreenFrame");

        multimeterBody = GameObject.Find("MultimeterBody");

        benchHolder = GameObject.Find("bench").GetComponent<ObjectHolder>();
    }
}
