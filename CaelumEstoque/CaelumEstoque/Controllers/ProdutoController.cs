using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto pmodel)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(pmodel);
            return RedirectToAction("Index", "Home");
        }
    }
}