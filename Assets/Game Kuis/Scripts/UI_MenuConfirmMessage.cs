using UnityEngine;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private GameObject _pesanCukupKoin = null;

    [SerializeField]
    private GameObject _pesanTakCukupKoin = null;

    void Start()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        // subs event
        OpsiLevelPack.EventSaatKlik += OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        OpsiLevelPack.EventSaatKlik -= OpsiLevelPack_EventSaatKlik;
    }

    private void OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack, bool terkunci)
    {
        // cek terkunci atau tidak, jika false abaikan
        if (!terkunci)
        {
            return;
        }

        // cek kecukupan koin untuk membuka level
        if (_playerProgress.progresData.koin < levelPack.Harga)
        {
            // jika koin tidak cukup
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        // jika koin cukup
        _pesanCukupKoin.SetActive(true);
        _pesanTakCukupKoin.SetActive(false);
    }
}