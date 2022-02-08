using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Perfil : MonoBehaviour
{
    public static Perfil Instance;
    public TextMeshProUGUI nameInput;
    public string namePlayer;

    void Start()
    {
        LoadName();
    }

    void Update()
    {
        InputName();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void InputName()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            namePlayer = nameInput.text;
            SaveName();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string namePlayer;
    }

    public void SaveName()
    {
        SaveData perfilPlayer = new SaveData();
        perfilPlayer.namePlayer = namePlayer;
        string nameJson = JsonUtility.ToJson(perfilPlayer);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", nameJson);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string nameJson = File.ReadAllText(path);
            SaveData perfilPlayer = JsonUtility.FromJson<SaveData>(nameJson);
            namePlayer = perfilPlayer.namePlayer;
        }
    }
}
