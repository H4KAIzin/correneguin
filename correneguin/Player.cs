using FFImageLoading.Maui;

namespace correneguin;

public delegate void CallBack();
public class Player : Animacao
{
    public Player(CachedImage a): base(a)
    {
        //Animaçao do samurai andando
        for(int i = 1; i <= 8; i++)
            animacao1.Add($"corre{i.ToString("D2")}.png");
        //Animação de morte
        for(int i = 1; i <= 3; i++)
            animacao2.Add($"comes{i.ToString("D2")}.png");
        SetAnimacaoAtiva(1);
    }

    public void Die()
    {
        loop = false;
        SetAnimacaoAtiva(2);
    }

    public void Run()
    {
        loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }
}