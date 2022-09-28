using Microsoft.AspNetCore.Mvc;

namespace TreinoAPI.Interfaces
{
    public interface CrudInterface
    {
        IActionResult Cadastro();
        IActionResult Atualizar();
        IActionResult Consultar();
        IActionResult Remover();
    }
}
