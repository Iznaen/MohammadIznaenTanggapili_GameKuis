using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField]
    private InisialDataGameplay _inisialData = null;

    [SerializeField]
    private UI_OpsiLevelKuis _tombolLevel = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private LevelPackKuis _levelPack = null;

    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _gameplayScene = null;

    private void Start()
    {
        // if(_levelPack != null)
        // {
        //     UnloadLevelPack(_levelPack);
        // }

        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _inisialData.levelIndex = index;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    public void UnloadLevelPack(LevelPackKuis levelPack)
    {
        HapusIsiKonten();

        _levelPack = levelPack;

        for(int i = 0; i < levelPack.BanyakLevel; i++)
        {
            // membuat salinan object dari prefab tombol level pack
            var t = Instantiate(_tombolLevel);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            // masukkan object tombol sebagai anak dari object "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for(int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
