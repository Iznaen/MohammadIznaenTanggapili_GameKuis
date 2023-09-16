using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    private UI_PesanLevel _tempatPesan = null;    

    [SerializeField]
    private Slider _timeBar = null;

    [SerializeField]
    private float _waktuJawab = 10f;

    private float _sisaWaktu = 0f;
    private bool _waktuBerjalan = true;

    public bool WaktuBerjalan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    private void Start()
    {
        UlangWaktu();
    }

    private void Update()
    {
        if (!_waktuBerjalan)
            return;

        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu <= 0f)
        {
            _tempatPesan.Pesan = "Waktu sudah habis!";
            _tempatPesan.gameObject.SetActive(true);
            //#Debug.Log("Waktu habis!");
            _waktuBerjalan = false;
            return;
        }

        //#Debug.Log(_sisaWaktu);
    }

    public void UlangWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }
}
