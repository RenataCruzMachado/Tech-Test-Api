using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_api.Dtos
{
    public class TurmaDto{
        public int Id { get; set; }
        public string NomeTurma { get; set; }
        public int AnoLetivo { get; set; }
        public int QtdMaximaAlunos { get; set; }
    }
}