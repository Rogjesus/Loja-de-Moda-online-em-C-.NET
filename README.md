Este repositório contém o código-fonte para o controlador HomeController de um aplicativo ASP.NET MVC chamado DigitalFashionPortal. Este controlador gerencia diversas ações relacionadas a páginas como index, about, services, contact, registro e login de usuários.

Estrutura do Código
Namespaces e Imports
csharp
Copiar código
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using DigitalFashionPortal_MVC.Models;
Os namespaces importados são essenciais para o funcionamento do ASP.NET MVC e para a interação com o Entity Framework.

Controlador HomeController
O controlador HomeController é responsável por gerenciar as ações e exibir as respectivas views. Ele contém métodos para lidar com requisições GET e POST.

Métodos de Ação
Index(): Exibe a página inicial.
About(): Exibe a página sobre.
Services(): Exibe a página de serviços.
Contact(): Exibe a página de contato.
Registration(): Exibe a página de registro (GET) e processa o registro de novos usuários (POST).
Login(): Exibe a página de login (GET) e processa a autenticação do usuário (POST).
Exemplo de Código
Método Registration (GET)
csharp
Copiar código
public ActionResult Registration()
{
    return View();
}
Este método exibe a página de registro.

Método Registration (POST)
csharp
Copiar código
[HttpPost]
public ActionResult Registration(TblUser tblUser)
{
    using (DigitalFashionEntities db = new DigitalFashionEntities())
    {
        if (ModelState.IsValid)
        {
            db.TblUsers.Add(tblUser);
            db.SaveChanges();
            ModelState.Clear();
        }
    }
    return View();
}
Este método processa o registro de novos usuários, salvando-os no banco de dados se o modelo for válido.

Método Login (POST)
csharp
Copiar código
[HttpPost]
public ActionResult Login(TblUser tblUser)
{
    using (DigitalFashionEntities db = new DigitalFashionEntities())
    {
        if (ModelState.IsValid)
        {
            var log = db.TblUsers.Where(a => a.userName.Equals(tblUser.userName) && a.password.Equals(tblUser.password)).FirstOrDefault();
            if (log != null)
            {
                return RedirectToAction("Contact");
            }
            db.SaveChanges();
            ModelState.Clear();
        }
    }
    return View();
}
Este método autentica os usuários verificando suas credenciais no banco de dados e redireciona para a página de contato em caso de sucesso.

Requisitos
ASP.NET MVC 4 ou superior
Entity Framework 6 ou superior
SQL Server
Como Executar
Clone o repositório para o seu ambiente local.
Abra o projeto no Visual Studio.
Configure a string de conexão no arquivo web.config de acordo com a sua configuração de banco de dados.
Compile e execute o projeto.
Estrutura do Banco de Dados
O projeto utiliza o Entity Framework para gerenciar a persistência de dados. A tabela principal usada é TblUsers que armazena informações dos usuários registrados.    
em atualização...

