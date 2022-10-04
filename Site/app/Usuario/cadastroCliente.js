async function CarregarTemplate(enderecoTela) {
    const template = await fetch(enderecoTela)
        .then(response => {
            return response.text();
        }).catch(erro => {
            console.log(erro);
        });
    return template;
}


function converterParaDomElement(str) {
    let parser = new DOMParser();
    let doc = parser.parseFromString(str, 'text/html');
    return doc.body;
};

async function SalvarFichaCliente() {
    let idUsuario = document.querySelector('#idUsuario').value;
    console.log(idUsuario);
    let nome = document.querySelector('#nome').value;
    console.log(nome);
    let cpf = document.querySelector('#cpf').value;
    console.log(cpf);
    let dataNascimento = document.querySelector('#dataNascimento').value;
    console.log(dataNascimento);
    let telefone = document.querySelector('#telefone').value;
    console.log(telefone);
    let email = document.querySelector('#email').value;
    console.log(email);
    let dataCadastro = document.querySelector('#dataNascimento').value;
    console.log(dataCadastro);

    let createClienteViewModel = {
        Cliente :
        {
            IdUsuario: parseInt(idUsuario),
            Nome : nome,
            Cpf : cpf,
            DataNascimento: dataNascimento,
            Telefone: telefone,
            Email: email,
            DataCadastro: dataCadastro,            
        }        
    };


    console.log(createClienteViewModel);

    let response =  EnviarApi(createClienteViewModel);
    console.log(response);
}

//função para fazer uma request na api;
async function EnviarApi(viewmodel) {

    //opções/dados para fazer a request;
    const options = {
        //método, se é um post, get etc..
        method: 'POST',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(viewmodel)
    };

    //TODO: mudar a url para o seu localhost.
    const req =  fetch('https://localhost:44335/cliente/CreateCliente', options)
        //caso a request dê certo, retornará a resposta;
        .then(response => {
            response.text()
                .then(data => {
                    alert(data);
                    return data;
                });
        })
        //caso dê erro, irá retornar o erro e mostrar no console
        .catch(erro => {
            console.log(erro);
            return erro;
        });

    return req;
}


function Voltar() {
    window.location = "../../index.html";
}