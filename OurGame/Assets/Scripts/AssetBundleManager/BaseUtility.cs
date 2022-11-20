using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.U2D;

public static class BaseUtility
{
    public const string AssetBundlesOutputPath = "AssetBundles";

    public static string GetPlatformName()
    {
#if UNITY_ANDROID
        return "Android";
#elif UNITY_IOS
			return "IOS";
#else
            return "Windows";
#endif
    }

    public static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            CreateDirectory(Path.GetDirectoryName(path));
            Directory.CreateDirectory(path);
        }
    }


    /// <summary>
    /// ��һ������������תΪ����
    /// </summary>
    /// <returns></returns>
    public static Vector3Int LongToVector3(long v)
    {
        var sign = v % 10;
        v /= 10;
        var x = (int)(v / 10000);
        var y = (int)(v % 10000);

        switch (sign)
        {
            case 1:
                x *= -1;
                break;
            case 2:
                y *= -1;
                break;
            case 3:
                x *= -1;
                y *= -1;
                break;
        }
        return new Vector3Int(x, y, 0);
    }

    /// <summary>
    /// ����ת������
    /// </summary>
    /// <param name="vec3"></param>
    /// <returns></returns>
    public static long Vector3ToLong(Vector3Int vec3)
    {
        var sign = 0; // ���ű��λ  0: xy��Ϊ����  1��xΪ���� 2��yΪ���� 3��xy��Ϊ����
        if (vec3.x < 0)
        {
            sign += 1;
        }
        if (vec3.y < 0)
        {
            sign += 2;
        }

        var t = (long)Mathf.Abs(vec3.x);
        return t * 100000 + Mathf.Abs(vec3.y) * 10 + sign;
    }

    public static Sprite GSprite(this SpriteAtlas spriteAtlas, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return null;
        }

        return spriteAtlas.GetSprite(name);
    }
}