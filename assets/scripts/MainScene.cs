using Godot;
using System;
using System.IO;
using System.Text.Json;

public partial class MainScene : Control
{
	Button BnPlay;
	Button BnOption;
	Button BnHelp;
	Button BnExit;
	
	public override void _Ready()
	{
		//初始化
		if (!Directory.Exists(@"D:\\Godot\WakaMon"))
			Directory.CreateDirectory(@"D:\\Godot\WakaMon");
		if (!File.Exists(@"D:\\Godot\WakaMon\Options.json"))
		{
			Options options = new Options() { Language = 0, };
			string jsonString = JsonSerializer.Serialize(options);
			File.WriteAllText(@"D:\\Godot\WakaMon\Options.json", jsonString);
        }
		Language.LanguageObserve();
			
		//获取节点
        BnPlay = GetNode<Button>("BoxContainer/VBoxContainer/BnPlay");
        BnOption = GetNode<Button>("BoxContainer/VBoxContainer/BnOption");
        BnHelp = GetNode<Button>("BoxContainer/VBoxContainer/BnHelp");
        BnExit = GetNode<Button>("BoxContainer/VBoxContainer/BnExit");
		BnPlay.Text = Language.OpenGame;
		BnOption.Text = Language.Option;
		BnHelp.Text = Language.Help;
		BnExit.Text = Language.Exit;
		//信号连接 点击执行方法
		BnOption.Pressed += () => { OnBnOption(); };
		BnHelp.Pressed += () => { OnBnHelp(); };
		BnExit.Pressed += () => { OnBnExit(); };
	}

    private void OnBnOption()
    {
        Language_en.Change_en();
        Options options = new Options() { Language = 0, };
        string jsonString = JsonSerializer.Serialize(options);
        File.WriteAllText(@"D:\\Godot\WakaMon\Options.json", jsonString);
        GetTree().ReloadCurrentScene();
    }

    private void OnBnHelp()
    {
        Language_cn.Change_cn();
        Options options = new Options() { Language = 1, };
        string jsonString = JsonSerializer.Serialize(options);
        File.WriteAllText(@"D:\\Godot\WakaMon\Options.json", jsonString);
        GetTree().ReloadCurrentScene();
    }

    private void OnBnExit()
    {
		GetTree().Quit();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
