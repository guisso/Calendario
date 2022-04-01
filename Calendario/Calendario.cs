using System;
using System.Text;

namespace Calendario
{
    internal class Calendario
    {
        public Byte Mes { get; set; }
        public UInt16 Ano { get; set; }

        public Boolean IsMesValido()
        {
            return Mes >= 1 && Mes <= 12;
        }

        public Boolean IsAnoValido()
        {
            return Ano >= 1 && Ano <= 9999;
        }

        public String GerarCalendario()
        {
            // Se dados inválidos para geração da data...
            if (!IsMesValido() || !IsAnoValido())
            {
                // ... interrompe execução gerando uma exceção
                throw new Exception("Mês e/ou ano inválidos.");
            }

            // Cria a data referente aos dados recebidos
            DateTime calendario = new DateTime(Ano, Mes, 1);

            // Identifica a partir de qual dia da semana o mês se inicia
            Byte diaSemanaPrimeiroDia = (Byte)calendario.DayOfWeek;

            // Recupera o último dia do mês para iteração
            Byte ultimoDia = (Byte)calendario.AddMonths(1).AddDays(-1).Day;
            
            // ... OU
            //Byte ultimoDia = (Byte)DateTime.DaysInMonth(Ano, Mes);


            // Gera título...
            String titulo = String.Format("{0:MMMM} de {0:yyyy}", calendario);

            // ... centralizado para o calendário
            titulo = (" " + Char.ToUpper(titulo[0]) + titulo.Substring(1) + " ")
                .PadLeft((titulo.Length + 2) / 2 + 15, ' ')
                .PadRight(30, ' ');

            // Inicia a elaboração da string
            StringBuilder sb = new StringBuilder(titulo + "\n");

            // Especificação de colunas para dias da semana
            sb.Append("------------------------------\n");
            sb.Append("  D   S   T   Q   Q   S   S   \n");
            sb.Append("------------------------------\n");

            // Dias iniciais vazios
            for (int i = 0; i < diaSemanaPrimeiroDia; i++)
            {
                sb.Append("    ");
            }

            // Insere dias válidos para o mês
            for (int i = 1; i <= ultimoDia; i++)
            {
                sb.Append(
                    String.Format("  {0:00}", i)
                    // Inserção de quebra de linha aos sábados
                     + ((i + diaSemanaPrimeiroDia) % 7 == 0 ? "\n" : "")
                    );
            }
            
            // Barra inferior...
            sb.Append(
                // ... com quebra de linha condicional no início
                (sb[sb.Length - 1] == '\n' ? "" : "\n")
                + "------------------------------\n");

            // Retorna string construída
            return sb.ToString();
        }
    }
}

/*
---------------------
-- Múltiplas cores --
---------------------
var data = new[] { new[] { "a", "b", "c" }, new[] { "d", "e", "f" } };
var colors = new[] { ConsoleColor.Red, ConsoleColor.Green };

// Build a stream of commands with with some of them dealing
// with formatting and others dealing with data output
var commandBuilder = new List<Action>();
var colorIndex = 0;
foreach (var row in data)
{
    foreach (var cell in row)
    {
        // Define a local variable 
        var cellColor = colors[colorIndex];
        commandBuilder.Add(() => SetCellColor(cellColor));
        commandBuilder.Add(() => DrawCell(cell));

        // flip colors
        colorIndex = ++colorIndex % colors.Length;
    }
    commandBuilder.Add(NewRow);
}

// Now, as we've built our command stream, play it:
commandBuilder.ForEach(cmd => cmd());

void SetCellColor(ConsoleColor color) { Console.ForegroundColor = color; }
void DrawCell(string cellText) { Console.Write(cellText); }
void NewRow() { Console.WriteLine(); }
*/