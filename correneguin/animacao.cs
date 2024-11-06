namespace correneguin;

public class Animacao
{
    protected List<String> Animacao1 =  new List<String>();
    protected List<String> Animacao2 = new List<String>();

    protected bool loop = true;
    protected int animacaoAtiva = 1;
    bool parado = true;
    int frameAtual = 1;
    protected Image compImagem;
    public Animacao(Image a)
    {
        compImagem = a;
    }

    public void Stop()
    {
        parado = true;
    }

    public void Play()
    {
        parado = false;
    }

    public void SetAnimacaoAtiva(int a)
    {
        animacaoAtiva = a;
    }

    public void Desenha()
    {
        if(parado)
           return;
        string nomeArquivo = "";
        int tamanhoAnimacao = 0;
        if (animacaoAtiva = = 1)
        {
            nomeArquivo = Animacao1[frameAtual];
            tamanhoArquivo = Animacao1.Count;
        }
    }

}