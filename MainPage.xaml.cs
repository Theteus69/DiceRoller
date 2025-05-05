using System.IO;
namespace DiceRoller
{
    public partial class MainPage : ContentPage
    {
        private int totalTentativas = 0;
        private int totalVitorias = 0;
        private int sequenciaAcertos = 0;
        private int somaTotal = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void FlipButtonClicked(object sender, EventArgs e)
        {
            if (totalTentativas >= 30)
            {
                DisplayAlert("Fim de Jogo", "Tentativas máximas utilizadas", "OK");
                return;
            }

            if (DicePicker.SelectedIndex == -1)
            {
                DisplayAlert("Erro", "Escolha um número primeiro!", "OK");
                return;
            }


            int numeroEscolhido = int.Parse(DicePicker.Items[DicePicker.SelectedIndex]);


            Random rand = new Random();
            int numeroSorteado = rand.Next(1, 7);


            int ladoOposto = 7 - numeroSorteado;


            int soma = numeroSorteado + ladoOposto;


            totalTentativas++;
            if (numeroEscolhido == numeroSorteado)
            {
                totalVitorias++;
                sequenciaAcertos++;
            }
            else
            {
                sequenciaAcertos = 0;
            }

            somaTotal += soma;


            vitorias.Text = $"Total de vitórias: {totalVitorias}";
            Streak.Text = $"Sequência de Acertos: {sequenciaAcertos}";
            Soma.Text = $"Soma do total com os lados opostos: {somaTotal}";


            DisplayAlert("Resultado", $"Número sorteado: {numeroSorteado}\nLado oposto: {ladoOposto}\nSoma: {soma}", "OK");
        }
    }
}