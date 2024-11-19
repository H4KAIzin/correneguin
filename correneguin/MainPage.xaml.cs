using FFImageLoading.Maui;
namespace correneguin;

public partial class MainPage : ContentPage
{
	Player player;
	bool estaMorto = false;
	bool estaPulando = false;
	const int tempoEntreFrames = 25;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velocidade4 = 0;
	int velocidade5 = 0;
	int velocidade = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;

	public MainPage()
	{
		InitializeComponent();
		player = new Player(ImgSamurai);
		player.Run();
	}
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		CorrigeTamanhoCenario(width, height);
		CalculaVelocidade(width);
	}

	void CalculaVelocidade(double width)
	{
		velocidade1 = (int)(width * 0.001);
		velocidade2 = (int)(width * 0.004);
		velocidade3 = (int)(width * 0.008);
		velocidade4 = (int)(width * 0.012);
		velocidade5 = (int)(width * 0.016);
		velocidade = (int)(width * 0.01);
	}

	void CorrigeTamanhoCenario(double width, double height)
	{
		foreach (var a in HSLayer1.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayer2.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayer3.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayer4.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayer5.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayerChao.Children)
			(a as Image).WidthRequest = width;

		HSLayer1.WidthRequest = width * 1.5;
		HSLayer2.WidthRequest = width * 1.5;
		HSLayer3.WidthRequest = width * 1.5;
		HSLayer4.WidthRequest = width * 1.5;
		HSLayer5.WidthRequest = width * 1.5;
		HSLayerChao.WidthRequest = width * 1.5;
	}

	void GerenciaCenario()
	{
		MoveCenario();
		GerenciaCenario(HSLayer1);
		GerenciaCenario(HSLayer2);
		GerenciaCenario(HSLayer3);
		GerenciaCenario(HSLayer4);
		GerenciaCenario(HSLayer5);
		GerenciaCenario(HSLayerChao);
	}

	void MoveCenario()
	{
		HSLayer1.TranslationX -= velocidade1;
		HSLayer2.TranslationX -= velocidade2;
		HSLayer3.TranslationX -= velocidade3;
		HSLayer4.TranslationX -= velocidade4;
		HSLayer5.TranslationX -= velocidade5;
		HSLayerChao.TranslationX -= velocidade;
	}

	void GerenciaCenario(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}

	async Task Desenha()
	{
		while (!estaMorto)
		{
			GerenciaCenario();
			player.Desenha();

			await Task.Delay(tempoEntreFrames);
		}
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
}