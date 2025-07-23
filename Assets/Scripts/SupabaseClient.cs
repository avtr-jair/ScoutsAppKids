using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro; // o usa TMPro si usas TMP_Text

public class SupabaseClient : MonoBehaviour
{
    public TextMeshProUGUI nameText; // arrastra aquí tu componente Text desde el Inspector

    private string baseUrl = "https://qhveemjtglrjjthifiec.supabase.co/rest/v1/";
    private string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFodmVlbWp0Z2xyamp0aGlmaWVjIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTMwOTQyODEsImV4cCI6MjA2ODY3MDI4MX0.yfv_qXqV8BSMufeLIaD9Q-JvV1IQsBUQPf5onPAH2Ck";
    
    public int scoutId = 3;

    void Start()
    {
        StartCoroutine(GetScoutName(scoutId));
    }

    IEnumerator GetScoutName(int id)
    {
        string url = baseUrl + "Scouts?id=eq." + id + "&select=name";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("apikey", apiKey);
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);
        request.SetRequestHeader("Accept", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;

            Scout[] scouts = JsonHelper.FromJsonArray<Scout>(json);

            if (scouts.Length > 0)
            {
                nameText.text = scouts[0].name;
            }
            else
            {
                nameText.text = "Scout no encontrado";
            }
        }
        else
        {
            Debug.LogError("Error al consultar Supabase: " + request.error);
            nameText.text = "Error de conexión";
        }
    }
}

[System.Serializable]
public class Scout
{
    public string name;
}

public static class JsonHelper
{
    public static T[] FromJsonArray<T>(string json)
    {
        string newJson = "{\"array\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

