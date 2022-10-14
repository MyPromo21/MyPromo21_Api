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

async function SalvarEndereco() {
    let idEstabelecimento = document.querySelector('#idEstabelecimento').value;
    console.log(idEstabelecimento);

    let estado = document.querySelector('#estado').value;
    console.log(estado);

    let cidade = document.querySelector('#cidade').value;
    console.log(cidade);

    let bairro = document.querySelector('#bairro').value;
    console.log(bairro);

    let rua = document.querySelector('#rua').value;
    console.log(rua);

    let numero = document.querySelector('#numero').value;
    console.log(numero);

    let complemento = document.querySelector('#complemento').value;
    console.log(complemento);

    let cep = document.querySelector('#cep').value;
    console.log(cep);
    

    let createEstabelecimentoViewModel = {
        Endereco :
        {
            IdEstabelecimento : parseInt(idEstabelecimento),
            Estado : estado,
            Cidade : cidade,
            Bairro : bairro,
            Rua : rua,
            Numero : numero,
            Complemento : complemento,
            Cep : cep,

            
        }        
    };


    console.log(createEstabelecimentoViewModel);

    let response =  EnviarApi(createEstabelecimentoViewModel);
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
    const req =  fetch('https://localhost:44335/endereco/Create', options)
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