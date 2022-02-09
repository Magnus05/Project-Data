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
    public int highScore;

    void Start()
    {
        LoadPerfil();
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            namePlayer = nameInput.text;
            SavePerfil();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string namePlayer;
        public int highScore;
    }

    public void SavePerfil()
    {
        SaveData perfilPlayer = new SaveData();
        perfilPlayer.namePlayer = namePlayer;
        perfilPlayer.highScore = highScore;
        string json = JsonUtility.ToJson(perfilPlayer);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadPerfil()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData perfilPlayer = JsonUtility.FromJson<SaveData>(json);
            namePlayer = perfilPlayer.namePlayer;
            highScore = perfilPlayer.highScore;
        }
    }
}
