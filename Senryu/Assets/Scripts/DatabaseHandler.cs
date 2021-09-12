using FullSerializer;
using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabaseHandler : MonoBehaviour
{
    private const string projectId = "senryu-6e704-default-rtdb";
    private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";

    private static fsSerializer serializer = new fsSerializer();

    public delegate void PostPoemCallback();
    public delegate void GetPoemsCallback(Dictionary<string, Poem> poems);

    public void Clicked()
    {
        Poem poem = new Poem("WHO IS DIS MAN", "DIS man", "MON", 2);

        PostPoem(poem, () =>
        {
            GetPoems(poems =>
            {

                Debug.Log(poems.ElementAt(0).Value.poemAuthor);

            });
        });
    }

    public void PostPoem(Poem poem, PostPoemCallback callback)
    {
        RestClient.Post<Poem>($"{databaseURL}.json", poem).Then(response =>
        {
            callback();
        });
    }

    public static void GetPoems(GetPoemsCallback callback)
    {
        RestClient.Get($"{databaseURL}.json").Then(response =>
        {
            var responseJson = response.Text;

            var data = fsJsonParser.Parse(responseJson);
            object deserialized = null;
            serializer.TryDeserialize(data, typeof(Dictionary<string, Poem>), ref deserialized);

            var poems = deserialized as Dictionary<string, Poem>;
            callback(poems);
        });
    }
}
