using System.Collections.Generic;
using zadanie4.Models;

namespace zadanie4.ViewModels
{
    public class QuizViewModel
    {
        public List<Pytanie> Pytania { get; set; } = new List<Pytanie>();

        public Dictionary<int, int> WybraneOdpowiedzi { get; set; } = new Dictionary<int, int>();
    }
}