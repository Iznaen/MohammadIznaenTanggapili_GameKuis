using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _inisialData = null;

    [SerializeField]
    private UI_LevelKuisList _levelLists = null;

    [SerializeField]
    private OpsiLevelPack _tombolLevelPack = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        LoadLevelPack();

        if (_inisialData.SaatKalah)
        {
            OpsiLevelPack_EventSaatKlik(_inisialData.levelPack);
        }

        // subscribe event
        OpsiLevelPack.EventSaatKlik += OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        // unsubscribe event
        OpsiLevelPack.EventSaatKlik -= OpsiLevelPack_EventSaatKlik;
    }

    private void OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        // buka menu levels
        _levelLists.gameObject.SetActive(true);
        _levelLists.UnloadLevelPack(levelPack);

        // tutup menu level packs
        gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;

        // _levelLists.UnloadLevelPack(levelPack);
    }

    private void LoadLevelPack()
    {
        foreach(var lp in _levelPacks)
        {
            // membuat salinan object dari prefab tombol level pack
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            // masukkan object tombol sebagai anak dari object "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}