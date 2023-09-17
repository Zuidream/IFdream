using Godot;
using System;
using System.IO;
using System.Text.Json;

public static class Language
{
    //监视语言代码 自动修改语言文件
    public static void LanguageObserve()
    {
        string jsonString = File.ReadAllText(@"D:\\Godot\WakaMon\Options.json");
        Options json = JsonSerializer.Deserialize<Options>(jsonString);
        if (json.Language == 0)
            Language_en.Change_en();
        if (json.Language == 1)
            Language_cn.Change_cn();
    }
    public static string? OpenGame { get; set; }
    public static string? Option { get; set; }
    public static string? Help { get; set; }
    public static string? Exit { get; set; }
}
