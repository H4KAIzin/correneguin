namespace correneguin;

public partial class MainPage : ContentPage
{
	
bool estaMorto=false;
bool estaPulando=false;
const int tempoEntreFrames=25;
int velocidade1=0;
int velocidade2=0;
int velocidade3=0;
int velocidade4=0;
int velocidade5=0;
int velocidade=0;
int larguraJanela=0;
int alturaJanela=0;
	public MainPage()
	{
		InitializeComponent();
	}
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
		CorrigeTamanhoCenario(width, height);
		CalculaVelocidade(width);
    }

	void CalculaVelocidade(double width)
	{
		velocidade1=(int)(width*0.001);
		velocidade2=(int)(width*0.004);
		velocidade3=(int)(width*0.008);
		velocidade4=(int)(width*0.0010);
		velocidade5=(int)(width*001);
		velocidade=(int)(width*001);
	}

	void CorrigeTamanhoCenario(double width, double height)
	{
		foreach (var a in HSLayer1.Children)
		(a as Image). WidthRequest = width;
		foreach (var a in HSLayer2.Children)
		(a as Image). WidthRequestRequest = width;
		foreach (var a in HSLayer3.Children)
		(a as Image). WidthRequest = width;
		foreach(var a in HSLayerChao.Children)
		(a as Image). WidthRequest = width;

		HSLayer1.WidthRequest = width*1.5;
		HSLayer2.WidthRequest = width*1.5;
		HSLayer3.WidthRequest = width*1.5;
		HSLayerChao.WidthRequest = width*1.5;
	}

	

}

