using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<LevelPackKuis, bool> EventSaatKlik;

    [SerializeField]
    private Button _tombol = null;

    [SerializeField]
    private TextMeshProUGUI _packName = null;

    [SerializeField]
    private LevelPackKuis _levelPack = null;

    [SerializeField]
    private TextMeshProUGUI _labelTerkunci = null;

    [SerializeField]
    private TextMeshProUGUI _labelHarga = null;

    [SerializeField]
    private bool _terkunci = false;

    private void Start()
    {
        if(_levelPack != null)
        {
            SetLevelPack(_levelPack);
        }

        // subscribe event
        _tombol.onClick.AddListener(SaatKlik);
    }

    private void OnDestroy()
    {
        // unsubscribe event
        _tombol.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelPack(LevelPackKuis levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

    private void SaatKlik()
    {
        // Debug.Log("KLIK!!!");

        EventSaatKlik?.Invoke(_levelPack, _terkunci);
    }

    public void KunciLevelPack()
    {
        _terkunci = true;
        _labelTerkunci.gameObject.SetActive(true);
        _labelHarga.transform.parent.gameObject.SetActive(true);
        _labelHarga.text = $"{_levelPack.Harga}";
    }

    public void BukaLevelPack()
    {
        _terkunci = false;
        _labelTerkunci.gameObject.SetActive(false);
        _labelHarga.transform.parent.gameObject.SetActive(false);
    }
}