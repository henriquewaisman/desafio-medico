namespace LinqTest.Models;
class Consulta
{
    public DateTime DataConsulta { get; private set; }
    public string HoraDaConsulta { get; private set; }
    public string NomePaciente { get; private set; }
    public string? NumeroTelefone { get; private set; }
    public long Cpf { get; private set; }
    public string Rua { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Especialidade { get; private set; }
    public string NomeMedico { get; private set; }
    public bool Particular { get; private set; }
    public long NumeroDaCarteirinha { get; private set; }
    public double ValorConsulta { get; set; }
    public Consulta(DateTime dataConsulta, string horaDaConsulta, string nomePaciente, string? numeroTelefone, long cpf, string rua, string cidade, string estado, string especialidade, string nomeMedico, bool particular, long numeroDaCarteirinha, double valorConsulta)
    {
        SetDataConsulta(dataConsulta);
        SetHoraDaConsulta(horaDaConsulta);
        SetNomePaciente(nomePaciente);
        SetNumeroTelefone(numeroTelefone);
        SetCpf(cpf);
        SetRua(rua);
        SetCidade(cidade);
        SetEstado(estado);
        SetEspecialidade(especialidade);
        SetNomeMedico(nomeMedico);
        SetParticular(particular);
        SetNumeroDaCarteirinha(numeroDaCarteirinha);
        SetValorConsulta(valorConsulta);
    }

    public void SetDataConsulta(DateTime dataConsulta)
    {
        if (dataConsulta == DateTime.MinValue && string.IsNullOrWhiteSpace(dataConsulta.ToString()))
        {
            throw new Exception("Data inválida");
        }
        DataConsulta = dataConsulta;
    }
    public void SetHoraDaConsulta(string horaDaConsulta)
    {
        if (string.IsNullOrWhiteSpace(horaDaConsulta))
        {
            throw new Exception("A hora da consulta não pode estar vazia");
        }
        HoraDaConsulta = horaDaConsulta;
    }
    public void SetNomePaciente(string nomePaciente)
    {
        if (string.IsNullOrWhiteSpace(nomePaciente))
        {
            throw new Exception("O nome do paciente não pode estar vazio");
        }
        if (nomePaciente.Any(char.IsDigit) == true)
        {
            throw new Exception("O nome não pode conter números");
        }
        NomePaciente = nomePaciente;
    }
    public void SetNumeroTelefone(string? numeroTelefone)
    {
        if (numeroTelefone?.Any(char.IsDigit) == false)
        {
            throw new Exception("O número de telefone é inválido");
        }
        if (!string.IsNullOrEmpty(numeroTelefone))
        {
            numeroTelefone = "";
        }
        NumeroTelefone = numeroTelefone;
    }
    public void SetCpf(long cpf)
    {
        if (cpf.ToString().Length != 11 && string.IsNullOrEmpty(cpf.ToString()))
        {
            throw new Exception("CPF inválido");
        }
        Cpf = cpf;
    }
    public void SetRua(string rua)
    {
        if (string.IsNullOrEmpty(rua))
        {
            throw new Exception("Nome da rua inválido");
        }
        if (rua.Length > 255)
        {
            throw new Exception("A rua deve conter no máximo 255 caracteres");
        }
        Rua = rua;
    }
    public void SetCidade(string cidade)
    {
        if (string.IsNullOrWhiteSpace(cidade))
        {
            throw new Exception("Nome da cidade inválido");
        }
        if (cidade.Length > 255)
        {
            throw new Exception("A Cidade deve conter no máximo 255 caracteres");
        }
        Cidade = cidade;
    }
    public void SetEstado(string estado)
    {
        if (string.IsNullOrWhiteSpace(estado))
        {
            throw new Exception("Nome da estado inválido");
        }
        if (estado.Length > 255)
        {
            throw new Exception("O estado deve conter no máximo 255 caracteres");
        }
        Estado = estado;
    }
    public void SetEspecialidade(string especialidade)
    {
        if (string.IsNullOrEmpty(especialidade))
        {
            throw new Exception("Nome da especialidade inválido");
        }
        if (especialidade.Length > 255)
        {
            throw new Exception("A especialidade deve conter no máximo 255 caracteres");
        }
        Especialidade = especialidade;
    }
    public void SetNomeMedico(string nomeMedico)
    {
        if (string.IsNullOrWhiteSpace(nomeMedico))
        {
            throw new Exception("O nome do medico não pode estar vazio");
        }
        if (nomeMedico.Any(char.IsDigit) == true)
        {
            throw new Exception("O nome não pode conter números");
        }
        NomeMedico = nomeMedico;
    }
    public void SetParticular(bool particular)
    {
        Particular = particular;
    }
    public void SetNumeroDaCarteirinha(long numeroDaCarteirinha)
    {
        if (numeroDaCarteirinha < 0)
        {
            throw new Exception("Numero da carteirinha inválido");
        }
        NumeroDaCarteirinha = numeroDaCarteirinha;
    }
    public void SetValorConsulta(double valorConsulta)
    {
        if (valorConsulta < 0)
        {
            throw new Exception("Valor de consulta inválido");
        }
        ValorConsulta = valorConsulta;
    }
}