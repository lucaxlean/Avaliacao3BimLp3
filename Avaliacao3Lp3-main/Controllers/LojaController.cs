using AvaliacaoLp3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao3Lp3.Controllers;

public class LojaController : Controller
{
    public static List<LojaViewModel> lojas = new List<LojaViewModel>();

    public IActionResult Index()
    {
        return View(lojas);
    }

    public IActionResult Gerenciamento()
    {
        return View(lojas);
    }

    public IActionResult Detalhes(int id)
    {
        return View(lojas[id - 1]);
    }

    public IActionResult Excluir(int id)
    {
        lojas.RemoveAt(id - 1);
        return View();
    }

    public IActionResult Cadastramento()
    {
        return View();
    }

    public IActionResult ConfirmacaoCadastramento([FromForm] string piso, [FromForm] string nome, [FromForm] string descricao, [FromForm] string tipo, [FromForm] string email)
    {
        foreach (var loja in lojas)
        {
            if(nome == loja.Nome)
            {
                ViewData["Texto"] = "Não foi possivel fazer o cadastro";
                return View();
            }
        }

        int id = 1;
        for(int i = 0; i < lojas.Count(); i++){
            i++;
        }

        lojas.Add(new LojaViewModel(id, piso, nome, descricao, tipo, email));

        ViewData["Texto"] = "Loja cadastrada";

        return View();
    }
}