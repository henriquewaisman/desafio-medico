using NPOI.SS.UserModel;
using LinqTest.Models;
using System.Text.RegularExpressions;
using System.Runtime.ConstrainedExecution;
class Program
{
    private static string caminhoArquivo = Path.Combine(Environment.CurrentDirectory, "DesafioMedicos.xlsx");
    private static List<Consulta> consultas = [];
    static void Main(string[] args)
    {
        Console.Clear();
        ImportarDadosPlanilha();
        Exe3();
    }
    private static void ImportarDadosPlanilha()
    {
        try
        {
            IWorkbook pastaTrabalho = WorkbookFactory.Create(caminhoArquivo);
            ISheet planilha = pastaTrabalho.GetSheetAt(0);

            for (int i = 1; i < planilha.PhysicalNumberOfRows; i++)
            {
                try
                {
                    IRow linha = planilha.GetRow(i);
                    DateTime dataConsulta = DateTime.Parse(linha.GetCell(0).StringCellValue);
                    string horaDaConsulta = linha.GetCell(1).StringCellValue;
                    string nomePaciente = linha.GetCell(2).StringCellValue;
                    string? numeroTelefone = linha.GetCell(3)?.StringCellValue;
                    long cpf = Convert.ToInt64(Regex.Replace(linha.GetCell(4).StringCellValue, @"\D", ""));
                    string rua = linha.GetCell(5).StringCellValue;
                    string cidade = linha.GetCell(6).StringCellValue;
                    string estado = linha.GetCell(7).StringCellValue;
                    string especialidade = linha.GetCell(8).StringCellValue ?? "Geral";
                    string nomeMedico = linha.GetCell(9).StringCellValue ?? "Desconhecido   ";
                    bool particular = linha.GetCell(10).StringCellValue == "Sim" ? true : false;
                    long numeroDaCarteirinha = (long)linha.GetCell(11).NumericCellValue;
                    double valorConsulta = linha.GetCell(12).NumericCellValue;
                    Consulta consulta = new Consulta(dataConsulta, horaDaConsulta, nomePaciente, numeroTelefone, cpf, rua, cidade, estado, especialidade, nomeMedico, particular, numeroDaCarteirinha, valorConsulta);

                    consultas.Add(consulta);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao carregar a linha {i}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static void Exe1()
    {
        var pacientesAtendidos = consultas.DistinctBy(p => p.NomePaciente)
        .Where(c => c.DataConsulta.Day > 26 && c.DataConsulta.Month == 3);
        foreach (var paciente in pacientesAtendidos)
        {
            Console.WriteLine(paciente.NomePaciente);
        }
        Console.WriteLine($"Total: {pacientesAtendidos.Count()}");
    }
    public static void Exe2()
    {
        var medicosDistintos = consultas.DistinctBy(m => m.NomeMedico);
        foreach (var medico in medicosDistintos)
        {
            Console.WriteLine(medico.NomeMedico);
        }
        Console.WriteLine($"Total: {medicosDistintos.Count()}");
    }
    public static void Exe3()
    {
        var medicos = consultas.GroupBy(m => m.NomeMedico)
        .Select(m => new
        {
            nome = m.Key,
            especialidade = m.Select(e => e.Especialidade).Distinct()
        });
        foreach (var medico in medicos)
        {
            Console.WriteLine($"{medico.nome} - " + string.Join(", ", medico.especialidade));
        }
    }
    public static void Exe4()
    {
        var valorConsulta = consultas.GroupBy(c => c.Especialidade);
        var total = consultas.Sum(c => c.ValorConsulta);
        Console.WriteLine($"Total: {total}:c");
        foreach (var consulta in valorConsulta)
        {
            Console.WriteLine($"{consulta.Key} - {consulta.Sum(c => c.ValorConsulta):c}");
        }
    }
    public static void Exe5()
    {
        var diaConsulta = consultas
        .Select(c => new
        {
            nome = c.NomeMedico,
            especialidade = c.Especialidade,
            horario = c.HoraDaConsulta,
            data = c.DataConsulta,
            particular = c.Particular
        }).Where(c => c.data.Day == 30);

        Console.Write($"Para o dia 30/03 - Total de {diaConsulta.Count()} consultas. ");
        Console.WriteLine($"{diaConsulta.Count(p => p.particular)} particulares e {diaConsulta.Count(p => !p.particular)} convênios\n");
        foreach (var consulta in diaConsulta)
        {
            Console.WriteLine($"{consulta.nome} - {consulta.especialidade} / {consulta.horario}");
        }
    }
}