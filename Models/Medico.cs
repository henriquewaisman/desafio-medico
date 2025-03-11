namespace LinqTest.Models;
class Medico
{
    public string NomeMedico { get; private set; }
    public List<string> Especialidade { get; private set; }

    public Medico(string nomeMedico, List<string> especialidade)
    {
        SetNomeMedico(nomeMedico);
        SetEspecialidade(especialidade);
    }

    public void SetNomeMedico(string nomeMedico)
    {
        if (string.IsNullOrWhiteSpace(nomeMedico))
        {
            throw new ArgumentException("O nome do médico não pode estar vazio");
        }
        if (nomeMedico.Any(char.IsDigit))
        {
            throw new ArgumentException("O nome não pode conter números");
        }
        NomeMedico = nomeMedico;
    }

    public void SetEspecialidade(List<string> especialidade)
    {
        if (especialidade == null || especialidade.Count == 0)
        {
            throw new ArgumentException("A lista de especialidades não pode estar vazia");
        }
        Especialidade = new List<string>(especialidade);
    }
}
