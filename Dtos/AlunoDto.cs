using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_api.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}