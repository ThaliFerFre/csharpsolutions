using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // 1) Soma com laço 'enquanto'
        SomaComLaco();

        // 2) Verificação de número na sequência de Fibonacci
        VerificaFibonacci();

        // 3) Faturamento diário de uma distribuidora
        FaturamentoDistribuidora();

        // 4) Percentual de faturamento por estado
        PercentualFaturamentoPorEstado();

        // 5) Inversão de uma string sem usar funções prontas
        InverterString();
    }

    // 1) Soma com laço 'enquanto'
    static void SomaComLaco()
    {
        int INDICE = 13, SOMA = 0, K = 0;

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine("Questão 1 - Soma final: " + SOMA);
    }

    // 2) Verificação de número na sequência de Fibonacci
    static void VerificaFibonacci()
    {
        Console.Write("\nQuestão 2 - Informe um número para verificar se está na sequência de Fibonacci: ");
        int num = int.Parse(Console.ReadLine());
        bool isFibonacci = IsFibonacci(num);
        
        if (isFibonacci)
            Console.WriteLine($"{num} pertence à sequência de Fibonacci.");
        else
            Console.WriteLine($"{num} não pertence à sequência de Fibonacci.");
    }

    static bool IsFibonacci(int n)
    {
        int a = 0, b = 1, c = 0;
        while (c < n)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c == n || n == 0;
    }

    // 3) Faturamento diário de uma distribuidora
    static void FaturamentoDistribuidora()
    {
        string json = @"[1000.0, 2000.0, 0.0, 3000.0, 5000.0, 7000.0, 0.0, 8000.0, 6000.0]";
        List<double> faturamentos = JsonConvert.DeserializeObject<List<double>>(json);

        // Remove zeros (dias sem faturamento)
        var faturamentoSemZeros = faturamentos.Where(f => f > 0).ToList();

        double menor = faturamentoSemZeros.Min();
        double maior = faturamentoSemZeros.Max();
        double media = faturamentoSemZeros.Average();
        int diasAcimaMedia = faturamentoSemZeros.Count(f => f > media);

        Console.WriteLine($"\nQuestão 3 - Menor faturamento: {menor}");
        Console.WriteLine($"Maior faturamento: {maior}");
        Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaMedia}");
    }

    // 4) Percentual de faturamento por estado
    static void PercentualFaturamentoPorEstado()
    {
        double sp = 67836.43, rj = 36678.66, mg = 29229.88, es = 27165.48, outros = 19849.53;
        double total = sp + rj + mg + es + outros;

        Console.WriteLine("\nQuestão 4 - Percentual de faturamento por estado:");
        Console.WriteLine($"Percentual SP: {sp / total * 100:F2}%");
        Console.WriteLine($"Percentual RJ: {rj / total * 100:F2}%");
        Console.WriteLine($"Percentual MG: {mg / total * 100:F2}%");
        Console.WriteLine($"Percentual ES: {es / total * 100:F2}%");
        Console.WriteLine($"Percentual Outros: {outros / total * 100:F2}%");
    }

    // 5) Inversão de uma string sem usar funções prontas
    static void InverterString()
    {
        Console.Write("\nQuestão 5 - Informe uma string para inverter: ");
        string str = Console.ReadLine();
        string invertida = InverterStringHelper(str);
        Console.WriteLine($"String invertida: {invertida}");
    }

    static string InverterStringHelper(string str)
    {
        char[] caracteres = str.ToCharArray();
        string resultado = "";
        for (int i = caracteres.Length - 1; i >= 0; i--)
        {
            resultado += caracteres[i];
        }
        return resultado;
    }
}
