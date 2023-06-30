using UnityEngine;

public static class DataHolder
{
    private static Texture2D _image;
    public static Texture2D Image
    {
        get { return _image; }
        set { _image = value; }
    }

    private static string _text;
    public static string Text
    {
        get { return _text; }
        set { _text = value.ToString(); }
    }
}
